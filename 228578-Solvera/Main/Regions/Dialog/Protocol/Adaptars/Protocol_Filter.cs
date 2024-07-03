using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;
using VisiWin.UserManagement;

namespace HMI.DialogRegion.Protocol.Adapters
{
    [ExportAdapter("Protocol_Filter")]
    public class Protocol_Filter : AdapterBase
    {

        public Protocol_Filter()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Close = new ActionCommand(CloseExecuted);
            Filter = new ActionCommand(FilterExecuted);
        }

        #region - - - Properties - - -
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

        private string data_1;
        public string Data_1
        {
            get { return data_1; }
            set
            {
                data_1 = value;
                OnPropertyChanged("Data_1");

            }
        }

        private string data_2;
        public string Data_2
        {
            get { return data_2; }
            set
            {
                data_2 = value;
                OnPropertyChanged("Data_2");

            }
        }
        private string data_3;
        public string Data_3
        {
            get { return data_3; }
            set
            {
                data_3 = value;
                OnPropertyChanged("Data_3");

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

            Views.Protocol_Filter v = (Views.Protocol_Filter)iRS.GetView("Protocol_Filter");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand Filter { get; set; }
        private void FilterExecuted(object parameter)
        {
            string T = "Select * From Orders ";
            string F = "";
            List<string> FL = new List<string>();

            if (minTime != null && maxTime != null)
            {
                string Minmonth = minTime.Month.ToString().Length == 1 ? "0" + minTime.Month.ToString() : minTime.Month.ToString();

                string Minday = minTime.Day.ToString().Length == 1 ? "0" + minTime.Day.ToString() : minTime.Day.ToString();

                string Maxmonth = maxTime.Month.ToString().Length == 1 ? "0" + maxTime.Month.ToString() : maxTime.Month.ToString();

                string Maxday = maxTime.Day.ToString().Length == 1 ? "0" + maxTime.Day.ToString() : maxTime.Day.ToString();
                FL.Add("Start >= '" + minTime.Year  + Minmonth  + Minday + "' AND Start <= '" + MaxTime.Year + Maxmonth  + Maxday + "'");

            }

            if (data_1 != "" && data_1 != null)
            {
                FL.Add("Data_1 like '%" + data_1 + "%'");
            }

            if (data_2 != "" && data_2 != null)
            {
                FL.Add("Data_2 like '%" + data_2 + "%'");
            }

            if (data_3 != "" && data_3 != null)
            {
                FL.Add("Data_3 like '%" + data_3 + "%'");
            }


            if (FL.Count > 0)
            {
                F += " WHERE ";
                for (int i = 0; i < FL.Count; i++)
                {
                    if (i == 0)
                    {
                        F += FL[i];
                    }
                    else
                    {
                        F = F + " AND " + FL[i];
                    }
                }
            }

            MainRegion.Protocol.Views.Protocol_Orders v = (MainRegion.Protocol.Views.Protocol_Orders)iRS.GetView("Protocol_Orders");
            MainRegion.Protocol.Adapters.Protocol a = (MainRegion.Protocol.Adapters.Protocol)v.DataContext;
            a.LoadOrderList(T + F + ";");

            CloseExecuted(null);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {


            TimeSpanFilterTypes.Clear();
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Today));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Yesterday));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.ThisWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.LastWeek));
            TimeSpanFilterTypes.Add(new HistoricalTimeSpanFilterItem(HistoricalTimeSpanFilterType.Custom));
            SelectedTimeSpanFilterType = TimeSpanFilterTypes[0];
            IsSelected = true;
            Views.Protocol_Filter v = (Views.Protocol_Filter)iRS.GetView("Protocol_Filter");
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