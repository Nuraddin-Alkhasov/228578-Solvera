using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.UM.Views
{
    [ExportView("UM_AddChangeUser")]
    public partial class UM_AddChangeUser
    {
        public UM_AddChangeUser()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("UM_AddChangeUser");
        }
    }
}