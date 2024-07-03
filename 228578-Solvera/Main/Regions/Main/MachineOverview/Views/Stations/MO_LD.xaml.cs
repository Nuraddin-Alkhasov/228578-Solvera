using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_LD")]
    public partial class MO_LD 
    {

        public MO_LD()
        {
            InitializeComponent();
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
            Weight = "CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Station.BS.Weight";

            Release = "CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.to PC.isReloadable";
        }
       
        IVariableService VS = ApplicationService.GetService<IVariableService>();
        
        //private IVariable IVReloaded;

       
       
        private IVariable IVRelease;

        public string Release
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVRelease = VS.GetVariable(value);
                    IVRelease.Change += IVRelease_ValueChanged;
                }
            }
        }
        private void IVRelease_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {

                if ((bool)e.Value)
                {
                    update.IsEnabled = true;
                    update.IsBlinkEnabled = true;
                }
                else 
                {
                    update.IsEnabled = false;
                    update.IsBlinkEnabled = false;

                }
            }
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

        IVariable IVWeight;
        public string Weight
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVWeight = VS.GetVariable(value);
                    IVWeight.Change += IVWeight_ValueChanged;
                }
            }
        }
        private void IVWeight_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                f_weight.Value = (float)e.Value;
                t_weight.Value = (float)e.Value + (float)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.04 BS.01 Rotary.DB BS Rotary HMI.Parameters.Weight.Overweight");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU="CPU1",
                Station = 4,
                Header = "@Status.Text25",
                Type = "Basket"
            }.Open();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text102", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Reload", true);
            }
           
        }
    }
}



