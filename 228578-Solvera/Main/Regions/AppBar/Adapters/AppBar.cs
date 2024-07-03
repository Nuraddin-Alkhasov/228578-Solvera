using HMI.CO.General;
using HMI.MainRegion.Diagnose.Views;
using HMI.MainRegion.Maintenance.Views;
using HMI.MainRegion.Protocol.Views;
using HMI.MainRegion.Recipes.Views;
using HMI.MainRegion.UM.Views;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.AppBarRegion.Adapters
{
    [ExportAdapter("AppBar")]
    public class AppBar : AdapterBase
    {
        public AppBar()
        {
            if (ApplicationService.IsInDesignMode) { return; }
            DashboardViewOpenExecuted(null);
            languageService.LanguageChanged += LanguageService_LanguageChanged;

            Open = new ActionCommand(OpenExecuted);
            Close = new ActionCommand(CloseExecuted);

            DashboardViewOpen = new ActionCommand(DashboardViewOpenExecuted);
            MainViewOpen = new ActionCommand(MainViewOpenExecuted);
            RecipesViewOpen = new ActionCommand(RecipesViewOpenExecuted);
            OrdersViewOpen = new ActionCommand(OrdersViewOpenExecuted);
            LoggingViewOpen = new ActionCommand(LoggingViewOpenExecuted);
            PMViewOpen = new ActionCommand(PMViewOpenExecuted);
            UMViewOpen = new ActionCommand(UMViewOpenExecuted);
            DiagnoseViewOpen = new ActionCommand(DiagnoseViewOpenExecuted);

            ChangeLanguage = new ActionCommand(ChangeLanguageExecuted);
            LogIn = new ActionCommand(LogInExecuted);
            Exit = new ActionCommand(ExitExecuted);

        }


        #region - - - Properties - - -
        private readonly ILanguageService languageService = ApplicationService.GetService<ILanguageService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        ICurrentAlarms2 CurrentAlarmList;

        private Visibility openButtonVisibility = Visibility.Visible;
        public Visibility OpenButtonVisibility
        {
            get { return openButtonVisibility; } 
            set
            {
                openButtonVisibility = value;
                OnPropertyChanged("OpenButtonVisibility");
            }
        }

        private Visibility closeButtonVisibility = Visibility.Collapsed;
        public Visibility CloseButtonVisibility
        {
            get { return closeButtonVisibility; }
            set
            {
                closeButtonVisibility = value;
                OnPropertyChanged("CloseButtonVisibility");
            }
        }

        private string ltDashboardViewButton = "@Appbar.Text10";
        public string LTDashboardViewButton
        {
            get { return ltDashboardViewButton; }
            set
            {
                ltDashboardViewButton = value;
                OnPropertyChanged("LTDashboardViewButton");
            }
        }

        private string ltMainViewButton = "@Appbar.Text10";
        public string LTMainViewButton
        {
            get { return ltMainViewButton; }
            set
            {
                ltMainViewButton = value;
                OnPropertyChanged("LTMainViewButton");
            }
        }

        private string ltRecipeViewButton = "@Appbar.Text10";
        public string LTRecipeViewButton
        {
            get { return ltRecipeViewButton; }
            set
            {
                ltRecipeViewButton = value;
                OnPropertyChanged("LTRecipeViewButton");
            }
        }

        private string ltOrdersViewButton = "@Appbar.Text10";
        public string LTOrdersViewButton
        {
            get { return ltOrdersViewButton; }
            set
            {
                ltOrdersViewButton = value;
                OnPropertyChanged("LTOrdersViewButton");
            }
        }
        private string ltLoggingViewButton = "@Appbar.Text10";
        public string LTLoggingViewButton
        {
            get { return ltLoggingViewButton; }
            set
            {
                ltLoggingViewButton = value;
                OnPropertyChanged("LTLoggingViewButton");
            }
        }

        private string ltPMViewButton = "@Appbar.Text10";
        public string LTPMViewButton
        {
            get { return ltPMViewButton; }
            set
            {
                ltPMViewButton = value;
                OnPropertyChanged("LTPMViewButton");
            }
        }

        private string ltUMViewButton = "@Appbar.Text10";
        public string LTUMViewButton
        {
            get { return ltUMViewButton; }
            set
            {
                ltUMViewButton = value;
                OnPropertyChanged("LTUMViewButton");
            }
        }

        private string ltDiagnoseViewButton = "@Appbar.Text10";
        public string LTDiagnoseViewButton
        {
            get { return ltDiagnoseViewButton; }
            set
            {
                ltDiagnoseViewButton = value;
                OnPropertyChanged("LTDiagnoseViewButton");
            }
        }

        private string currentLanguage = "";
        public string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
                OnPropertyChanged("CurrentLanguage");
            }
        }

        private string currentUser = "";
        public string CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        private string powerOff = "";
        public string PowerOff
        {
            get { return powerOff; }
            set
            {
                powerOff = value;
                OnPropertyChanged("PowerOff");
            }
        }

        private string dstatus = "0";
        public string DStatus
        {
            get { return dstatus; }
            set
            {
                dstatus = value;
                OnPropertyChanged("DStatus");
            }
        }

        private string pmstatus = "0";
        public string PMStatus
        {
            get { return pmstatus; }
            set
            {
                pmstatus = value;
                OnPropertyChanged("PMStatus");
            }
        }

        #endregion

        #region - - - Event Handlers - - -
        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            if (CurrentLanguage != "")
            {
                var name = ((ILanguageService)sender).CurrentLanguage.Text;
                CurrentLanguage = name.Substring(0, name.IndexOf('(') - 1);
            }
        }

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();
                CurrentAlarmList.ChangeAlarm += SetAlarmLineData;
                CurrentAlarmList.NewAlarm += SetAlarmLineData;
                CurrentAlarmList.ClearAlarm += SetAlarmLineData;
            }
            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }


        #endregion

        #region - - - Commands - - -
        public ICommand Open { get; set; }
        public void OpenExecuted(object parameter)
        {
            LTDashboardViewButton = "@Appbar.Text1";
            LTMainViewButton = "@Appbar.Text2";
            LTRecipeViewButton = "@Appbar.Text3";
            LTOrdersViewButton = "@Appbar.Text4";
            LTLoggingViewButton = "@Appbar.Text5";
            LTPMViewButton = "@Appbar.Text6";
            LTUMViewButton = "@Appbar.Text7";
            LTDiagnoseViewButton = "@Appbar.Text8";

            string name = languageService.CurrentLanguage.Text;
            CurrentLanguage = name.Substring(0, name.IndexOf('(') - 1);
            CurrentUser = ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString();
            PowerOff = "@Appbar.Text9";

            Views.AppBar v = (Views.AppBar)iRS.GetView("AppBar");
            new ObjectAnimator().OpenAppBar(v, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }
        public ICommand Close { get; set; }
        public void CloseExecuted(object parameter)
        {
            LTDashboardViewButton = "@Appbar.Text10";
            LTMainViewButton = "@Appbar.Text10";
            LTRecipeViewButton = "@Appbar.Text10";
            LTOrdersViewButton = "@Appbar.Text10";
            LTLoggingViewButton = "@Appbar.Text10";
            LTPMViewButton = "@Appbar.Text10";
            LTUMViewButton = "@Appbar.Text10";
            LTDiagnoseViewButton = "@Appbar.Text10";
            CurrentLanguage = "";
            CurrentUser = "";
            PowerOff = "@Appbar.Text10";

            Views.AppBar v = (Views.AppBar)iRS.GetView("AppBar");
            new ObjectAnimator().CloseAppBar(v, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }

        public ICommand DashboardViewOpen { get; set; }
        private void DashboardViewOpenExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "Dashboard");
        }
        public ICommand MainViewOpen { get; set; }
        private void MainViewOpenExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "MO_MainView");
        }
        public ICommand RecipesViewOpen { get; set; }
        public void RecipesViewOpenExecuted(object parameter)
        {
            Recipes_PN R_PN = (Recipes_PN)iRS.GetView("Recipes_PN");

            if (iRS.GetCurrentViewName("MainRegion") == "Recipes_PN")
            {
                switch (R_PN.pn_recipe.SelectedPanoramaRegionIndex) 
                {
                    case 0: R_PN.pn_recipe.ScrollNext(true); break;
                    case 1: break;
                    case 2: R_PN.pn_recipe.ScrollPrevious(true); break;
                }
            }
            else 
            {
                ApplicationService.SetView("MainRegion", "Recipes_PN");

            }

        }
        public ICommand OrdersViewOpen { get; set; }
        private void OrdersViewOpenExecuted(object parameter)
        {
            Protocol_PN P_PN = (Protocol_PN)iRS.GetView("Protocol_PN");

            if (iRS.GetCurrentViewName("MainRegion") != "Protocol_PN")
            {
                P_PN.pn_protocol.SelectedPanoramaRegionIndex = 0;

                ApplicationService.SetView("MainRegion", "Protocol_PN");
            }
            else
            {
                P_PN.pn_protocol.ScrollPrevious(true);
            }

        }
        public ICommand LoggingViewOpen { get; set; }
        private void LoggingViewOpenExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "Logging");
        }
        public ICommand PMViewOpen { get; set; }
        private void PMViewOpenExecuted(object parameter)
        {
            Maintenance_PN M_PN = (Maintenance_PN)iRS.GetView("Maintenance_PN");
            if (iRS.GetCurrentViewName("MainRegion") == "Maintenance_PN")
            {
                if (M_PN.pn_maintenance.SelectedPanoramaRegionIndex == 0)
                {
                    M_PN.pn_maintenance.ScrollNext(true);
                }
                else
                {
                    M_PN.pn_maintenance.ScrollPrevious(true);
                }
            }
            else
            {
                ApplicationService.SetView("MainRegion", "Maintenance_PN");
            }
        }
        public ICommand UMViewOpen { get; set; }
        private void UMViewOpenExecuted(object parameter)
        {
            UM_PN U_PN = (UM_PN)iRS.GetView("UM_PN");
            if (iRS.GetCurrentViewName("MainRegion") == "UM_PN")
            {
                if (U_PN.pn_um.SelectedPanoramaRegionIndex == 0)
                {
                    U_PN.pn_um.ScrollNext(true);
                }
                else
                {
                    U_PN.pn_um.ScrollPrevious(true);
                }
            }
            else
            {
                ApplicationService.SetView("MainRegion", "UM_PN");
            }
        }
        public ICommand DiagnoseViewOpen { get; set; }
        private void DiagnoseViewOpenExecuted(object parameter)
        {
            Diagnose_PN D_PN = (Diagnose_PN)iRS.GetView("Diagnose_PN");
            if (iRS.GetCurrentViewName("MainRegion") == "Diagnose_PN")
            {
                if (D_PN.pn_diagnose.SelectedPanoramaRegionIndex == 0)
                {
                    D_PN.pn_diagnose.ScrollNext(true);
                }
                else
                {
                    D_PN.pn_diagnose.ScrollPrevious(true);
                }
            }
            else
            {
                ApplicationService.SetView("MainRegion", "Diagnose_PN");
            }
        }

        public ICommand ChangeLanguage { get; set; }
        private void ChangeLanguageExecuted(object parameter)
        {
            switch (languageService.CurrentLanguage.LCID)
            {
                case 1033: languageService.ChangeLanguageAsync(1031); break;
                case 1031: languageService.ChangeLanguageAsync(1045); break;
                case 1045: languageService.ChangeLanguageAsync(1033); break;
                default: languageService.ChangeLanguageAsync(1033); break;
            }
        }

        public ICommand LogIn { get; set; }
        private void LogInExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_LogOnOff");
        }
        public ICommand Exit { get; set; }
        private void ExitExecuted(object parameter)
        {
            if (MessageBoxView.Show("@Appbar.Text11", "@Appbar.Text12", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }


        #endregion

        #region - - - Methods - - -

        void SetAlarmLineData(object sender, AlarmEventArgs e)
        {
            IAlarmItem[] TPM = CurrentAlarmList.Alarms.Where(x => x.Group.Name == "PM" && x.AlarmState == AlarmState.Active).ToArray();
            IAlarmItem[] TE = CurrentAlarmList.Alarms.Where(x => x.Group.Name == "Errors" && x.AlarmState == AlarmState.Active).ToArray();
            IAlarmItem[] TW = CurrentAlarmList.Alarms.Where(x => x.Group.Name == "Warnings" && x.AlarmState == AlarmState.Active).ToArray();

            PMStatus = TPM.Length > 0 ? "1" : "0";
            DStatus = TE.Length == 0 && TW.Length > 0 ? "1" : TE.Length > 0 && TW.Length == 0 ? "2" : TE.Length > 0 && TW.Length > 0 ? "3" : "0";
        }

        #endregion


    }
}