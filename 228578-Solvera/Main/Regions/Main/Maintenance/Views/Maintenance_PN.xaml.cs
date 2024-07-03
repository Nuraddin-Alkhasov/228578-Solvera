using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Maintenance.Views
{
    [ExportView("Maintenance_PN")]
    public partial class Maintenance_PN
    {
        public Maintenance_PN()
        {
            InitializeComponent();
        }
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private void Pn_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            header.LocalizableText = pn_maintenance.SelectedPanoramaRegionIndex == 0 ? "@Maintenance.Text1" : "@Maintenance.Text2";
        }

    }
}