using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Logging;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Coating_VC")]
    public partial class MO_Coating_VC
    {
        public MO_Coating_VC()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text45", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.PC.Function.Viscosity checked", true);
                loggingService.Log("Machine", "Visco", "@Logging.Machine.Text7", DateTime.Now);
            }

            new ObjectAnimator().CloseDialog1(this, border);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}