using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MVMaterial : UserControl
    {
        public MVMaterial()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }

        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable isMaterial = null;
        public string IsMaterial
        {
            get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isMaterial = VS.GetVariable(value);
                    isMaterial.Change += isMaterial_ValueChanged;
                }
            }  
        }

        private void isMaterial_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good) 
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(pack);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(pack);
                }
            }
            
        }
        public string AS
        {
            get { return ""; }
            set
            {
                Value.Visibility = Visibility.Visible;
                if (value == "Set") { Value.VariableName = IVSetLayer.Name; }

                if (value == "Actual") { { Value.VariableName = IVActualLayer.Name; } }
            }
        }
        IVariable IVActualLayer;
        public string ActualLayer
        {
            get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVActualLayer = VS.GetVariable(value);
                    IVActualLayer.Change += IVActualLayer_Change;
                }
            }
        }

        private void IVActualLayer_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((short)e.Value == 0)
                {
                    cl.Background = new SolidColorBrush(Colors.White);
                }
                if ((short)e.Value == (short)IVSetLayer.Value && (short)IVSetLayer.Value != 0)
                {
                    cl.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                }
                if ((short)e.Value != (short)IVSetLayer.Value && (short)e.Value != 0)
                {
                    cl.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                }
            }
        }
        IVariable IVSetLayer;
        public string SetLayer
        {
            get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVSetLayer = VS.GetVariable(value);
                }
            }
        }

        public string ValueWeight
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    Weight.Visibility = Visibility.Visible;
                    Weight.VariableName = value;
                }
            }
        }

    
        #region - - - Status - - -
        public int Station { set; get; } = 0;
        public string Header { set; get; } = "";
        public string Type { set; get; } = "";
        public string CPU { set; get; } = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = CPU,
                Station = Station,
                Header = Header,
                Type = Type
            }.Open();
        }

    }

    #endregion



}
