using SharpSheet.Engine;
using System.Windows;

namespace SharpSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _sheetView.ViewModel.Sheet = TestSheet.Instance;
        }
    }
}
