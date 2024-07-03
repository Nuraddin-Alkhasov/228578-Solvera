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
    [ExportAdapter("UM_Groups")]
    public class UM_Groups : AdapterBase
    {



        public UM_Groups()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Open = new ActionCommand(OpenExecuted);
            Close = new ActionCommand(CloseExecuted);

            Add = new ActionCommand(AddExecuted);
            Change = new ActionCommand(ChangeExecuted);
            Remove = new ActionCommand(RemoveExecuted);
        }

        #region - - - Properties - - - 

        private readonly IUserManagementService userService = ApplicationService.GetService<IUserManagementService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        private ObservableCollection<GroupData> grouplist = new ObservableCollection<GroupData>();
        public ObservableCollection<GroupData> GroupList
        {
            get { return grouplist; }
            set { grouplist = value; OnPropertyChanged("GroupList"); }
        }

        private GroupData selectedgroup = null;
        public GroupData SelectedGroup
        {
            get { return selectedgroup; }
            set
            {
                IsSelected = value != null;
                selectedgroup = value;
                OnPropertyChanged("SelectedGroup");
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

        #region Commands

        public ICommand Add { get; set; }

        private void AddExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_AddChangeGroup", "");
        }
        public ICommand Change { get; set; }

        private void ChangeExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "UM_AddChangeGroup", SelectedGroup.Name);
        }
        public ICommand Remove { get; set; }

        private void RemoveExecuted(object parameter)
        {
            if (SelectedGroup == null)
            {
                new MessageBoxTask("@UserManagement.Results.ChooseGroup", "@UserManagement.View.DeleteGroup", MessageBoxIcon.Information);
                return;
            }

            if (MessageBoxView.Show("@UserManagement.Results.DeleteGroupQuery", "@UserManagement.View.DeleteGroup", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) != MessageBoxResult.Yes)
            {
                return;
            }

            ChangeGroupSuccess success = userService.RemoveUserGroup(SelectedGroup.Name);
            if (success == ChangeGroupSuccess.Succeeded)
            {
                GroupList.Remove(SelectedGroup);
                new MessageBoxTask("@UserManagement.Results.DeleteGroupOK", "@UserManagement.View.DeleteGroup", MessageBoxIcon.Information);
            }
            else
            {
                new MessageBoxTask("@UserManagement.Results.DeleteGroupError", "@UserManagement.View.DeleteGroup", MessageBoxIcon.Information);
            }

        }


        public ICommand Open { get; set; }
        public void OpenExecuted(object parameter)
        {
            Views.UM_Groups v = (Views.UM_Groups)iRS.GetView("UM_Groups");
            new ObjectAnimator().OpenMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }
        public ICommand Close { get; set; }
        public void CloseExecuted(object parameter)
        {

            Views.UM_Groups v = (Views.UM_Groups)iRS.GetView("UM_Groups");
            new ObjectAnimator().CloseMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }

        #endregion


        #region - - - Methods - - -

        public void RefreshGroups()
        {
            GroupList.Clear();

            foreach (string groupName in userService.UserGroupNames)
            {
                IUserGroupDefinition iugd = userService.GetUserGroupDefinition(groupName);
                GroupList.Add(new GroupData(iugd.Name, iugd.LocalizableText, iugd.Comment));
            }
        }

        #endregion

        #region - - - Event Handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                SelectedGroup = null;
                RefreshGroups();
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