using System.Security.Permissions;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.Dashboard.Views
{
    [ExportView("WidgetSelector")]
    public partial class WidgetSelector : View
    {
        public WidgetSelector()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("DR_Dashboard");

        }
        private void gi_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            list.UnselectAll();
            ((System.Windows.Controls.ListBoxItem)sender).IsSelected = true;
        }
        public static bool Show(DashboardWidgetCommandParameter parameter)
        {
            ApplicationService.ObjectStore.Add("DWCP", parameter);
            ApplicationService.SetView("DialogRegion1", "WidgetSelector");
            object result = null;
            while ((result = ApplicationService.ObjectStore["SelectedWidget"]) == null)
            {
                DoEvents();
            }

            return true;
        }

        #region - - - DoEvents - - - 

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]

        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);

            Thread.Sleep(10);
        }

        public static object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
        #endregion

    }
}