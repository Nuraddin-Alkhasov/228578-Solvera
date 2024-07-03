using System;
using System.Windows;
using VisiWin.ApplicationFramework;
using System.Threading.Tasks;
using VisiWin.Alarm;
using VisiWin.DataAccess;
using System.Linq;
using System.Windows.Media.Animation;

namespace HMI.HeaderRegion.Views
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    [ExportView("Header")]
    public partial class Header
    {
        public Header()
        {
            InitializeComponent();
            DataContext = new Adapters.Header();
        }

    }
}