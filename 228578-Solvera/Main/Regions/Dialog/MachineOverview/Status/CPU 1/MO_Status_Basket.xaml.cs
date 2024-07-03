using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Status_Basket")]
    public partial class MO_Status_Basket
    {

        public MO_Status_Basket()
        {
            InitializeComponent();
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
            paints.StateList = GetPaintTypes();
        }

        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();
            for (int i = 1; i <= 10; i++)
            {

                string temp = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + i + "]").ToString();
                if (temp != "")
                {
                    Temp_SC.Add(new State()
                    {
                        Text = temp,
                        Value = i.ToString()
                    });
                }
            }
            return Temp_SC;
        }
    }
}