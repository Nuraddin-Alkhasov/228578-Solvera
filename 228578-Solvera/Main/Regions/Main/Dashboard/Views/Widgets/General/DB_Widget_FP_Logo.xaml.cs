using HMI.CO.General;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.Dashboard.Widgets
{
    [ExportDashboardWidget("DB_Widget_FP_Logo", "Dashboard.Text4", "@Dashboard.Text12", 1, 1)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_FP_Logo
    {

        public DB_Widget_FP_Logo()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }
        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}