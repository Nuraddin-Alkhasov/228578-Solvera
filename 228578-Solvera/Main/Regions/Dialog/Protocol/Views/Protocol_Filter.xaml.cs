using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Protocol.Views
{
    [ExportView("Protocol_Filter")]
    public partial class Protocol_Filter
    {
        public Protocol_Filter()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Protocol_Filter");
        }
    }
}