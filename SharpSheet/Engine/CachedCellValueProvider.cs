using System;

namespace SharpSheet.Engine
{
    class CachedCellValueProvider : ICellValueProvider
    {
        public event Action Modified = delegate { };

        private dynamic _value;
        public dynamic Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Modified();
            }
        }

        public dynamic GetValue(out ICellValueProvider cellValue)
        {
            cellValue = this;
            return Value;
        }
    }
}
