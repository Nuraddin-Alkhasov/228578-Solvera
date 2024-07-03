using HMI.CO.General;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Coating_SF")]
    public partial class MO_Coating_SF
    {
        public MO_Coating_SF()
        {
            InitializeComponent();
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable VStatus;
        IVariable VPurge;
        IVariable VPS1;
        IVariable VPS2;

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

            VStatus = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.07 Air.DB CD Air HMI.Actual.Supply fan.Ventilator");
            VStatus.Change += VStatus_Change;

            VPurge = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.07 Air.DB CD Air HMI.Actual.Supply fan.isPurging");
            VPurge.Change += VPurge_Change;

            VPS1 = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.07 Air.DB CD Air HMI.Actual.Supply fan.Pressure switch 1");
            VPS1.Change += VPS1_Change;

            VPS2 = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.07 Air.DB CD Air HMI.Actual.Supply fan.Pressure switch 2");
            VPS2.Change += VPS2_Change;

        }

        private void VStatus_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                switch ((short)e.Value)
                {
                    case 0:
                        V_On.IsDefault = false;
                        V_On.IsBlinkEnabled = false;
                        break;
                    case 1:
                        V_On.IsDefault = true;
                        V_On.IsBlinkEnabled = false;
                        break;
                    case 2:
                        V_On.IsDefault = true;
                        V_On.IsBlinkEnabled = true;
                        break;
                }
            }
        }
        private void VPurge_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                    Purge.Visibility = Visibility.Visible;
                else
                    Purge.Visibility = Visibility.Hidden;
            }

        }
        private void VPS1_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    PS1.Background = (LinearGradientBrush)Application.Current.Resources["FP_Green_Gradient"];
                    PS1.IsBlinkEnabled = false;
                }
                else
                {
                    PS1.Background = (LinearGradientBrush)Application.Current.Resources["FP_Yellow_Gradient"];
                    PS1.IsBlinkEnabled = true;
                }
            }
        }
        private void VPS2_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    PS2.Background = (LinearGradientBrush)Application.Current.Resources["FP_Green_Gradient"];
                    PS2.IsBlinkEnabled = false;
                }
                else
                {
                    PS2.Background = (LinearGradientBrush)Application.Current.Resources["FP_Yellow_Gradient"];
                    PS2.IsBlinkEnabled = true;
                }
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}