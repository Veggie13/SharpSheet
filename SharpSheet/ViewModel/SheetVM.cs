using SharpSheet.Engine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SharpSheet.ViewModel
{
    public class SheetVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private SheetBase _sheet = EmptySheet.Instance;
        public SheetBase Sheet
        {
            get { return _sheet; }
            set
            {
                _sheet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ColumnNames"));
                PropertyChanged(this, new PropertyChangedEventArgs("RowNames"));
                PropertyChanged(this, new PropertyChangedEventArgs("Cells"));
            }
        }

        public IEnumerable<string> ColumnNames
        {
            get
            {
                return Tools.ColumnHeaders.Get(Sheet.ColumnCount);
            }
        }

        public IEnumerable<string> RowNames
        {
            get
            {
                return Enumerable.Range(1, Sheet.RowCount).Select(i => i.ToString()).ToArray();
            }
        }

        public IEnumerable<IEnumerable<CellVM>> Cells
        {
            get
            {
                return Enumerable.Range(0, Sheet.RowCount)
                    .Select(i => Enumerable.Range(0, Sheet.ColumnCount)
                    .Select(j => new CellVM() { Model = Sheet[i, j] }));
            }
        }
    }
}
