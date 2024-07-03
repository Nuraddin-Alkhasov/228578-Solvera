using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_ST")]
    public partial class MO_ST 
    {

        public MO_ST()
        {
            InitializeComponent();
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int M3_Temp = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag);
            
            SP sp = new SP(){
                Station = 6,
                Place = M3_Temp,
                Type = "Basket",
                CPU="CPU1"
            };

            switch (M3_Temp)
            {
                case 1: sp.Header = "@Status.Text35"; break;
                case 2: sp.Header = "@Status.Text36"; break;
                case 3: sp.Header = "@Status.Text37"; break;
            }

            sp.Open();
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

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



