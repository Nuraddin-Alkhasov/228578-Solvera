using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Protocol.Views
{
    [ExportView("Protocol_MR")]
    public partial class Protocol_MR
    {
        public Protocol_MR()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Protocol_MR");
        }
    }
}