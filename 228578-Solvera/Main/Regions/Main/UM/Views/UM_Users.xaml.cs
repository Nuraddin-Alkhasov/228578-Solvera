using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.UM.Views
{
    /// <summary>
    /// Interaction logic for UserManager.xaml
    /// </summary>
    [ExportView("UM_Users")]
    public partial class UM_Users
    {
        public UM_Users()
        {
            InitializeComponent();
            DataContext = new Adapters.UM_Users();
        }

    }
}