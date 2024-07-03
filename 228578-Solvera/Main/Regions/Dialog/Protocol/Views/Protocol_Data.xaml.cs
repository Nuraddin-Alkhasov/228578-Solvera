using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Protocol.Views
{
    [ExportView("Protocol_Data")]
    public partial class Protocol_Data
    {
        public Protocol_Data()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Protocol_Data");
        }
    }
}