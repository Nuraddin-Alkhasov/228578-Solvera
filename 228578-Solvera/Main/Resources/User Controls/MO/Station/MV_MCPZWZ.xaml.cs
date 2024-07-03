using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_MCPZWZ : UserControl
    {
        public MV_MCPZWZ()
        {
            InitializeComponent();
            PZTemp = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Temperature";
            PZRpm = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Circulation fan.Motor.Actual.Speed 2";
            PZCaster = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Caster";
            PZPurge = "CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Exhaust fan.State.isPurging";
            WZTemp = "CPU2.PLC.Blocks.04 Tray handling.03 WZ.01 Air.DB WZ Air HMI.Actual.Temperature";
            WZRpm = "CPU2.PLC.Blocks.04 Tray handling.03 WZ.01 Air.DB WZ Air HMI.Actual.Circulation fan.Motor.Actual.Speed 2";
            WZCaster = "CPU2.PLC.Blocks.04 Tray handling.03 WZ.01 Air.DB WZ Air HMI.Actual.Caster";
            WZPurge = "CPU2.PLC.Blocks.04 Tray handling.03 WZ.01 Air.DB WZ Air HMI.Actual.Exhaust fan.State.isPurging";
            WZStatus = "CPU2.PLC.Blocks.04 Tray handling.00 Main.DB TH HMI.Actual.State";
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        public string PZTemp
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    PZT.VariableName = value;
                }
            }
        }
        public string WZTemp
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    WZT.VariableName = value;
                }
            }
        }
      
        public string PZRpm
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    PZF.VariableName = value;
                }
            }
        }
        public string WZRpm
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    WZF.VariableName = value;
                }
            }
        }

        IVariable IVWZStatus;
        public string WZStatus
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVWZStatus = VS.GetVariable(value);
                    IVWZStatus.Change += IVWZStatus_Change;
                }
            }
        }
        private void IVWZStatus_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                switch ((short)e.Value)
                {
                    case 1: vh.IsChecked = true; vh.IsBlinkEnabled = false; break;
                    case 2: vh.IsChecked = true; vh.IsBlinkEnabled = true; break;
                    default: vh.IsChecked = false; vh.IsBlinkEnabled = false; break;
                }
            }
           
        }
        IVariable IVPZCaster;
        public string PZCaster
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVPZCaster = VS.GetVariable(value);
                    IVPZCaster.Change += IVPZCaster_Change;
                }
            }
        }
        private void IVPZCaster_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    phzNL.Visibility = Visibility.Visible;
                }
                else
                {
                    phzNL.Visibility = Visibility.Hidden;
                }
            }
        }
        
        IVariable IVWZCaster;
        public string WZCaster
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVWZCaster = VS.GetVariable(value);
                    IVWZCaster.Change += IVWZCaster_Change;
                }
            }
        }
        private void IVWZCaster_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    oNL.Visibility = Visibility.Visible;
                }
                else
                {
                    oNL.Visibility = Visibility.Hidden;
                }
            }
        }
        IVariable IVPZPurge;
        public string PZPurge
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVPZPurge = VS.GetVariable(value);
                    IVPZPurge.Change += IVPZPurge_Change;
                }
            }
        }
        private void IVPZPurge_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    phzPT.Visibility = Visibility.Visible;
                }
                else
                {
                    phzPT.Visibility = Visibility.Hidden;
                }
            }
        }

        IVariable IVWZPurge;
        public string WZPurge
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVWZPurge = VS.GetVariable(value);
                    IVWZPurge.Change += IVWZPurge_Change;
                }
            }
        }
        private void IVWZPurge_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    oPT.Visibility = Visibility.Visible;
                }
                else
                {
                    oPT.Visibility = Visibility.Hidden;
                }
            }
        }

       
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }
     
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "MO_PZWZ");
        }

    }
}
