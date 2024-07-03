using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using HMI.CO.General;

namespace HMI.Dashboard
{
    [ExportDashboardWidget("DB_Widget_PZT", "Dashboard.Text8", "@Dashboard.Text11", 1, 1)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_PZT
    {

        public DB_Widget_PZT()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
            UC.DoWork();
        }
        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }

    }
}
