using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.UM.Adapters
{
    [ExportAdapter("UM_AddChangeUser")]
    public class UM_AddChangeUser : AdapterBase
    {



        public UM_AddChangeUser()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Close = new ActionCommand(CloseExecuted);
            AU = new ActionCommand(AUExecuted);
        }

        #region - - - Properties - - -

        private readonly IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private bool isAdd = false;

        private string hLocalizableText = "";
        public string HLocalizableText
        {
            get { return hLocalizableText; }
            set { hLocalizableText = value; OnPropertyChanged("HLocalizableText"); }
        }

        private string bLocalizableText = "";
        public string BLocalizableText
        {
            get { return bLocalizableText; }
            set { bLocalizableText = value; OnPropertyChanged("BLocalizableText"); }
        }

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
        private bool isNameEnabled = false;
        public bool IsNameEnabled
        {
            get { return isNameEnabled; }
            set { isNameEnabled = value; OnPropertyChanged("IsNameEnabled"); }
        }
        private string code = "";
        public string MachineCode
        {
            get { return code; }
            set { code = value; OnPropertyChanged("MachineCode"); }
        }

        private bool isCodeChecked = false;
        public bool IsCodeChecked
        {
            get { return isCodeChecked; }
            set { isCodeChecked = value; OnPropertyChanged("IsCodeChecked"); }
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

        private bool isPasswordChecked = false;
        public bool IsPasswordChecked
        {
            get { return isPasswordChecked; }
            set { isPasswordChecked = value; OnPropertyChanged("IsPasswordChecked"); }
        }

        private ObservableCollection<string> grouplist = new ObservableCollection<string>();
        public ObservableCollection<string> GroupList
        {
            get { return grouplist; }
            set { grouplist = value; OnPropertyChanged("GroupList"); }
        }

        private ObservableCollection<UserState> stateList = new ObservableCollection<UserState>() { UserState.Active, UserState.Deactivated, UserState.Invalidated, UserState.PasswordExpired };
        public ObservableCollection<UserState> StateList
        {
            get { return stateList; }
            set { stateList = value; OnPropertyChanged("StateList"); }
        }

        private bool deacknever = true;
        public bool DeackNever
        {
            get { return deacknever; }
            set { deacknever = value; OnPropertyChanged("DeackNever"); }
        }

        private bool deackdate = false;
        public bool DeackDate
        {
            get { return deackdate; }
            set { deackdate = value; OnPropertyChanged("DeackDate"); }
        }

        private bool deacktime = false;
        public bool DeackTime
        {
            get { return deacktime; }
            set { deacktime = value; OnPropertyChanged("DeackTime"); }
        }

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        private string days = "0";
        public string Days
        {
            get { return days; }
            set { days = value; OnPropertyChanged("Days"); }
        }

        private string hours = "0";
        public string Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged("Hours"); }
        }

        private string minutes = "0";
        public string Minutes
        {
            get { return minutes; }
            set { minutes = value; OnPropertyChanged("Minutes"); }
        }

        private string selectedgroup = "";
        public string SelectedGroup
        {
            get { return selectedgroup; }
            set { selectedgroup = value; OnPropertyChanged("SelectedGroup"); }
        }

        private UserState selectedstate = UserState.Unknown;
        public UserState SelectedState
        {
            get { return selectedstate; }
            set { selectedstate = value; OnPropertyChanged("SelectedState"); }
        }

        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.UM_AddChangeUser v = (Views.UM_AddChangeUser)iRS.GetView("UM_AddChangeUser");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }
        public ICommand AU { get; set; }
        private void AUExecuted(object parameter)
        {
            if (isAdd)
            {
                if (!CheckUserDefinition(false))
                    return;

                IUserDefinition ud = userService.CreateUserDefinition();
                ud.Name = UserName;
                ud.FullName = UserFullName;
                ud.Comment = Comment;
                ud.GroupName = SelectedGroup;
                ud.InitialPassword = Password;
                ud.Code = MachineCode;
                ud.UserState = SelectedState;

                if (DeackNever)
                {
                    ud.DeactivationTime = DateTime.FromOADate(0);
                }
                else if (DeackDate)
                {
                    ud.DeactivationTime = Date;
                }
                else if (DeackTime)
                {
                    TimeSpan ts = new TimeSpan(Convert.ToInt32(Days), Convert.ToInt32(Hours), Convert.ToInt32(Minutes), 0);
                    ud.DeactivationTime = DateTime.FromOADate(ts.TotalDays);
                }

                AddUserSuccess success = userService.AddUser(ud);
                if (success != AddUserSuccess.Succeeded)
                {
                    new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "AddUserSuccess", success.ToString()), "@UserManagement.View.AddUser", MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    new MessageBoxTask("@UserManagement.Results.AddUserOK", "@UserManagement.View.AddUser", MessageBoxIcon.Information);
                }


            }
            else
            {
                if (!CheckUserDefinition(true))
                    return;

                IUserDefinition ud = userService.GetUserDefinition(UserName);
                ud.GroupName = SelectedGroup;
                ud.Comment = Comment;
                if (IsPasswordChecked)
                {
                    ud.InitialPassword = Password;
                }
                else
                {
                    ud.InitialPassword = null;
                }
                if (IsCodeChecked)
                    ud.Code = MachineCode;
                else
                    ud.Code = null;
                ud.UserState = SelectedState;

                if (DeackNever)
                {
                    ud.DeactivationTime = DateTime.FromOADate(0);
                }
                else if (DeackDate)
                {
                    ud.DeactivationTime = Date;
                }
                else if (DeackTime)
                {
                    TimeSpan ts = new TimeSpan(Convert.ToInt32(Days), Convert.ToInt32(Hours), Convert.ToInt32(Minutes), 0);
                    ud.DeactivationTime = DateTime.FromOADate(ts.TotalDays);
                }

                ChangeUserSuccess success = userService.ChangeUser(ud);
                if (success != ChangeUserSuccess.Succeeded)
                {
                    new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "ChangeUserSuccess", success.ToString()), "@UserManagement.View.ChangeUser", MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    new MessageBoxTask("@UserManagement.Results.ChangeUserOK", "@UserManagement.View.AddUser", MessageBoxIcon.Information);
                }
            }
            CloseExecuted(null);
            MainRegion.UM.Views.UM_Users v = (MainRegion.UM.Views.UM_Users)iRS.GetView("UM_Users");
            ((MainRegion.UM.Adapters.UM_Users)v.DataContext).RefreshUserNames();
        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            string user = ApplicationService.ObjectStore.GetValue("UM_AddChangeUser_KEY").ToString();
            ApplicationService.ObjectStore.Remove("UM_AddChangeUser_KEY");

            RefreshUserGroups();

            if (user == "")
            {
                isAdd = true;

                HLocalizableText = "@UserManagement.View.AddUser";
                BLocalizableText = "@Buttons.Text42";

                UserName = "";
                UserFullName = "";
                Comment = "";
                IsNameEnabled = true;
                IsCodeChecked = true;
                IsPasswordChecked = true;
                MachineCode = "";
                Password = "";
                Password2 = "";
                SelectedGroup = GroupList[0];
                SelectedState = StateList[0];
                DeackNever = true;

            }
            else
            {
                isAdd = false;

                HLocalizableText = "@UserManagement.View.ChangeUser";
                BLocalizableText = "@Buttons.Text8";

                IUser u = userService.GetUser(user);
                UserName = u.Name;
                UserFullName = u.FullName;
                Comment = u.Comment;
                IsNameEnabled = false;
                IsCodeChecked = false;
                IsPasswordChecked = false;
                MachineCode = u.Code;
                SelectedGroup = GroupList.Where(x => x == u.GroupName).First();
                SelectedState = StateList.Where(x => x == u.UserState).First();

                double deactivationTime = u.DeactivationTime.ToOADate();
                if (deactivationTime == 0)
                {
                    DeackNever = true;
                }
                else if (deactivationTime > 25000.0)
                {
                    Date = u.DeactivationTime;
                    DeackDate = true;
                }
                else
                {
                    TimeSpan ts = TimeSpan.FromDays(deactivationTime);
                    Days = ts.Days.ToString();
                    Hours = ts.Hours.ToString();
                    Minutes = ts.Minutes.ToString();
                    DeackTime = true;
                }



            }






            Views.UM_AddChangeUser v = (Views.UM_AddChangeUser)iRS.GetView("UM_AddChangeUser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void RefreshUserGroups()
        {
            GroupList.Clear();

            foreach (string group in userService.UserGroupNames)
            {
                GroupList.Add(group);
            }
        }

        bool CheckUserDefinition(bool changeUser)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                new MessageBoxTask("@UserManagement.Results.EnterUserName", HLocalizableText, MessageBoxIcon.Information);
                return false;
            }

            if (!changeUser && userService.UserNames.Any(rd => rd == UserName))
            {
                new MessageBoxTask("@UserManagement.Results.UserExistError", HLocalizableText, MessageBoxIcon.Exclamation);
                return false;
            }

            if (IsCodeChecked && !CheckCode(MachineCode))
            {
                new MessageBoxTask("@UserManagement.Results.CodeExistError", HLocalizableText, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(SelectedGroup))
            {
                new MessageBoxTask("@UserManagement.Results.EnterGroupName", HLocalizableText, MessageBoxIcon.Information);
                return false;
            }

            if (IsPasswordChecked)
            {
                if (string.IsNullOrEmpty(Password))
                {
                    new MessageBoxTask("@UserManagement.Results.EnterPassword", HLocalizableText, MessageBoxIcon.Information);
                    return false;
                }

                if (string.IsNullOrEmpty(Password2))
                {
                    new MessageBoxTask("@UserManagement.Results.EnterPassword", HLocalizableText, MessageBoxIcon.Information);
                    return false;
                }

                if (Password != Password2)
                {
                    new MessageBoxTask("@UserManagement.Results.EnterSamePassword", HLocalizableText, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (SelectedState == UserState.Unknown)
            {
                new MessageBoxTask("@UserManagement.Results.ChooseState", HLocalizableText, MessageBoxIcon.Information);
                return false;
            }

            if (DeackDate && string.IsNullOrEmpty(Date.ToString()))
            {
                new MessageBoxTask("@UserManagement.Results.EnterDate", HLocalizableText, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private bool CheckCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return true;

            foreach (string user in userService.UserNames)
            {
                IUserDefinition ud = userService.GetUserDefinition(user);
                if (ud.Code == code)
                    return false;
            }

            return true;
        }

        #endregion


    }
}