using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.AppBarRegion.Views
{
    [ExportView("AppBar")]
    public partial class AppBar
    {
        public AppBar()
        {
            InitializeComponent();
            DataContext = new Adapters.AppBar();
        }

    }
}

