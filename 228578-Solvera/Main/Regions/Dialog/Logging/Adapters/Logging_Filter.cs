using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.Logging.Adapters
{
    [ExportAdapter("Logging_Filter")]
    public class Logging_Filter : AdapterBase
    {

        public Logging_Filter()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            loggingService = GetService<ILoggingService>();

            Close = new ActionCommand(CloseExecuted);
            Filter = new ActionCommand(FilterExecuted);
        }

        #region - - - Properties - - -
        private ILoggingService loggingService;
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public ObservableCollection<HistoricalTimeSpanFilterItem> TimeSpanFilterTypes { get; } = new ObservableCollection<HistoricalTimeSpanFilterItem>();

        private HistoricalTimeSpanFilterItem selectedTimeSpanFilterType = new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Today);
        public HistoricalTimeSpanFilterItem SelectedTimeSpanFilterType
        {
            get { return selectedTimeSpanFilterType; } 
            set
            {
                if (value != null)
                {
                    CustomTimeSpanFilterEnabled = value.FilterType == HistoricalTimeSpanFilterType.Custom;
                    SetTimeSpan(value.FilterType);
                }
                selectedTimeSpanFilterType = value;
                OnPropertyChanged("SelectedTimeSpanFilterType");
            }
        }

        private DateTime maxTime;
        public DateTime MaxTime
        {
            get { return maxTime; }
            set
            {

                maxTime = value;
                OnPropertyChanged("MaxTime");

            }
        }
        private DateTime minTime;
        public DateTime MinTime
        {
            get { return minTime; }
            set
            {
                minTime = value;
                OnPropertyChanged("MinTime");

            }
        }
        private bool customTimeSpanFilterEnabled = false;
        public bool CustomTimeSpanFilterEnabled
        {
            get { return customTimeSpanFilterEnabled; }
            set
            {
                customTimeSpanFilterEnabled = value;
                OnPropertyChanged("CustomTimeSpanFilterEnabled");
            }
        }

        private bool isAllUsersSelected = true;
        public bool IsAllUsersSelected
        {
            get { return isAllUsersSelected; }
            set
            {
                isAllUsersSelected = value;
                OnPropertyChanged("IsAllUsersSelected");

                IsUserSelectionEnabled = !isAllUsersSelected;

            }
        }
        private bool isUserSelectionEnabled = false;
        public bool IsUserSelectionEnabled
        {
            get { return isUserSelectionEnabled; }
            set
            {
                isUserSelectionEnabled = value;
                OnPropertyChanged("IsUserSelectionEnabled");
            }
        }

        private ObservableCollection<UserFilterItem> desiredUsers = new ObservableCollection<UserFilterItem>();
        public ObservableCollection<UserFilterItem> DesiredUsers
        {
            get { return desiredUsers; }
            set
            {

                desiredUsers = value;
                OnPropertyChanged("DesiredUsers");

            }
        }

        private bool isSelected = true;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");

            }
        }

        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Logging_Filter v = (Views.Logging_Filter)iRS.GetView("Logging_Filter");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand Filter { get; set; }
        private void FilterExecuted(object parameter)
        {
            IHistoricalLoggingFilter LoggingFilter = loggingService.CreateHistoricalLoggingFilter();
            LoggingFilter.MinTime = MinTime;
            LoggingFilter.MaxTime = MaxTime;

            MainRegion.Logging.Views.Logging v = (MainRegion.Logging.Views.Logging)iRS.GetView("Logging");
            MainRegion.Logging.Adapters.Logging a = (MainRegion.Logging.Adapters.Logging)v.DataContext;

            if (!isAllUsersSelected)
            {
                foreach (UserFilterItem user in DesiredUsers)
                {
                    if (user.IsSelected)
                    {
                        LoggingFilter.Users.Add(user.FullName);
                    }
                }

                if (LoggingFilter.Users.Count == 0)
                {
                    new MessageBoxTask("@Logging.LoggingFilterView.NoUserFilterError", "@Logging.LoggingFilterView.Caption", MessageBoxIcon.Exclamation);
                    return;
                }
                a.RequestLoggingEntries(LoggingFilter);
            }
            else
            {
                a.RequestLoggingEntries(LoggingFilter);
            }


            CloseExecuted(null);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RefreshUsers();

            TimeSpanFilterTypes.Clear();
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Today));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Yesterday));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.ThisWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.LastWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Custom));
            SelectedTimeSpanFilterType = TimeSpanFilterTypes[0];
            IsAllUsersSelected = true;
            IsSelected = true;
            Views.Logging_Filter v = (Views.Logging_Filter)iRS.GetView("Logging_Filter");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -
        public void SetTimeSpan(HistoricalTimeSpanFilterType selectedTimeSpanFilterType)
        {
            switch (selectedTimeSpanFilterType)
            {
                case HistoricalTimeSpanFilterType.Custom:
                    break;
                case HistoricalTimeSpanFilterType.Today:
                    MinTime = DateTime.Now.Date;
                    MaxTime = MinTime.Add(TimeSpan.FromDays(1));
                    break;
                case HistoricalTimeSpanFilterType.Yesterday:
                    MinTime = DateTime.Now.Date.Add(TimeSpan.FromDays(-1.0));
                    MaxTime = MinTime.Add(TimeSpan.FromDays(1));
                    break;
                case HistoricalTimeSpanFilterType.ThisWeek:
                    MinTime = DateTime.Now.Date.Add(TimeSpan.FromDays(-(double)DateTime.Now.Date.DayOfWeek));
                    MaxTime = MinTime.Add(TimeSpan.FromDays(7));
                    break;
                case HistoricalTimeSpanFilterType.LastWeek:
                    MinTime = DateTime.Now.Date.Add(TimeSpan.FromDays(-(double)DateTime.Now.Date.DayOfWeek - 7));
                    MaxTime = MinTime.Add(TimeSpan.FromDays(7));
                    break;
                default:
                    break;
            }
        }

        private void RefreshUsers()
        {
            desiredUsers.Clear();

            IUserManagementService uMS = ApplicationService.GetService<IUserManagementService>();
            if (uMS != null)
            {
                foreach (string user in uMS.UserNames)
                {
                    IUserDefinition uD = uMS.GetUserDefinition(user);
                    if (uD != null)
                    {
                        desiredUsers.Add(new UserFilterItem(user, uD.FullName));
                    }
                }
            }
        }

        #endregion


    }
}