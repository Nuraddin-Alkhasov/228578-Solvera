using HMI.CO.General;
using HMI.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;

using VisiWin.DataAccess;

namespace HMI.Services
{
    [ExportService(typeof(ITimeSync))]
    [Export(typeof(ITimeSync))]
    public class Service_TimeSync : ServiceBase, ITimeSync
    {
        IVariableService VS;
        IVariable CPU1ToggleBit;
        IVariable CPU2ToggleBit;
        public Service_TimeSync()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region OnProject


        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
           

            base.OnLoadProjectStarted();
        }

       

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();

            CPU1ToggleBit = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
            CPU2ToggleBit = VS.GetVariable("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit");
            CPU1ToggleBit.Change += CPU1ToggleBit_Change;
            CPU2ToggleBit.Change += CPU2ToggleBit_Change;
            Time = new TimeSpan(9, 00, 00);
            Start();
            base.OnLoadProjectCompleted();
        }

        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            Stop();
            base.OnUnloadProjectCompleted();
        }

        private static Timer timer;

        public TimeSpan Time { get; set; }
        public bool IsRunning { get; set; }

        private void SetUpTimer(TimeSpan alertTime)
        {
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                timeToGo = new TimeSpan(24, 0, 0) - current.TimeOfDay + alertTime;
            }
            timer = new Timer(x => 
            {
                Start();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
           
        }

        public void Start()
        {
            SetUpTimer(Time);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.DateTime.from.Actual#DATE_AND_TIME", DateTime.Now.ToString());
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.DateTime.from.Update", true);
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.DateTime.from.Actual#DATE_AND_TIME", DateTime.Now.ToString());
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.DateTime.from.Update", true);
            IsRunning = true;
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }

            IsRunning = false;
        }
        void CPU1ToggleBit_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {

                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit", false);


            }

        }

        void CPU2ToggleBit_Change(object sender, VariableEventArgs e)
        {
            if ((bool)e.Value)
            {

                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.ToggleBit", false);


            }

        }
        #endregion

    }
}
