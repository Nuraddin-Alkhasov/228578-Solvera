using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.UM.Views
{
    [ExportView("UM_ChangePassword")]
    public partial class UM_ChangePassword
    {
        public UM_ChangePassword()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("UM_ChangePW");
        }
    }
}