using HMI.CO.General;
using System;
using System.Data;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class NewRun
    {
        public NewRun(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_NewRun;
        }



        #region - - - Properties - - -  

        IVariable Event;
        public IVariable Charge_Id { set; get; }
        public IVariable Run_Id { set; get; }
        public IVariable RunNr { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Event_NewRun(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Charge c = GetCharge((int)(uint)Charge_Id.Value);
                    if (c.Id > 0)
                    {
                        WriteEndToRun();
                        Run_Id.Value = WriteNewRun(c);
                    }
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private Charge GetCharge(int charge_id)
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                      "FROM Charges " +
                                      "WHERE Id = " + charge_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return new Charge()
                {
                    Id = charge_id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Runs = (int)DT.Rows[0]["Runs"]

                };
            }
            else
            {
                return new Charge();
            }
        }
        private void WriteEndToRun()
        {
            new MSSQLEAdapter("Orders", "UPDATE Runs " +
                                  "SET [End] = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + Run_Id.Value + ";").DB_Input();
        }
        private int WriteNewRun(Charge charge)
        {
            charge.Runs += 1;
            new MSSQLEAdapter("Orders", "INSERT " +
                                "INTO Runs (Order_Id, Box_Id, Charge_Id, Run, [User]) " +
                                "VALUES (" +
                                charge.Order_Id + "," +
                                charge.Box_Id + "," +
                                charge.Id + ", " +
                                charge.Runs + ",'" +
                                ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
            RunNr.Value = charge.Runs;
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Runs " +
                                             "WHERE Charge_Id = " + charge.Id + " AND " +
                                             "Run = " + charge.Runs + ";").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        #endregion

    }
}
