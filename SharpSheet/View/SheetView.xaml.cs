using SharpSheet.Engine;
using SharpSheet.ViewModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace SharpSheet.View
{
    /// <summary>
    /// Interaction logic for SheetView.xaml
    /// </summary>
    public partial class SheetView : UserControl
    {
        public SheetView()
        {
            ViewModel = new SheetVM();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                ViewModel.Sheet = TestSheet.Instance;
            }

            InitializeComponent();
        }

        public SheetVM ViewModel { get; private set; }

        private void _mainView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _topView.ScrollToHorizontalOffset(e.HorizontalOffset);
            _leftView.ScrollToVerticalOffset(e.VerticalOffset);
        }
    }
}
