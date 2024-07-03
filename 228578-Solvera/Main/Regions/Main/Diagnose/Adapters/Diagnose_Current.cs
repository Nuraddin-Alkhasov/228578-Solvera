using HMI.CO.General;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Diagnose.Adapters
{
    [ExportAdapter("Diagnose_Current")]

    public class Diagnose_Current : AdapterBase
    {


        public Diagnose_Current()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Open = new ActionCommand(OpenExecuted);
            Close = new ActionCommand(CloseExecuted);

            Ack = new ActionCommand(AckExecuted);
            HornOff = new ActionCommand(HornOffExecuted);
        }
        #region - - - Properties - - - 

        private ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

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
        private IAlarmItem alarm = null;
        public IAlarmItem Alarm
        {
            get { return alarm; }
            set
            {
                if (value != null) { OpenExecuted(null); }
                else { CloseExecuted(null); }

                alarm = value;
                OnPropertyChanged("Alarm");

            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Open { get; set; }
        public void OpenExecuted(object parameter)
        {
            Views.Diagnose_Current v = (Views.Diagnose_Current)iRS.GetView("Diagnose_Current");
            new ObjectAnimator().OpenMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }
        public ICommand Close { get; set; }
        public void CloseExecuted(object parameter)
        {
            Views.Diagnose_Current v = (Views.Diagnose_Current)iRS.GetView("Diagnose_Current");
            new ObjectAnimator().CloseMenu(v.SubMenu, v.ButtonCloseMenu, v.ButtonOpenMenu);
        }
        public ICommand Ack { get; set; }

        private void AckExecuted(object parameter)
        {
            Task taskA = Task.Run(() =>
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Acknowledge", true);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Acknowledge", true);
            });
            taskA.ContinueWith(async x =>
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Acknowledge", false);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Acknowledge", false);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
        public ICommand HornOff { get; set; }

        private void HornOffExecuted(object parameter)
        {
            Task taskA = Task.Run(() =>
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Horn off", true);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Horn off", true);
            });
            taskA.ContinueWith(async x =>
            {
                await Task.Delay(1000);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Horn off", false);
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Faults.Horn off", false);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
        #endregion

        #region - - - Event Handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                Alarm = null;
                Alarms = CurrentAlarmList.Alarms.Where(
                        x => (x.Group.Name == "Errors" || x.Group.Name == "Warnings") && x.AlarmState == AlarmState.Active).ToList()
                        .OrderByDescending(x => x.ActivationTime).ToList();

                CurrentAlarmList.ChangeAlarm += SetAlarmData;
                CurrentAlarmList.NewAlarm += SetAlarmData;
                CurrentAlarmList.ClearAlarm += SetAlarmData;
            }

            base.OnViewLoaded(sender, e);
        }

        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                CurrentAlarmList.ChangeAlarm -= SetAlarmData;
                CurrentAlarmList.NewAlarm -= SetAlarmData;
                CurrentAlarmList.ClearAlarm -= SetAlarmData;
            }
            base.OnViewUnloaded(sender, e);
        }

        #endregion

        private void SetAlarmData(object sender, AlarmEventArgs e)
        {
            Alarms = CurrentAlarmList.Alarms.Where(x => (x.Group.Name == "Errors" || x.Group.Name == "Warnings") && x.AlarmState == AlarmState.Active).ToList();
        }
    }

}
