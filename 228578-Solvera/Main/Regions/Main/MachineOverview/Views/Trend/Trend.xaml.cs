using HMI.CO.Trend;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Trend;
using VisiWin.UserManagement;

namespace HMI.MainRegion.MO.Views
{
    [ExportView("Trend")]
    public partial class Trend
    {
        public Trend()
        {
            InitializeComponent();
            DataContext = new Adapters.Trend();
           
        }
      
    }
}
