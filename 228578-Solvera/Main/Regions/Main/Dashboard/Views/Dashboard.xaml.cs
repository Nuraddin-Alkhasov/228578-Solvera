using System;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.UserManagement;

namespace HMI.MainRegion.Dashboard.Views
{
    [ExportView("Dashboard")]
    public partial class Dashboard : View
    {
        int cd = 0;
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new Adapters.Dashboard();

        }



        #region - - - Event Handlers - - -
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
           cd = cd + 1;

            if (cd >= 5)
            {
                IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();

                if (userService.CurrentUser.RightNames.Contains("Dashboard"))
                {
                    Adapters.Dashboard a = (Adapters.Dashboard)DataContext;
                    a.TurnOnEditing();
                }
            }
          
        }
        private void btn_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cd = 0;
        }

        private void btn_PreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            cd = 0;
        }
        #endregion




    }
}