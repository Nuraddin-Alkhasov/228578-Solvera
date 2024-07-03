using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Protocol.Views
{
    /// <summary>
    /// Interaction logic for ChargeView.xaml
    /// </summary>
    [ExportView("Protocol_Charges")]
    public partial class Protocol_Charges : VisiWin.Controls.View
    {
        public Protocol_Charges()
        {
            InitializeComponent();
        }

        private void dgrb_PreviewTouchDown(object sender, TouchEventArgs e)
        {

            //dgv_boxes.UnselectAllCells();
            // ((DataGridRow)sender).IsSelected = true;
            //oldIndex = dgv_orders.SelectedIndex;
        }
        private void dgrc_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            //  dgv_charges.UnselectAllCells();
            //  ((DataGridRow)sender).IsSelected = true;
            //oldIndex = dgv_orders.SelectedIndex;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "Protocol_MR", dgv_boxes.SelectedItem);
        }
    }
}