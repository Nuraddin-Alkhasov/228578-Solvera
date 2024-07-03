using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;

namespace HMI.Resources.UserControls.MO
{
    public partial class PaintType : UserControl
    {

        public PaintType()
        {
            InitializeComponent();
        }
        public string Header
        {
             get { return ""; } 
            set
            {
                A.LocalizableHeaderText = value;
            }
        }
        public string Paint
        {
             get { return ""; } 
            set
            {
                name.VariableName = value;
            }
        }
        public string Type
        {
             get { return ""; } 
            set
            {
                painttype.VariableName = value;
            }
        }
        public string Type2
        {
            get { return ""; }
            set
            {
                painttype2.VariableName = value;
            }
        }
        

        public string IsSolvent
        {
             get { return ""; } 
            set
            {
                solvent.VariableName = value;
            }
        }
        public string WatchDog
        {
             get { return ""; } 
            set
            {
                watchdog.VariableName = value;
            }
        }
        public string MaxCoatings
        {
             get { return ""; } 
            set
            {
                setCL.VariableName = value;
            }
        }
        public string Pump
        {
             get { return ""; } 
            set
            {
                pump.VariableName = value;
            }
        }
        public string PumpOn
        {
             get { return ""; } 
            set
            {
                pump_on.VariableName = value;
            }
        }
        public string PumpOff
        {
             get { return ""; } 
            set
            {
                pump_off.VariableName = value;
            }
        }
        public string WZUL
        {
             get { return ""; } 
            set
            {
               o_UL.VariableName = value;
            }
        }
        public string WZ
        {
             get { return ""; } 
            set
            {
                o_process.VariableName = value;
            }
        }
        public string WZLL
        {
             get { return ""; } 
            set
            {
                o_LL.VariableName = value;
            }
        }
        public string CZUL
        {
             get { return ""; } 
            set
            {
                c_UL.VariableName = value;
            }
        }
        public string CZ
        {
             get { return ""; } 
            set
            {
                c_process.VariableName = value;
            }
        }
        public string CZLL
        {
             get { return ""; } 
            set
            {
                c_LL.VariableName = value;
            }
        }

        public string ViscosityH
        {
             get { return ""; } 
            set
            {
                v_h.VariableName = value;
            }
        }
        public string ViscosityM
        {
             get { return ""; } 
            set
            {
                v_m.VariableName = value;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
         
        }
    }
}
