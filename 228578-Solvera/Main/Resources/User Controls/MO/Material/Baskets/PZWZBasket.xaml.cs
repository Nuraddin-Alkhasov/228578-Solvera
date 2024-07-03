using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class PZWZBasket : UserControl
    {
        public PZWZBasket()
        {
            InitializeComponent();
        }

        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        private IVariable isBasket;
        public string IsBasket
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isBasket = VS.GetVariable(value);
                    isBasket.Change += IsBasket_ValueChanged;
                }
            }
        }

        private void IsBasket_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(A);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(A);
                }
            }
        }

        private IVariable isMaterial;
        public string IsMaterial
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isMaterial = VS.GetVariable(value);
                    isMaterial.Change += IsMaterial_ValueChanged;
                }
            }
        }

        private void IsMaterial_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(ismaterial);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(ismaterial);
                }
            }
        }
        IVariable isDischarge;
        public string IsDischarge
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isDischarge = VS.GetVariable(value);
                    isDischarge.Change += IsDischarge_ValueChanged;
                }
            }
        }

        private void IsDischarge_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(discharge);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(discharge);
                }
            }
        }


        public string AS
        {
            get { return ""; }
            set
            {

                if (value == "Set") { ismaterial.VariableName = IVSetLayer.Name; }

                if (value == "Actual") { { ismaterial.VariableName = IVActualLayer.Name; } }
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
                    ismaterial.Background = new SolidColorBrush(Colors.White);
                }
                if ((short)e.Value == (short)IVSetLayer.Value && (short)IVSetLayer.Value != 0)
                {
                    ismaterial.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                }
                if ((short)e.Value != (short)IVSetLayer.Value && (short)e.Value != 0)
                {
                    ismaterial.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
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

        public override string ToString() { return "Basket"; }

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
        #endregion
    }

}
