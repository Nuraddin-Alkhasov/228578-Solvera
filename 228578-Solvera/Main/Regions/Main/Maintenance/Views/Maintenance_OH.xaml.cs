using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Maintenance.Views
{
    [ExportView("Maintenance_OH")]
    public partial class Maintenance_OH
    {
        public Maintenance_OH()
        {

            InitializeComponent();
            DataContext = new Adapters.Maintenance_OH();

        }

    }
}