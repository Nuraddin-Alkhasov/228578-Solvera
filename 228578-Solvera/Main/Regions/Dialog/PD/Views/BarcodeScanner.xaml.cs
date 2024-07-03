using System.Windows;
using HMI.CO.General;
using VisiWin.ApplicationFramework;


namespace HMI.DialogRegion.PD.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("BarcodeScanner")]
    public partial class BarcodeScanner
    {

        public BarcodeScanner()
        {
            InitializeComponent();

        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}