using HMI.CO.General;
using System.Windows;
using System.Windows.Controls;


namespace HMI.Resources.UserControls
{
    public partial class MR_Add : UserControl
    {
        public MR_Add()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

        public override string ToString() { return "MR_Add"; }

    }
}
