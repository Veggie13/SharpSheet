using SharpSheet.Engine;
using System.ComponentModel;

namespace SharpSheet.ViewModel
{
    public class CellVM : INotifyPropertyChanged
    {
        private ICellAccessor _model;
        public ICellAccessor Model
        {
            get { return _model; }
            set
            {
                if (_model != null)
                {
                    _model.ValueChanged -= _model_ValueChanged;
                }
                _model = value;
                if (_model != null)
                {
                    _model.ValueChanged += _model_ValueChanged;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Display"));
            }
        }

        private void _model_ValueChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Display"));
        }

        public string Display
        {
            get
            {
                dynamic val = Model.Value;
                if (val == null)
                {
                    return "";
                }
                return val.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
