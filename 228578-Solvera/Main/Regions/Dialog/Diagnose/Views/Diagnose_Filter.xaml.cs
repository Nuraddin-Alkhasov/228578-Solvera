using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.Diagnose.Views
{

    [ExportView("Diagnose_Filter")]
    public partial class Diagnose_Filter
    {
        public Diagnose_Filter()
        {
            InitializeComponent();
            DataContext = ApplicationService.GetAdapter("Diagnose_Filter");
        }


    }
}