using HMI.CO.General;
using HMI.Resources;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.UM.Adapters
{
    [ExportAdapter("UM_ChangePW")]
    public class UM_ChangePW : AdapterBase
    {

        public UM_ChangePW()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Close = new ActionCommand(CloseExecuted);
            ChangePW = new ActionCommand(ChangePWExecuted);
        }

        #region - - - Properties - - -

        private readonly IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        private string username = "";
        public string UserName
        {
            get { return username; }
            set { username = value; OnPropertyChanged("UserName"); }
        }

        private string userfullname = "";
        public string UserFullName
        {
            get { return userfullname; }
            set { userfullname = value; OnPropertyChanged("UserFullName"); }
        }

        private string comment = "";
        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChanged("Comment"); }
        }

        private string oldPassword;
        public string OldPassword
        {
            get { return oldPassword; }
            set { oldPassword = value; OnPropertyChanged("OldPassword"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private string password2;
        public string Password2
        {
            get { return password2; }
            set { password2 = value; OnPropertyChanged("Password2"); }
        }

        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.UM_ChangePassword v = (Views.UM_ChangePassword)iRS.GetView("UM_ChangePassword");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand ChangePW { get; set; }
        private void ChangePWExecuted(object parameter)
        {
            if (string.IsNullOrEmpty(OldPassword))
            {
                new MessageBoxTask("@UserManagement.Results.EnterOldPassword", "@UserManagement.View.ChangePassword", MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                new MessageBoxTask("@UserManagement.Results.EnterPassword", "@UserManagement.View.ChangePassword", MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(Password2))
            {
                new MessageBoxTask("@UserManagement.Results.EnterRepeatedPassword", "@UserManagement.View.ChangePassword", MessageBoxIcon.Exclamation);
                return;
            }

            if (Password != Password2)
            {
                new MessageBoxTask("@UserManagement.Results.EnterSamePassword", "@UserManagement.View.ChangePassword", MessageBoxIcon.Exclamation);
                return;
            }

            ChangePasswordSuccess success = userService.ChangeUserPassword(UserName, Password, OldPassword);
            if (success != ChangePasswordSuccess.Succeeded)
            {
                new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "ChangePasswordError", success.ToString()), "@UserManagement.View.ChangePassword", MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new MessageBoxTask("@UserManagement.Results.ChangePasswordOK", "@UserManagement.View.ChangePassword", MessageBoxIcon.Information);

            }
            CloseExecuted(null);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            string user = ApplicationService.ObjectStore.GetValue("UM_ChangePassword_KEY").ToString();
            ApplicationService.ObjectStore.Remove("UM_ChangePassword_KEY");
            IUser u = userService.GetUser(user);
            UserName = u.Name;
            UserFullName = u.FullName;
            Comment = u.Comment;

            Views.UM_ChangePassword v = (Views.UM_ChangePassword)iRS.GetView("UM_ChangePassword");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        #endregion


    }
}