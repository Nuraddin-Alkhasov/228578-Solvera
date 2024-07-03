using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Maintenance.Adapters
{
    [ExportAdapter("Maintenance_OH")]
    public class Maintenance_OH : AdapterBase
    {



        public Maintenance_OH()
        {

            if (ApplicationService.IsInDesignMode)
                return;

            M1 = new ActionCommand(M1Executed);
            M2 = new ActionCommand(M2Executed);
            M3 = new ActionCommand(M3Executed);
            M4 = new ActionCommand(M4Executed);
        }

        #region Commands
        public ICommand M1 { get; set; }

        private void M1Executed(object parameter)
        {
        }
        public ICommand M2 { get; set; }

        private void M2Executed(object parameter)
        {
        }
        public ICommand M3 { get; set; }

        private void M3Executed(object parameter)
        {
        }
        public ICommand M4 { get; set; }

        private void M4Executed(object parameter)
        {
        }
        #endregion

    }
}