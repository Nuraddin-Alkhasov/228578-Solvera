using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Maintenance.Adapters
{
    [ExportAdapter("Maintenance_Current")]
    public class Maintenance_Current : AdapterBase
    {



        public Maintenance_Current()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
        }
        #region - - - Properties - - -
        private ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();

        private List<IAlarmItem> alarms = new List<IAlarmItem>();
        public List<IAlarmItem> Alarms
        {
            get { return alarms; }
            set
            {
                alarms = value;
                OnPropertyChanged("Alarms");

            }
        }

        #endregion

        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                CurrentAlarmList.ChangeAlarm += SetAlarmData;
                CurrentAlarmList.NewAlarm += SetAlarmData;
                CurrentAlarmList.ClearAlarm += SetAlarmData;
                SetAlarmData(null, null);
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


        #endregion
        #region - - - Methods - - - 
        private void SetAlarmData(object sender, AlarmEventArgs e)
        {
            Alarms = CurrentAlarmList.Alarms.Where(
                                            x => (x.Group.Name == "PM") && x.AlarmState == AlarmState.Active).ToList()
                                            .OrderByDescending(x => x.ActivationTime).ToList();
        }

        #endregion

    }
}