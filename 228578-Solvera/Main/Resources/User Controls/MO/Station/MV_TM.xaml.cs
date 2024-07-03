using HMI.CO.General;
using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_TM : UserControl
    {
        public MV_TM()
        {
            InitializeComponent();
            Traction = "CPU2.PLC.Blocks.04 Tray handling.04 TM.01 Traction.DB TM Traction HMI.Actual.Traction.Motor.Actual.Position";

        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVTraction;
        public string Traction
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTraction = VS.GetVariable(value);
                    IVTraction.Change += IVTraction_Change;
                }
            }
        }
        double OldTraction = 0;
        private void IVTraction_Change(object sender, VariableEventArgs e)
        {
            double pos = Math.Round(((float)e.Value) * 0.06570);
            
            if (OldTraction != pos)
            {
                Mani.Margin = new Thickness(0, 3, pos, 0);
                OldTraction = pos;
             
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
                CPU="CPU2",
                Station = 16,
                Header = "@Status.Text71",
                Type = "Tray"
            }.Open();
        }
    }
}
