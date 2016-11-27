namespace SharpSheet.Engine
{
    public abstract class SheetBase
    {
        private CellFormulaDelegate[,] _cellFormulae;
        private CellAccessor[,] _cells;

        protected void init(CellFormulaDelegate[,] cellFormulae)
        {
            _cellFormulae = cellFormulae;

            _cells = new CellAccessor[_cellFormulae.GetLength(0), _cellFormulae.GetLength(1)];
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new CellAccessor()
                    {
                        CellValue = new FormulaCellValueProvider() { Formula = _cellFormulae[i, j] }
                    };
                }
            }
        }

        public ICellAccessor this[int i, int j]
        {
            get { return _cells[i, j]; }
        }

        public int RowCount { get { return _cells.GetLength(0); } }
        public int ColumnCount { get { return _cells.GetLength(1); } }
    }
}
