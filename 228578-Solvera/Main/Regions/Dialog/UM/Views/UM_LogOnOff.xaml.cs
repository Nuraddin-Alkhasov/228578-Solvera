using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.UM.Views
{
    [ExportView("UM_LogOnOff")]
    public partial class UM_LogOnOff
    {
        public UM_LogOnOff()
        {
            InitializeComponent();
            DataContext = new Adapters.UM_LogOnOff();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}