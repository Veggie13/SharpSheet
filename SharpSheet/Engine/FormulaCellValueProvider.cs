using System;

namespace SharpSheet.Engine
{
    class FormulaCellValueProvider : ICellValueProvider
    {
        public FormulaCellValueProvider()
        {
            Formula = () => null;
        }

        public event Action Modified = delegate { };

        private CellFormulaDelegate _formula;
        public CellFormulaDelegate Formula
        {
            get { return _formula; }
            set
            {
                if (value == null)
                {
                    _formula = () => null;
                }
                else
                {
                    _formula = value;
                }
                Modified();
            }
        }

        public dynamic GetValue(out ICellValueProvider cellValue)
        {
            dynamic val = Formula();
            cellValue = new CachedCellValueProvider() { Value = val };
            return val;
        }
    }
}
