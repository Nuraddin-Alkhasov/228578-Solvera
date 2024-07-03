using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Coating_DT")]
    public partial class MO_Coating_DT
    {
        public MO_Coating_DT()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

            StateCollection Temp_SC = new StateCollection();
            for (int i = 1; i <= 10; i++)
            {

                string temp = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + i + "]").ToString();
                if (temp != "")
                {
                    Temp_SC.Add(new State()
                    {
                        Text = temp,
                        Value = i.ToString()
                    });
                }
            }
            DT1.StateList = DT2.StateList = Temp_SC;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}