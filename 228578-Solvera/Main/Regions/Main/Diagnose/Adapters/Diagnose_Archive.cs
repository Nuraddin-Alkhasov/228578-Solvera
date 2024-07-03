using HMI.CO.General;
using HMI.MainRegion.Diagnose.Views;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Diagnose.Adapters
{
    [ExportAdapter("Diagnose_Archive")]
    public class Diagnose_Archive : AdapterBase
    {



        public Diagnose_Archive()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            alarmService = GetService<IAlarmService>();
            OpenFilter = new ActionCommand(OpenFilterExecuted);
        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private IAlarmService alarmService;
        private IHistoricalAlarmRequest alarmRequest;
        private List<IHistoricalAlarmItem> historicalAlarms = new List<IHistoricalAlarmItem>();
        public List<IHistoricalAlarmItem> HistoricalAlarms
        {
            get { return historicalAlarms; }
            set
            {
                if (historicalAlarms != value)
                {
                    historicalAlarms = value;
                    OnPropertyChanged("HistoricalAlarms");
                }
            }
        }


        #endregion

        #region - - - Commands - - - 
        public ICommand OpenFilter { get; set; }

        private void OpenFilterExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Diagnose_Filter");
        }
        #endregion

        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }
            base.OnViewLoaded(sender, e);
        }

        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }
            base.OnViewUnloaded(sender, e);
        }
        private void GetHistoricalDataCompleted(object sender, GetHistoricalAlarmsCompletedEventArgs e)
        {
            HistoricalAlarms = e.HistoricalAlarms.OrderByDescending(x => x.ActivationTime).ToList();
            Diagnose_PN D_PN = (Diagnose_PN)iRS.GetView("Diagnose_PN");
            D_PN.wait.Visibility = System.Windows.Visibility.Hidden;
            alarmRequest.GetHistoricalDataCompleted -= new EventHandler<GetHistoricalAlarmsCompletedEventArgs>(GetHistoricalDataCompleted);

        }

        #endregion

        #region - - - Methods - - - 
        public void RequestHistoricalAlarms(IHistoricalAlarmFilter f)
        {
            alarmRequest = alarmService.CreateHistoricalAlarmRequest(f);
            alarmRequest.GetHistoricalDataCompleted += new EventHandler<GetHistoricalAlarmsCompletedEventArgs>(GetHistoricalDataCompleted);

            if (alarmRequest.GetHistoricalData())
            {
                Diagnose_PN D_PN = (Diagnose_PN)iRS.GetView("Diagnose_PN");
                D_PN.wait.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                new MessageBoxTask("@HistoricalAlarms.HistoricalAlarmFilterView.GetAlarmsError", "@HistoricalAlarms.HistoricalAlarmFilterView.Caption", MessageBoxIcon.Exclamation);
            }
        }

        public void LoadData()
        {
            RequestHistoricalAlarms(alarmService.GetHistoricalAlarmFilter(DateTime.Now.AddHours(-24), DateTime.Now, desiredGroups: "Errors", desiredStates: AlarmState.Cleared));
        }

        #endregion
    }

}
