using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;

using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_BSMP : UserControl
    {
        public MV_BSMP()
        {
            InitializeComponent();
            ManipulatorPosition = "CPU1.PLC.Blocks.02 Basket handling.01 BM.02 Rotary.DB BM Rotary HMI.Actual.State";
        }
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        IVariable maniPos;
        public string ManipulatorPosition
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    maniPos = VS.GetVariable(value);
                    maniPos.Change += maniPos_Change;
                }
            }
        }

        private void maniPos_Change(object sender, VariableEventArgs e)
        {
            GridClear();
            switch ((short)e.Value) 
            {
                case 0:
                    ManiPosition.SymbolResourceKey = "MV_MP1";
                    B.Children.Add(GetBasket("R", new Thickness(116, 221, 0, 0), 0));
                    B.Children.Add(GetBasket("L", new Thickness(116, 262, 0, 0),0));
                    
                    break;
                case 1:
                    ManiPosition.SymbolResourceKey = "MV_MP2";
                    break;
                case 2:
                    ManiPosition.SymbolResourceKey = "MV_MP3";
                    B.Children.Add(GetBasket("L", new Thickness(145, 305, 0, 0),2));
                    B.Children.Add(GetBasket("R", new Thickness(197, 322, 0, 0),2));
                    break;
                case 3:
                    ManiPosition.SymbolResourceKey = "MV_MP4";
                    B.Children.Add(GetBasket("L", new Thickness(99, 411, 0, 0),3));
                    B.Children.Add(GetBasket("R", new Thickness(150, 427, 0, 0),3));
                    break; 
                case 4:
                    ManiPosition.SymbolResourceKey = "MV_MP5";
                    B.Children.Add(GetBasket("R", new Thickness(216, 318, 0, 0),4));
                    B.Children.Add(GetBasket("L", new Thickness(270, 310, 0, 0),4));
                   
                    break;
                case 5:
                    ManiPosition.SymbolResourceKey = "MV_MP6";
                    break;
                case 6:
                    ManiPosition.SymbolResourceKey = "MV_MP7";
                    B.Children.Add(GetBasket("L", new Thickness(331, 231, 0, 0),6));
                    B.Children.Add(GetBasket("R", new Thickness(331, 270, 0, 0),6));
                    break;
                case 7:
                    ManiPosition.SymbolResourceKey = "MV_MP8";
                   break;
                case 8:
                    ManiPosition.SymbolResourceKey = "MV_MP9";
                    B.Children.Add(GetBasket("L", new Thickness(446, 172, -3, 0), 7));
                    B.Children.Add(GetBasket("R", new Thickness(446, 212, -3, 0), 7)); break;
            }
        }

        private void GridClear()
        {
            for (int i = B.Children.Count - 1; i >= 0; i--)
            {
                B.Children.RemoveAt(i);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }
       
        #region - - - Status - - -
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = "CPU1",
                Station = 5,
                Header = "@Status.Text30",
                Type = "Basket"
            }.Open();

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new SP
            {
                CPU = "CPU1",
                Station = 4,
                Header = "@Status.Text25",
                Type = "Basket"
            }.Open();
        }

    

        #endregion
     
        private MVBasket GetBasket(string Basket, Thickness margin, int ManiPos) 
        {

            MVBasket temp = new MVBasket() 
            {
                CPU = "CPU1",
                Station = 5,
                Header = "@Status.Text30",
                Type = "Basket"
            };

            switch (Basket)
            {
                case "L":
                    temp.IsBasket = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Baskets.isBaskets";
                    temp.IsMaterial = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.isMaterial";
                    temp.SetLayer = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.Layers.Set";
                   
                    temp.ActualLayer = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.Layers.Actual";
                    temp.AS = "Set";
                    if (ManiPos >= 0 && ManiPos <= 2 || ManiPos == 4)
                    {
                        temp.IsDischarge = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Baskets.Functions.Discharge";
                    }
                    break;
                case "R":
                    temp.IsBasket = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Baskets.isBaskets";
                    temp.IsMaterial = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.isMaterial";
                    temp.SetLayer = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.Layers.Set";
                    temp.ActualLayer = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Charge.Layers.Actual";
                    temp.AS = "Actual";
                    if (ManiPos >= 3 && ManiPos <= 7 && ManiPos != 4)
                    {
                        temp.IsDischarge = "CPU1.PLC.Blocks.02 Basket handling.01 BM.00 Main.DB BM PD.Baskets.Functions.Discharge";

                    }
                    break;
            }

            temp.VerticalAlignment = VerticalAlignment.Top;
            temp.HorizontalAlignment = HorizontalAlignment.Left;
            temp.Margin = margin;
            return temp;
        }
    }
}
