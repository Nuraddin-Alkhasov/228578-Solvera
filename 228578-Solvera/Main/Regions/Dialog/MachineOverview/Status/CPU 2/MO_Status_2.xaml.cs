using VisiWin.ApplicationFramework;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Status_2")]
    public partial class MO_Status_2
    {

        public MO_Status_2()
        {
            this.InitializeComponent();

            DataContext = new Adapters.MO_Status_2();

        }

    }
}