using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SharpSheet.Document
{
    public class Sheet
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string[,] Cells { get; set; }

        [XmlAttribute("rows")]
        public int RowCount
        {
            get { return Cells.GetLength(0); }
            set
            {
                if (value != RowCount)
                {
                    int rows = (value < RowCount) ? value : RowCount;
                    var oldCells = Cells;
                    Cells = new string[value, ColumnCount];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < ColumnCount; j++)
                        {
                            Cells[i, j] = oldCells[i, j];
                        }
                    }
                }
            }
        }
        [XmlAttribute("cols")]
        public int ColumnCount
        {
            get { return Cells.GetLength(1); }
            set
            {
                if (value != ColumnCount)
                {
                    int cols = (value < ColumnCount) ? value : ColumnCount;
                    var oldCells = Cells;
                    Cells = new string[RowCount, value];
                    for (int i = 0; i < RowCount; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Cells[i, j] = oldCells[i, j];
                        }
                    }
                }
            }
        }

        [XmlElement("row")]
        public Row[] Rows
        {
            get
            {
                return range(RowCount)
                    .Where(r => range(ColumnCount).Any(c => Cells[r, c] != null))
                    .Select(r => new Row()
                    {
                        Index = r,
                        Cells = range(ColumnCount)
                            .Where(c => Cells[r, c] != null)
                            .Select(c => new Cell()
                            {
                                Index = c,
                                Formula = Cells[r, c]
                            }).ToArray()
                    }).ToArray();
            }
            set
            {
                Cells = new string[value.Max(r => r.Index), value.Max(r => r.Cells.Max(c => c.Index))];
                foreach (var row in value)
                {
                    foreach (var cell in row.Cells)
                    {
                        Cells[row.Index, cell.Index] = cell.Formula;
                    }
                }
            }
        }

        private static IEnumerable<int> range(int count)
        {
            return Enumerable.Range(0, count);
        }
    }
}
