using HMI.CO.General;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.MO.Views
{

	[ExportView("MO_Sheduler")]
	public partial class MO_Sheduler
    {

        public MO_Sheduler()
		{
			this.InitializeComponent();
          
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }

        private void LeftButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.Timer.On", true);
        }

        private void RightButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.Timer.On", false);
        }

        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}