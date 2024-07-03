using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Protocol.Views
{
    [ExportView("Protocol_Trend")]
    public partial class Protocol_Trend
    {
        public Protocol_Trend()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Protocol_Trend");
        }
    }
}