using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.UM.Adapters
{
    [ExportAdapter("UM_AddChangeGroup")]
    public class UM_AddChangeGroup : AdapterBase
    {



        public UM_AddChangeGroup()
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

        private ObservableCollection<UserRightDataClass> rightlist = new ObservableCollection<UserRightDataClass>();
        public ObservableCollection<UserRightDataClass> RightList
        {
            get { return rightlist; }
            set { rightlist = value; OnPropertyChanged("RightList"); }
        }

        private string groupname = "";
        public string GroupName
        {
            get { return groupname; }
            set { groupname = value; OnPropertyChanged("GroupName"); }
        }

        private bool isNameEnabled = false;
        public bool IsNameEnabled
        {
            get { return isNameEnabled; }
            set { isNameEnabled = value; OnPropertyChanged("IsNameEnabled"); }
        }

        private bool removable = false;
        public bool UserRemovable
        {
            get { return removable; }
            set { removable = value; OnPropertyChanged("UserRemovable"); }
        }

        private int timelogoff = 0;
        public int TimeToLogOff
        {
            get { return timelogoff; }
            set { timelogoff = value; OnPropertyChanged("TimeToLogOff"); }
        }

        private int daystonewpassword = 0;
        public int DaysToNewPassword
        {
            get { return daystonewpassword; }
            set { daystonewpassword = value; OnPropertyChanged("DaysToNewPassword"); }
        }

        private int maxlogins = 0;
        public int MaxLogIns
        {
            get { return maxlogins; }
            set { maxlogins = value; OnPropertyChanged("MaxLogIns"); }
        }

        private string comment = "";
        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChanged("Comment"); }
        }

        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.UM_AddChangeGroup v = (Views.UM_AddChangeGroup)iRS.GetView("UM_AddChangeGroup");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }
        public ICommand AU { get; set; }
        private void AUExecuted(object parameter)
        {
            if (isAdd)
            {
                if (!CheckGroupDefinition(false))
                {
                    return;
                }

                IUserGroupDefinition ugd = userService.CreateUserGroupDefinition();

                ugd.UsersRemovable = UserRemovable;
                ugd.Name = GroupName;
                ugd.Comment = Comment;
                ugd.AutoLogOffTime = TimeToLogOff;
                ugd.MaxFailedLogOns = MaxLogIns;
                ugd.RenewPasswordInterval = DaysToNewPassword;
                ugd.RightNames.Clear();
                foreach (UserRightDataClass rc in RightList)
                {
                    if (rc.On)
                    {
                        ugd.RightNames.Add(rc.DisplayName);
                    }
                }

                AddGroupSuccess success = userService.AddUserGroup(ugd);
                if (success != AddGroupSuccess.Succeeded)
                {
                    new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "AddGroupSuccess", success.ToString()), "@UserManagement.View.AddGroup", MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    new MessageBoxTask("@UserManagement.Results.AddGroupOK", "@UserManagement.View.AddGroup", MessageBoxIcon.Information);

                }
            }
            else
            {
                IUserGroupDefinition ugd = userService.GetUserGroupDefinition(GroupName);

                ugd.UsersRemovable = UserRemovable;
                ugd.Name = GroupName;
                ugd.Comment = Comment;
                ugd.AutoLogOffTime = TimeToLogOff;
                ugd.MaxFailedLogOns = MaxLogIns;
                ugd.RenewPasswordInterval = DaysToNewPassword;
                ugd.RightNames.Clear();
                foreach (UserRightDataClass rc in RightList)
                {
                    if (rc.On)
                        ugd.RightNames.Add(rc.Right);
                }

                ChangeGroupSuccess success = userService.ChangeUserGroup(ugd);
                if (success != ChangeGroupSuccess.Succeeded)
                {
                    new MessageBoxTask(string.Format("@UserManagement.Results.{0}.{1}", "ChangeGroupSuccess", success.ToString()), "@UserManagement.View.AddGroup", MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    new MessageBoxTask("@UserManagement.Results.ChangeGroupOK", "@UserManagement.View.AddGroup", MessageBoxIcon.Information);

                }

            }
            CloseExecuted(null);
            MainRegion.UM.Views.UM_Groups v = (MainRegion.UM.Views.UM_Groups)iRS.GetView("UM_Groups");
            ((MainRegion.UM.Adapters.UM_Groups)v.DataContext).RefreshGroups();
        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            string group = ApplicationService.ObjectStore.GetValue("UM_AddChangeGroup_KEY").ToString();
            ApplicationService.ObjectStore.Remove("UM_AddChangeGroup_KEY");
            if (group == "")
            {
                isAdd = true;

                HLocalizableText = "@UserManagement.View.AddGroup";
                BLocalizableText = "@Buttons.Text42";

                GroupName = "";
                Comment = "";
                IsNameEnabled = true;
                UserRemovable = true;
                TimeToLogOff = 0;
                DaysToNewPassword = 0;
                MaxLogIns = 0;

                RightList.Clear();

                foreach (string right in userService.RightNames)
                {
                    RightList.Add(new UserRightDataClass(false, right, userService.GetRight(right).Text));
                }
            }
            else
            {
                isAdd = false;

                HLocalizableText = "@UserManagement.View.ChangeGroup";
                BLocalizableText = "@Buttons.Text8";

                IUserGroupDefinition g = userService.GetUserGroupDefinition(group);
                GroupName = g.Name;
                Comment = g.Comment;
                IsNameEnabled = false;
                UserRemovable = g.UsersRemovable;
                TimeToLogOff = g.AutoLogOffTime;
                DaysToNewPassword = g.RenewPasswordInterval;
                MaxLogIns = g.MaxFailedLogOns;

                RightList.Clear();

                foreach (string right in userService.RightNames)
                {
                    RightList.Add(new UserRightDataClass(g.RightNames.Contains(right), right, userService.GetRight(right).Text));
                }

            }

            Views.UM_AddChangeGroup v = (Views.UM_AddChangeGroup)iRS.GetView("UM_AddChangeGroup");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private bool CheckGroupDefinition(bool changeGroup)
        {
            string header = (changeGroup) ? "@UserManagement.View.ChangeGroup" : "@UserManagement.View.AddGroup";

            if (string.IsNullOrEmpty(GroupName))
            {
                new MessageBoxTask("@UserManagement.Results.EnterGroupName", header, MessageBoxIcon.Information);
                return false;
            }

            if (!changeGroup && userService.UserGroupNames.Any(rd => rd == GroupName))
            {
                new MessageBoxTask("@UserManagement.Results.GroupExistError", header, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        #endregion


    }
}