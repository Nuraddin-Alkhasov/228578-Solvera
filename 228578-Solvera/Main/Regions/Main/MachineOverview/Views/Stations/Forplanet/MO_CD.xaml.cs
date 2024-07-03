using HMI.CO.General;
using HMI.CO.Trend;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_CD")]
    public partial class MO_CD
    {
       
        public MO_CD()
        {
            InitializeComponent();

            DTPosition = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.Actual.Motor.Actual.Position");
            DTPosition.Change += DTPosition_Change;
            IsDT = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Dipping tank.isDT");
            IsDT.Change += IsDT_Change;
            VC = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Dipping tank.Viscosity.Check required");
            VC.Change += VC_Change;
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
        }

        #region - - - Properties - - - 

        IVariableService VS = ApplicationService.GetService<IVariableService>();
        IVariable DTPosition;
        IVariable IsDT;
        IVariable StepType;
        IVariable VC;
        double Oldpos = 0;

        #endregion

        #region - - - Event Handlers - - -
        private void IsDT_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good) 
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowUIElement(LTB);
                }
                else
                {
                    new ObjectAnimator().HideUIElement(LTB);
                }
            }
           
        }
        private void DTPosition_Change(object sender, VariableEventArgs e)
        {
            double pos = Math.Round(((float)e.Value) * 0.2208);

            if (Oldpos != pos)
            {
               
                LTB.Margin = new Thickness(746, 0, 0, pos + 34);
                Oldpos = pos;
            }
        }
        private void CoatingStep_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                object content;
                switch ((short)e.Value)
                {
                    case 1: content = new MO_CD_Dip(); break;
                    case 2: content = new MO_CD_Spin(); break;
                    default: content = null; break;
                }
                Dispatcher.InvokeAsync((Action)delegate
                {
                    region.Content = content;
                });
            }

        }
        private void VC_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    vgroup.IsBlinkEnabled = true;
                    vgroup.LocalizableHeaderText = "@MachineOverview.Text52";
                }
                else
                {
                    vgroup.LocalizableHeaderText = "@MachineOverview.Text51";
                    vgroup.IsBlinkEnabled = false;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "DT",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text3",
                Min = 0,
                Max = 50,
                BackViewName = "MO_CD"
            });

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU="CPU1",
                Station = 10,
                Header = "@Status.Text38",
                Type = "Basket"
            }.Open();
        }


        private void region_Loaded(object sender, RoutedEventArgs e)
        {
            StepType = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.Library.DB Program control.Set active Step.Data.Type");
            StepType.Change += CoatingStep_Change;
        }
        #endregion






        private void TextVarOut_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((short)e.Value >= 1 && (short)e.Value <= 10)
                {
                    PaintTyp.Value = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (short)e.Value + "]").ToString();
                }
                else
                {
                    PaintTyp.Value = " - - - ";
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "MO_Paints_PN");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "MO_Coating_DT");
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion1", "MO_Coating_VC");
        }


        private IVariable IVModus;

        public string Modus
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVModus = VS.GetVariable(value);
                    IVModus.Change += IVModus_ValueChanged;
                }
            }
        }
        private void IVModus_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                Mod.Visibility = Visibility.Visible;
                switch ((byte)e.Value)
                {
                    case 1:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text1";
                        break;
                    case 2:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text2"; break;
                    case 3:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text3"; break;
                    default: Mod.Visibility = Visibility.Collapsed; break;
                }
            }
        }
    }
}



