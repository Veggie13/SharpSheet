using System;

namespace SharpSheet.Engine
{
    public interface ICellAccessor
    {
        event Action ValueChanged;
        dynamic Value { get; }
    }

    class CellAccessor : ICellAccessor
    {
        public event Action ValueChanged = delegate { };

        private ICellValueProvider _cellValue;
        public ICellValueProvider CellValue
        {
            get { return _cellValue; }
            set
            {
                if (_cellValue != null)
                {
                    _cellValue.Modified -= ValueChanged;
                }
                _cellValue = value;
                if (_cellValue != null)
                {
                    _cellValue.Modified += ValueChanged;
                }
            }
        }

        public dynamic Value
        {
            get
            {
                ICellValueProvider cellValue;
                dynamic val = CellValue.GetValue(out cellValue);
                CellValue = cellValue;
                return val;
            }
        }
    }
}
