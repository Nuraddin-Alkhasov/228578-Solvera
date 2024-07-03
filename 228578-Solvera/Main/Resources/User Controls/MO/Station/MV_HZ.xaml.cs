using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_HZ : UserControl
    {
        public MV_HZ()
        {
            InitializeComponent();
            HZTemp = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.01 Air.DB HZ 1 Air HMI.Actual.Temperature";
            HZRpm = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.01 Air.DB HZ 1 Air HMI.Actual.Circulation fan.Motor.Actual.Speed 2";
            HZCaster = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.01 Air.DB HZ 1 Air HMI.Actual.Caster";
        }

        IVariableService VS = ApplicationService.GetService<IVariableService>();

        public string HZTemp
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    HZ1T.VariableName = value;
                }
            }
        }

        public string HZRpm
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    HZ1F.VariableName = value;
                }
            }
        }
        IVariable IVHZCaster;
        public string HZCaster
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVHZCaster = VS.GetVariable(value);
                    IVHZCaster.Change += IVHZCaster_Change;
                }
            }
        }
        private void IVHZCaster_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    hzNL.Visibility = Visibility.Visible;
                }
                else
                {
                    hzNL.Visibility = Visibility.Hidden;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "MO_HZ");
        }
    }
}
