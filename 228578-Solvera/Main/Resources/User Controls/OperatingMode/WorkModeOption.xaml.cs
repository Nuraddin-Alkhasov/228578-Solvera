using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.Resources.UserControls.MO
{
    public partial class WorkModeOption : UserControl
    {

        public WorkModeOption()
        {
            InitializeComponent();
            TS.LanguageChanged += TS_LanguageChanged;
        }
        #region - - - Properties - - -
        
        IVariableService VS = ApplicationService.GetService<IVariableService>();
        ILanguageService TS = ApplicationService.GetService<ILanguageService>();
        string header { set; get; } = "";
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                H.Header = TS.GetText(value);
            }
        }
        IVariable IVStart;
        public string Start
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVStart = VS.GetVariable(value);
                }
            }
        }
        IVariable IVStop;
        public string Stop
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVStop = VS.GetVariable(value);
                }
            }
        }
        IVariable SS;
        public string StartStatus
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    SS = VS.GetVariable(value);
                    SS.Change += SS_Change;
                }
            }
        }

        public string AuthorizationRight
        {
             get { return ""; } 
            set
            {
                btnstart.AuthorizationRight = value;
                btnstop.AuthorizationRight = value;
            }
        }

        IVariable IVRelease;
        public string IsRelease
        {
             get { return ""; } 
            set
            {
                IVRelease = VS.GetVariable(value);
                IVRelease.Change += IsRelease_Change;
            }
        }

        #endregion

        #region - - - Event Handlers - - -
        private void TS_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            H.Header = TS.GetText(Header);
        }

        private void SS_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                switch ((short)e.Value)
                {
                    case 0: btnstart.IsDefault = false; btnstart.IsBlinkEnabled = false; break;
                    case 1: btnstart.IsDefault = true; btnstart.IsBlinkEnabled = false; break;
                    case 2: btnstart.IsDefault = false; btnstart.IsBlinkEnabled = true; break;
                }
            }
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            
            if (MessageBoxView.Show("@MachineOverview.Text53", Header, MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                SetValue(IVStart);
            }           
        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBoxView.Show("@MachineOverview.Text53", Header, MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                SetValue(IVStop);
            }
        }

        private void IsRelease_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    btnstart.IsEnabled = true;
                }
                else
                {
                    btnstart.IsEnabled = false;
                }
            }
        }
        #endregion









        #region - - - Methods - - -

        private void SetValue(IVariable v) 
        {
            Task taskA = Task.Run(() =>
            {
                v.Value = true;
            });
            taskA.ContinueWith(async x =>
            {
                await Task.Delay(1000);
                v.Value = false;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        #endregion
    }
}
