using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.UM.Views
{
    /// <summary>
    /// Interaction logic for View2.xaml
    /// </summary>
    [ExportView("UM_PN")]
    public partial class UM_PN
    {
        public UM_PN()
        {
            InitializeComponent();
        }

        private void Pn_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            header.LocalizableText = pn_um.SelectedPanoramaRegionIndex == 0 ? "@UserManagement.View.Text1" : "@UserManagement.View.Text2";
        }

        private void pn_um_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (pn_um.SelectedPanoramaRegionIndex != 0)
                pn_um.ScrollPrevious();
        }
    }
}