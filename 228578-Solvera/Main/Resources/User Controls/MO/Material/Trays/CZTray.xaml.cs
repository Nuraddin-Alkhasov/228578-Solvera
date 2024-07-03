using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class CZTray : UserControl
    {
        public CZTray()
        {
            InitializeComponent();
        }
        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        IVariable isTray;
        public string IsTray
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isTray = VS.GetVariable(value);
                    isTray.Change += isTray_ValueChanged;
                }
            }
        }

        private void isTray_ValueChanged(object sender, VariableEventArgs e)
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

        IVariable isMaterial;
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
        IVariable isWatch;
        public string IsWatch
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    isWatch = VS.GetVariable(value);
                    isWatch.Change += IsWatch_ValueChanged;
                }
            }
        }

        private void IsWatch_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(watch);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(watch);
                }
            }
        }

        IVariable IVActualLayer;
        public string ActualLayer
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    aCL.VariableName = value;
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
                    aCL.Background = new SolidColorBrush(Colors.White);
                    sCL.Background = new SolidColorBrush(Colors.White);
                }
                if ((short)e.Value == (short)IVSetLayer.Value && (short)IVSetLayer.Value != 0)
                {
                    aCL.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                    sCL.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                }
                if ((short)e.Value != (short)IVSetLayer.Value && (short)e.Value != 0)
                {
                    aCL.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                    sCL.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                }
            }

        }
        IVariable IVSetLayer;
        public string SetLayer
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVSetLayer = VS.GetVariable(value);
                    sCL.VariableName = value;
                }
            }
        }

        public override string ToString() { return "Tray"; }

        #region - - - Status - - -

        public int Station { set; get; } = 0;
        public int place { set; get; } = 0;
        public int Place
        {

            get { return place; }
            set
            {
                place = value;
            }
        }


        public int coord { set; get; } = 0;
        public int Coord
        {

            get { return coord; }
            set
            {
                Vplace.Text = value.ToString();
                if (value == 0)
                {
                    Vplace.Foreground = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red");
                    Vplace.FontWeight = FontWeights.Bold;
                    Vplace.Text = " > "+ value.ToString() + " < ";
                }

            }
        }
        public string Header { set; get; } = "";
        public string Type { set; get; } = "";
        public string CPU { set; get; } = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = CPU,
                Station = Station,
                Place = Place,
                Header = Header,
                Type = Type
            }.Open();
        }
        #endregion
    }
}
