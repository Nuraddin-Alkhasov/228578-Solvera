using HMI.CO.General;
using System;
using System.Data;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class NewCharge
    {
        public NewCharge(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_NewCharge;
        }



        #region - - - Properties - - -  

        IVariable Event;
        public IVariable Box_Id { set; get; }
        public IVariable Charge_Id { set; get; }
        public IVariable ChargeNr { set; get; }
        public IVariable Run_Id { set; get; }
        public IVariable RunNr { set; get; }
        public IVariable WeightL { set; get; }
        public IVariable WeightR { set; get; }
        public IVariable Optimized { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Event_NewCharge(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    Box b = GetBox((int)(uint)Box_Id.Value);
                    if (b.Id > 0)
                    {
                        Charge_Id.Value = WriteNewCharge(b);
                        Run_Id.Value = WriteNewRun(b);
                    }
                });
            }
        }

        #endregion

        #region - - - Methods - - - 
        private Box GetBox(int box_id)
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                      "FROM Boxes " +
                                      "WHERE Id = " + box_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return new Box()
                {
                    Id = box_id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"]
                };
            }
            else
            {
                return new Box();
            }
        }
        private int WriteNewCharge(Box box)
        {

            DataTable DT = new MSSQLEAdapter("Orders", "SELECT MAX(Charge) as Charge " +
                                                 "FROM Charges " +
                                                 "WHERE Box_Id = " + box.Id + "; ").DB_Output();
            int Charge = 1;
            if (DT.Rows[0]["Charge"] != System.DBNull.Value)
            {
                Charge = (int)DT.Rows[0]["Charge"] + 1;
            }

                ChargeNr.Value = Charge;

            new MSSQLEAdapter("Orders", "INSERT " +
                                     "INTO Charges (Order_Id, Box_Id, Charge, Weight, isOptimized, [User]) " +
                                     "VALUES (" +
                                     box.Order_Id + "," +
                                     box.Id + "," +
                                     Charge + ",'" +
                                     Math.Round((float)WeightL.Value + (float)WeightR.Value, 1).ToString().Replace(",", ".") + "','" +
                                     Optimized.Value.ToString().ToUpper() + "','" +
                                     ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();

            DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                   "FROM Charges " +
                                   "WHERE Box_Id = " + box.Id + " AND " +
                                   "Charge = " + Charge + ";").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        private int WriteNewRun(Box box)
        {
            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO Runs (Order_Id, Box_Id, Charge_Id, Run, [User]) " +
                                  "VALUES (" +
                                  box.Order_Id + "," +
                                  box.Id + "," +
                                  Charge_Id.Value + ", 1,'" +
                                  ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
            RunNr.Value = 1;
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Runs " +
                                             "WHERE Charge_Id = " + Charge_Id.Value + " AND " +
                                             "Run = 1;").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        #endregion

    }
}
