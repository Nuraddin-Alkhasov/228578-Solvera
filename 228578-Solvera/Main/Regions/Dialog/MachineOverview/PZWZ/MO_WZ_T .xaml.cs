using HMI.CO.General;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_WZ_T")]
    public partial class MO_WZ_T
    {
        public MO_WZ_T()
        {
            InitializeComponent();
        }  

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseDialog1(this, border);
        }
    }
}