using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Protocol.Views
{
    /// <summary>
    /// Interaction logic for ChargeView.xaml
    /// </summary>
    [ExportView("Protocol_Layers")]
    public partial class Protocol_Layers
    {
        public Protocol_Layers()
        {
            InitializeComponent();
        }


        private void dgrr_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            //dgv_runs.UnselectAllCells();
            //((DataGridRow)sender).IsSelected = true;
            //oldIndex = dgv_orders.SelectedIndex;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "Protocol_Data", dgv_runs.SelectedItem);
        }
    }
}