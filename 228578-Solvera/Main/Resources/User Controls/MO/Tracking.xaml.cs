using HMI.CO.General;
using System.Windows.Controls;

namespace HMI.Resources.UserControls.MO
{
    public partial class Tracking : UserControl
    {
        public Tracking()
        {
            InitializeComponent();
        }
        public int X1 { set { line.X1 = value; } }
        public int Y1 { set { line.Y1 = value; } }
        public int X2 { set { line.X2 = value; } }
        public int Y2 { set { line.Y2 = value; } }

        public Track Data 
        {
            set 
            {
                d1.Text = value.Data_1;
                d2.Text = value.Data_2;
                mr.Text = value.MR;
                charges.Text = value.Charges.ToString();
                article.SymbolResourceKey = value.Article;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(A);
        }
    }
}
