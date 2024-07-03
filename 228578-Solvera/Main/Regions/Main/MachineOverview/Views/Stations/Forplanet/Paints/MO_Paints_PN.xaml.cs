using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.MO.Views
{
    /// <summary>
    /// Interaction logic for View2.xaml
    /// </summary>
    [ExportView("MO_Paints_PN")]
    public partial class MO_Paints_PN
    {
        public MO_Paints_PN()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "MO_CD");
        }
    }
}