using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Diagnose.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    [ExportView("Diagnose_Current")]
    public partial class Diagnose_Current
    {
        public Diagnose_Current()
        {
            InitializeComponent();
            DataContext = new Adapters.Diagnose_Current();
        }

        //private void OpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    new ObjectAnimator().OpenMenu(SubMenu, ButtonCloseMenu, ButtonOpenMenu);
        //}

        //private void CloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    new ObjectAnimator().CloseMenu(SubMenu, ButtonCloseMenu, ButtonOpenMenu);
        //}


    }
}