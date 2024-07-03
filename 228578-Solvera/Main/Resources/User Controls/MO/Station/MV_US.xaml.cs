using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_US : UserControl
    {
        public MV_US()
        {
            InitializeComponent();
            isBox1 = "CPU2.PLC.Blocks.04 Tray handling.09 US 1.00 Main.DB US 1 PD.Box.Box.isBox";
            isMaterialBox1 = "CPU2.PLC.Blocks.04 Tray handling.09 US 1.00 Main.DB US 1 PD.Box.Charge.isMaterial";
            isBox2 = "CPU2.PLC.Blocks.04 Tray handling.10 US 2.00 Main.DB US 2 PD.Box.Box.isBox";
            isMaterialBox2 = "CPU2.PLC.Blocks.04 Tray handling.10 US 2.00 Main.DB US 2 PD.Box.Charge.isMaterial";
            isBox1Full = "CPU2.PLC.Blocks.04 Tray handling.09 US 1.01 Belt.DB US 1 Belt HMI.Actual.Box.Needs to be changed";
            isBox2Full = "CPU2.PLC.Blocks.04 Tray handling.10 US 2.01 Belt.DB US 2 Belt HMI.Actual.Box.Needs to be changed";
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable IVTBox1Full;
        public string isBox1Full
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTBox1Full = VS.GetVariable(value);
                    IVTBox1Full.Change += IVTBox1Full_Change;
                }
            }
        }
        private void IVTBox1Full_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    nr1.FontSize = 20;
                    nr1.Foreground = Brushes.Red; 
                    new ObjectAnimator().BlinkUIElement(nr1);
                }
                else
                {
                    nr1.FontSize = 16;
                    nr1.Foreground = Brushes.White;
                    new ObjectAnimator().ShowUIElement(nr1);
                }
            }
        }

        IVariable IVTBox2Full;
        public string isBox2Full
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTBox2Full = VS.GetVariable(value);
                    IVTBox2Full.Change += IVTBox2Full_Change;
                }
            }
        }
        private void IVTBox2Full_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    nr2.FontSize = 20;
                    nr2.Foreground = Brushes.Red;
                    new ObjectAnimator().BlinkUIElement(nr2);
                }
                else
                {
                    nr2.FontSize = 16;
                    nr2.Foreground = Brushes.White;
                    new ObjectAnimator().ShowUIElement(nr2);
                }
            }
        }

        IVariable IVTBox1;
        public string isBox1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTBox1 = VS.GetVariable(value);
                    IVTBox1.Change += IVTBox1_Change;
                }
            }
        }
        private void IVTBox1_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(box1);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(box1);
                }
            }
        }

        IVariable IVTisMaterialBox1;
        public string isMaterialBox1
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTisMaterialBox1 = VS.GetVariable(value);
                    IVTisMaterialBox1.Change += IVTisMaterialBox1_Change;
                }
            }
        }
        private void IVTisMaterialBox1_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(isMat1);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(isMat1);
                }
            }
        }

        IVariable IVTBox2;
        public string isBox2
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTBox2 = VS.GetVariable(value);
                    IVTBox2.Change += IVTBox2_Change;
                }
            }
        }
        private void IVTBox2_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(box2);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(box2);
                }
            }


        }

        IVariable IVTisMaterialBox2;
        public string isMaterialBox2
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVTisMaterialBox2 = VS.GetVariable(value);
                    IVTisMaterialBox2.Change += IVTisMaterialBox2_Change;
                }
            }
        }
        private void IVTisMaterialBox2_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if ((bool)e.Value)
                {
                    new ObjectAnimator().ShowMOElement(isMat2);
                }
                else
                {
                    new ObjectAnimator().HideMOElement(isMat2);
                }
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
                Station = 19,
                Header = "@Status.Text74",
                Type = "Box",
                CPU = "CPU2"
            }.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 21,
                Header = "@Status.Text78",
                Type = "Box",
                CPU = "CPU2"
            }.Open();
        }
    }
}
