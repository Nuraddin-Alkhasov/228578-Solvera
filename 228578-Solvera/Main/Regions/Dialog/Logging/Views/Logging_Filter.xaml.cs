using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Logging.Views
{

    [ExportView("Logging_Filter")]
    public partial class Logging_Filter
    {
        public Logging_Filter()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Logging_Filter");
        }

    }
}