using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Maintenance.Views
{
    [ExportView("Maintenance_Current")]
    public partial class Maintenance_Current
    {
        public Maintenance_Current()
        {

            InitializeComponent();
            DataContext = new Adapters.Maintenance_Current();

        }

    }
}