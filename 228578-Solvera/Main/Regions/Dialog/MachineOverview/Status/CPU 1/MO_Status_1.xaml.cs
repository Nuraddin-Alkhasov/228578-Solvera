using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_Status_1")]
    public partial class MO_Status_1
    {

        public MO_Status_1()
        {
            this.InitializeComponent();

            DataContext = new Adapters.MO_Status_1();
            //paints.StateList = GetPaintTypes();
        }
        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();
            for (int i = 1; i <= 10; i++)
            {

                string temp = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Coating.10 DT.DB Vat Para Temp.Name[" + i + "]").ToString();
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