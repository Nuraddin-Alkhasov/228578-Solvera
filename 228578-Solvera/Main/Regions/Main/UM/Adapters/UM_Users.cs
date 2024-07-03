using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;
using VisiWin.UserManagement;

namespace HMI.MainRegion.UM.Adapters
{
    [ExportAdapter("UM_Users")]
    public class UM_Users : AdapterBase
    {



        public UM_Users()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Open = new ActionCommand(OpenExecuted);
            Close = new ActionCommand(CloseExecuted);

            Add = new ActionCommand(AddExecuted);
            Change = new ActionCommand(ChangeExecuted);
            ChangePW = new ActionCommand(ChangePWExecuted);
            Remove = new ActionCommand(RemoveExecuted);
        }

        #region - - - Properties - - - 

        private readonly IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        private ObservableCollection<UserData> userlist = new ObservableCollection<UserData>();
        public ObservableCollection<UserData> UserList
        {
            get { return userlist; }
            set { userlist = value; OnPropertyChanged("UserList"); }
        }

        private UserData selectedUser = null;
        public UserData SelectedUser
        {
            get { return selectedUser; }
            set
            {
                IsSelected = value != null;

                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value) { OpenExecuted(null); }
                else { CloseExecuted(null); }

                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Open { get; set; }
        public void OpenExecuted(object parameter)
        {

            Views.UM_Users v = (Views.UM_Users)iRS.GetView("UM_Users");
            new ObjectAnimator().OpenMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }
        public ICommand Close { get; set; }
        public void CloseExecuted(object parameter)
        {

            Views.UM_Users v = (Views.UM_Users)iRS.GetView("UM_Users");
            new ObjectAnimator().CloseMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }

        public ICommand Add { get; set; }

        private void AddExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_AddChangeUser", "");
        }
        public ICommand Change { get; set; }

        private void ChangeExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_AddChangeUser", SelectedUser.Name);
        }
        public ICommand ChangePW { get; set; }

        private void ChangePWExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_ChangePassword", SelectedUser.Name);
        }
        public ICommand Remove { get; set; }

        private void RemoveExecuted(object parameter)
        {
            IUserDefinition ud = userService.GetUserDefinition(SelectedUser.Name);
            IUserGroupDefinition ugd = userService.GetUserGroupDefinition(ud.GroupName);
            if (!ugd.UsersRemovable)
            {
                new MessageBoxTask("@UserManagement.Results.DeleteUserProhibited", "@UserManagement.View.DeleteUser", MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBoxView.Show("@UserManagement.Results.DeleteUserQuery", "@UserManagement.View.DeleteUser", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                if (userService.RemoveUser(SelectedUser.Name))
                {
                    UserList.Remove(SelectedUser);
                    new MessageBoxTask("@UserManagement.Results.DeleteUserOK", "@UserManagement.View.DeleteUser", MessageBoxIcon.Information);

                }
                else
                {
                    new MessageBoxTask("@UserManagement.Results.DeleteUserError", "@UserManagement.View.DeleteUser", MessageBoxIcon.Information);

                }
            }


        }

        #endregion

        #region - - - Methods - - -

        public void RefreshUserNames()
        {
            UserList.Clear();

            foreach (string userName in userService.UserNames)
            {
                IUserDefinition iud = userService.GetUserDefinition(userName);
                UserList.Add(new UserData(iud.Name, iud.FullName, iud.UserState, iud.GroupName, iud.Comment, ""));
            }
        }

        #endregion

        #region - - - Event Handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                SelectedUser = null;
                RefreshUserNames();
            }
            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }
        #endregion




    }
}