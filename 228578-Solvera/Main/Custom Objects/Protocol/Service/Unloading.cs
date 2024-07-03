using HMI.CO.General;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class Unloading
    {
        public Unloading(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_Unloading;
        }



        #region - - - Properties - - -  

        IVariable Event;
        public IVariable Run_Id { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Event_Unloading(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Run r = GetRun((int)(uint)Run_Id.Value);
                    if (r.Id > 0)
                    {
                        WriteEndToRun(r);
                        WriteEndToCharge(r);
                        WriteEndToBoxes(r);
                        WriteEndToOrders(r);
                    }
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private Run GetRun(int run_id)
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Runs " +
                                             "WHERE Id = " + run_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return new Run()
                {
                    Id = run_id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"]
                };
            }
            else { return new Run(); }
        }
        private void WriteEndToRun(Run r)
        {
            new MSSQLEAdapter("Orders", "UPDATE Runs " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + r.Id + ";").DB_Input();
        }

        private void WriteEndToCharge(Run r)
        {
            new MSSQLEAdapter("Orders", "UPDATE Charges " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + r.Charge_Id + ";").DB_Input();
        }

        private void WriteEndToBoxes(Run r)
        {
            DataTable charges = new MSSQLEAdapter("Orders", "SELECT * " +
                                            "FROM Charges " +
                                            "WHERE Box_Id = " + r.Box_Id + ";").DB_Output();

            

            string current = (from row in charges.AsEnumerable() where row.Field<int>("Id") == r.Charge_Id select row).First()["Charge"].ToString();

            string max = charges.AsEnumerable().Max(row => row["Charge"]).ToString();

            if (current == max)
            {
                new MSSQLEAdapter("Orders", "UPDATE Boxes " +
                                     "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                     "WHERE Id = " + r.Box_Id + ";").DB_Input();
              
            }
        }

        private void WriteEndToOrders(Run r)
        {
            DataTable charges = new MSSQLEAdapter("Orders", "SELECT * " +
                                                  "FROM Boxes " +
                                                  "WHERE Order_Id = " + r.Order_Id + ";").DB_Output();

            DataTable T = new MSSQLEAdapter("Orders", "SELECT * " +
                                                "FROM Orders " +
                                                "WHERE Id = " + r.Order_Id + ";").DB_Output();


            ApplicationService.SetVariableValue("CPU2.PLC.Blocks.04 Tray handling.09 US 1.01 Belt.DB US 1 Belt HMI.Actual.Order#STRING20", T.Rows[0]["Data_1"].ToString());
            
            string current = (from row in charges.AsEnumerable() where row.Field<int>("Id") == r.Box_Id select row).First()["Box"].ToString();

            string max = charges.AsEnumerable().Max(row => row["Box"]).ToString();

            if (current == max)
            {
                new MSSQLEAdapter("Orders", "UPDATE Orders " +
                                     "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                     "WHERE Id = " + r.Order_Id + ";").DB_Input();
            }
        }

        #endregion

    }
}
