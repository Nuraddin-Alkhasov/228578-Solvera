using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_CI : UserControl
    {
        public MV_CI()
        {
            InitializeComponent();
            Position = "CPU1.PLC.Blocks.02 Basket handling.05 CI.01 Traction.DB CI Traction HMI.Actual.Traction.Motor.Actual.Position";

        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVPosition;
        public string Position
        {
             get { return ""; } 
            set
            {
                IVPosition = VS.GetVariable(value);
                IVPosition.Change += IVPosition_ValueChanged;
            }
        }
        double Oldpos = 0;
        private void IVPosition_ValueChanged(object sender, VariableEventArgs e)
        {

            double pos = Math.Round(((float)e.Value) * 0.03843);

            if (Oldpos != pos)
            {
                HVT.Margin = new Thickness(3, 0, 0, pos);
                Oldpos = pos;
            }
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 9,
                Header = "@Status.Text39",
                Type = "Basket",
                CPU = "CPU1"
            }.Open();
        }
    }
}
