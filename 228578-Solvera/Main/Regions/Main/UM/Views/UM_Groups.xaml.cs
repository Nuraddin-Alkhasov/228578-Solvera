using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.UM.Views
{
    /// <summary>
    /// Interaction logic for GroupManager.xaml
    /// </summary>
    [ExportView("UM_Groups")]
    public partial class UM_Groups
    {
        public UM_Groups()
        {
            InitializeComponent();
            DataContext = new Adapters.UM_Groups();
        }

    }
}