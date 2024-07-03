using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;
using VisiWin.UserManagement;

namespace HMI.MainRegion.Dashboard.Adapters
{

    [ExportAdapter("Dashboard")]
    public class Dashboard : AdapterBase
    {

        public Dashboard()
        {
            Save = new ActionCommand(SaveExecuted);
            Add = new ActionCommand(AddExecuted);
            Cancel = new ActionCommand(CancelExecuted);
            userManagementService.UserLoggedOn += userManagementService_UserLoggedOn;
            userManagementService.UserLoggedOff += userManagementService_UserLoggedOff;

        }

        #region - - - Properties - - -

        private readonly IUserManagementService userManagementService = ApplicationService.GetService<IUserManagementService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();


        private Visibility edit = Visibility.Visible;
        public Visibility Edit
        {
            get { return edit; }
            set
            {
                edit = value;
                OnPropertyChanged("Edit");
            }
        }
        private Visibility sc = Visibility.Collapsed;
        public Visibility SC
        {
            get { return sc; }
            set
            {
                sc = value;
                OnPropertyChanged("SC");
            }
        }

        #endregion
        #region - - - Event Handlers - - -
        private void userManagementService_UserLoggedOff(object sender, LogOffEventArgs e)
        {
            LoadDashboardConfiguration();
        }

        private void userManagementService_UserLoggedOn(object sender, LogOnEventArgs e)
        {
            LoadDashboardConfiguration();
        }

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (e.View.Name == "DB")
            {
                LoadDashboardConfiguration();
            }

            base.OnViewLoaded(sender, e);
        }

        #endregion
        #region - - - Commands - - -
        public ICommand Add { get; set; }
        public void AddExecuted(object parameter)
        {
            if (DialogRegion.Dashboard.Views.WidgetSelector.Show((DashboardWidgetCommandParameter)parameter))
            {
                string wdg = ApplicationService.ObjectStore["SelectedWidget"].ToString();
                if (wdg != "")
                {
                    ((DashboardWidgetCommandParameter)parameter).ViewName = ApplicationService.ObjectStore["SelectedWidget"].ToString();
                }
                ApplicationService.ObjectStore.Remove("SelectedWidget");
            }

        }
        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            Views.Dashboard v = (Views.Dashboard)iRS.GetView("Dashboard");
            if (userManagementService != null)
            {
                if (!string.IsNullOrEmpty(userManagementService.CurrentUserName))
                {
                    v.dashboard.SaveConfiguration(configurationName: userManagementService.CurrentUserName);
                    TurnOffEditing();
                    return;
                }
            }

            v.dashboard.SaveConfiguration();


            TurnOffEditing();

        }

        public ICommand Cancel { get; set; }
        private void CancelExecuted(object parameter)
        {
            if (MessageBoxView.Show("@Dashboard.SaveConfig", "@Dashboard.Text24", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                LoadDashboardConfiguration();
                TurnOffEditing();
            }
        }
        #endregion

        #region - - - Methods - - -
        public void LoadDashboardConfiguration()
        {
            Views.Dashboard v = (Views.Dashboard)iRS.GetView("Dashboard");

            if ((userManagementService != null) && !string.IsNullOrEmpty(userManagementService.CurrentUserName) &&
                v.dashboard.ConfigurationExists(userManagementService.CurrentUserName))
            {
                Dispatcher.BeginInvoke((Action)(() => v.dashboard.LoadConfiguration(configurationName: userManagementService.CurrentUserName)), DispatcherPriority.Loaded);
            }
            else
            {
                Dispatcher.BeginInvoke((Action)(() => v.dashboard.LoadConfiguration()), DispatcherPriority.Loaded);
            }
        }
        public void TurnOnEditing()
        {
            Views.Dashboard v = (Views.Dashboard)iRS.GetView("Dashboard");
            v.dashboard.IsInEditMode = true;
            SC = Visibility.Visible;
            Edit = Visibility.Collapsed;
        }

        private void TurnOffEditing()
        {
            Views.Dashboard v = (Views.Dashboard)iRS.GetView("Dashboard");
            v.dashboard.IsInEditMode = false;
            SC = Visibility.Collapsed;
            Edit = Visibility.Visible;
        }
        #endregion


    }
}