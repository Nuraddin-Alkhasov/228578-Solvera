using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.UM.Views
{
    /// <summary>
    /// Interaction logic for UserAdd.xaml
    /// </summary>
    [ExportView("UM_AddChangeGroup")]
    public partial class UM_AddChangeGroup
    {
        public UM_AddChangeGroup()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("UM_AddChangeGroup");
        }
    }
}