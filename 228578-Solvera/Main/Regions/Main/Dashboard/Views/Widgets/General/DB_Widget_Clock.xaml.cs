using HMI.CO.General;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.Dashboard.Widgets
{
    [ExportDashboardWidget("DB_Widget_Clock", "Dashboard.Text3", "@Dashboard.Text12", 1, 1)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_Clock
    {

        public DB_Widget_Clock()
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