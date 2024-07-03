using HMI.CO.General;
using HMI.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.UM.Adapters
{
    [ExportAdapter("UM_LogOnOff")]
    public class UM_LogOnOff : AdapterBase
    {



        public UM_LogOnOff()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Close = new ActionCommand(CloseExecuted);
            LogOnCommand = new ActionCommand(OnLogOnCommandExecuted);
            LogOffCommand = new ActionCommand(OnLogOffCommandExecuted);
        }

        #region - - - Properties - - -

        private readonly IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
        private readonly ILanguageService textService = ApplicationService.GetService<ILanguageService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        private string currentUserName;
        public string CurrentUserName
        {
            get { return currentUserName; }
            set { currentUserName = value; OnPropertyChanged("CurrentUserName"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private bool islogedin = false;
        public bool IsLogedIn
        {
            get { return islogedin; }
            set { islogedin = value; OnPropertyChanged("IsLogedIn"); }
        }

        private bool islogedoff = true;
        public bool IsLogedOff
        {
            get { return islogedoff; }
            set { islogedoff = value; OnPropertyChanged("IsLogedOff"); }
        }
        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.UM_LogOnOff v = (Views.UM_LogOnOff)iRS.GetView("UM_LogOnOff");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }
        public ICommand LogOnCommand { get; set; }
        private void OnLogOnCommandExecuted(object parameter)
        {
            if (string.IsNullOrEmpty(CurrentUserName))
            {
                new MessageBoxTask("@UserManagement.Results.ChooseUser", "@UserManagement.View.LogOnOff", MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                new MessageBoxTask("@UserManagement.Results.EnterPassword", "@UserManagement.View.LogOnOff", MessageBoxIcon.Information);
                return;
            }

            LogOnSuccess success = userService.LogOn(CurrentUserName, Password);
            if (success != LogOnSuccess.Succeeded)
            {
                new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "LogOnSuccess", success.ToString()), "@UserManagement.View.LogOnOff", MessageBoxIcon.Exclamation);



                if (success == LogOnSuccess.RenewPassword)
                {
                    ApplicationService.SetView("DialogRegion1", "UM_ChangePassword", CurrentUserName);
                    Password = "";
                    CurrentUserName = "";
                    IsLogedIn = false;
                    IsLogedOff = true;


                }
            }
            else
            {
                IsLogedIn = true;
                IsLogedOff = false;
                CloseExecuted(null);

                //AppBarRegion.Views.AppBar v = (AppBarRegion.Views.AppBar)iRS.GetView("AppBar");
               // AppBarRegion.Adapters.AppBar a = v.DataContext as AppBarRegion.Adapters.AppBar;
                //Task obTask = Task.Run(async () =>
                //{

                //    Application.Current.Dispatcher.InvokeAsync(delegate { a.OpenExecuted(null); });
                //    await Task.Delay(1000);
                //    Application.Current.Dispatcher.InvokeAsync(delegate { a.CloseExecuted(null); });
                //});
            }

        }

        public ICommand LogOffCommand { get; set; }
        private void OnLogOffCommandExecuted(object parameter)
        {
            if (userService.LogOff())
            {
                Password = "";
                CurrentUserName = "";
                IsLogedIn = false;
                IsLogedOff = true;
                CloseExecuted(null);

              //  AppBarRegion.Views.AppBar v = (AppBarRegion.Views.AppBar)iRS.GetView("AppBar");
                //AppBarRegion.Adapters.AppBar a = v.DataContext as AppBarRegion.Adapters.AppBar;
                //Task obTask = Task.Run(async () =>
                //{

                //    Application.Current.Dispatcher.InvokeAsync(delegate { a.OpenExecuted(null); });
                //    await Task.Delay(1000);
                //    Application.Current.Dispatcher.InvokeAsync(delegate { a.CloseExecuted(null); });
                //});

            }
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            Password = "";
            if (userService.CurrentUser != null)
            {
                CurrentUserName = userService.CurrentUser.Name;
                IsLogedIn = true;
                IsLogedOff = false;
            }
            else 
            {
                IsLogedIn = false;
                IsLogedOff = true;
            }
            Views.UM_LogOnOff v = (Views.UM_LogOnOff)iRS.GetView("UM_LogOnOff");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        #endregion


    }
}