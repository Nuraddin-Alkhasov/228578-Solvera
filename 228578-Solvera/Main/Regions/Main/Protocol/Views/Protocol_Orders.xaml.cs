using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Protocol.Views
{
    /// <summary>
    /// Interaction logic for Protocol.xaml
    /// </summary>
    [ExportView("Protocol_Orders")]
    public partial class Protocol_Orders
    {

        public Protocol_Orders()
        {
            InitializeComponent();



        }
        private void DataGridRow_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            //dgv_orders.UnselectAllCells();
            //((DataGridRow)sender).IsSelected = true;
            //oldIndex = dgv_orders.SelectedIndex;
        }
    }
}