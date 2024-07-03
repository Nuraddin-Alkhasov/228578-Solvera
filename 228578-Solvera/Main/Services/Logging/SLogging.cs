using HMI.Interfaces.Logging;
using HMI.Services.Custom_Objects;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Logging;

namespace HMI.Services.Logging
{
    [ExportService(typeof(ILogging))]
    [Export(typeof(ILogging))]
    public class SLogging : ServiceBase, ILogging
    {

        public SLogging()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
        }

        IVariableService VS;
       // IVariable Referenced;

        #region OnProject

        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();

            //Referenced = VS.GetVariable("xxxx");
            //Referenced.Change += Referenced_Change;
            base.OnLoadProjectCompleted();
        }

        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        void Referenced_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue && bool.Parse(e.Value.ToString()))
            {
      //          Referenced.Value = false;
                ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();

                if ((bool)ApplicationService.GetVariableValue(""))
                {
                    loggingService.Log("Machine", "Reference", "", System.DateTime.Now);
                }

            }

        }

        #endregion

    }
}
