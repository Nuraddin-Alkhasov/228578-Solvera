using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.Diagnose.Adapters
{
    [ExportAdapter("Diagnose_Filter")]
    public class Diagnose_Filter : AdapterBase
    {

        public Diagnose_Filter()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Close = new ActionCommand(CloseExecuted);
            Filter = new ActionCommand(FilterExecuted);
        }

        #region - - - Properties - - -
        private IAlarmService alarmService;
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
                if (value != maxTime)
                {
                    maxTime = value;
                    OnPropertyChanged("MaxTime");
                }
            }
        }
        private DateTime minTime;
        public DateTime MinTime
        {
            get { return minTime; }
            set
            {
                if (value != minTime)
                {
                    minTime = value;
                    OnPropertyChanged("MinTime");
                }
            }
        }
        private bool customTimeSpanFilterEnabled = false;
        public bool CustomTimeSpanFilterEnabled
        {
            get
            {
                return customTimeSpanFilterEnabled;
            }
            set
            {
                customTimeSpanFilterEnabled = value;
                OnPropertyChanged("CustomTimeSpanFilterEnabled");
            }
        }

        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Diagnose_Filter v = (Views.Diagnose_Filter)iRS.GetView("Diagnose_Filter");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand Filter { get; set; }
        private void FilterExecuted(object parameter)
        {

            MainRegion.Diagnose.Views.Diagnose_Archive v = (MainRegion.Diagnose.Views.Diagnose_Archive)iRS.GetView("Diagnose_Archive");
            MainRegion.Diagnose.Adapters.Diagnose_Archive a = (MainRegion.Diagnose.Adapters.Diagnose_Archive)v.DataContext;
            a.RequestHistoricalAlarms(alarmService.GetHistoricalAlarmFilter(MinTime, MaxTime, desiredGroups: "Errors", desiredStates: AlarmState.Cleared));
            CloseExecuted(null);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            alarmService = GetService<IAlarmService>();

            TimeSpanFilterTypes.Clear();
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Today));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Yesterday));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.ThisWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.LastWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Custom));
            SelectedTimeSpanFilterType = TimeSpanFilterTypes[0];


            Views.Diagnose_Filter v = (Views.Diagnose_Filter)iRS.GetView("Diagnose_Filter");
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
        #endregion


    }
}