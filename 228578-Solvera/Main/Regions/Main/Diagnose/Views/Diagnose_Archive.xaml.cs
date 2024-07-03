using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Diagnose.Views
{
    /// <summary>
    /// Interaction logic for AlarmHistoryView.xaml
    /// </summary>
    [ExportView("Diagnose_Archive")]
    public partial class Diagnose_Archive
    {
        public Diagnose_Archive()
        {
            InitializeComponent();
            DataContext = new Adapters.Diagnose_Archive();
        }

        private void ButtonOpenMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}