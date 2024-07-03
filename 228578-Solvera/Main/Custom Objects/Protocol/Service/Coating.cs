using HMI.CO.General;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    class Coating
    {
        public Coating(string _Start, string _End, string _Error)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();

            Start = VS.GetVariable(_Start);
            Start.Change += Start_Event;

            End = VS.GetVariable(_End);
            End.Change += End_Event;

            Error = VS.GetVariable(_Error);
            Error.Change += Error_Event;
        }
        #region - - - Properties - - -  

        ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();

        IVariable Start;
        IVariable End;
        IVariable Error;
        public IVariable Run_Id { set; get; }
        public IVariable SetPaintTemp { set; get; }
        public IVariable ActualPaintTemp { set; get; }
        public IVariable PaintType { set; get; }
        public IVariable ActualLayer { set; get; }
        public IVariable MR_Id { set; get; }
        public string Paints { set; get; }
        public int StartError { set; get; }
        public int EndError { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Start_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Start.Value = false;
                Task.Run(() =>
                {
                    Run r = GetRun((int)(uint)Run_Id.Value);
                    if (r.Id > 0)
                    {
                        WriteDateTimeToRun("C_S", r);
                        WriteSetValuesToRun(r);
                        WriteActualValuesToRun(r);
                    }
                });
            }
        }

        private void End_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                End.Value = false;
                Task.Run(() =>
                {
                    Run r = GetRun((int)(uint)Run_Id.Value);
                    if (r.Id > 0)
                        WriteDateTimeToRun("C_E", r);
                });
            }
        }

        private void Error_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Error.Value = false;
                Task.Run(() =>
                {
                    Run r = GetRun((int)(uint)Run_Id.Value);
                    if (r.Id > 0)
                        WriteErrorsToRun(r);
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

        private void WriteDateTimeToRun(string clmn, Run run)
        {
            new MSSQLEAdapter("Orders", "UPDATE Runs " +
                                  "SET " + clmn + " = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' " +
                                  "WHERE Id = " + run.Id + ";").DB_Input();
        }

        private void WriteSetValuesToRun(Run run)
        {
            string Paint = ApplicationService.GetVariableValue(Paints + "[" + PaintType.Value + "]").ToString();
            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO SetValues (Order_Id, Box_Id, Charge_Id, Run_Id, PaintType, PaintTemp) " +
                                  "VALUES (" +
                                  run.Order_Id + "," +
                                  run.Box_Id + "," +
                                  run.Charge_Id + "," +
                                  Run_Id.Value + ",'" +
                                  Paint + "','" +
                                  Math.Round((float)SetPaintTemp.Value, 0) + "');").DB_Input();
            
           
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_MR WHERE Id = " + MR_Id.Value.ToString() + "; ").DB_Output();         
            int RecipesCoating_Id = (int)DT.Rows[0]["C" + ((short)ActualLayer.Value + 1).ToString() + "_Id"];
            
            DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                                             "FROM Recipes_Coating " +
                                             "WHERE Id = " + RecipesCoating_Id + ";").DB_Output();

            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO Recipes_Coating (Order_Id, Box_Id, Charge_Id, Run_Id, Name, Description, LastChanged, [User], VWRecipe) " +
                                  "VALUES (" +
                                  run.Order_Id + "," +
                                  run.Box_Id + "," +
                                  run.Charge_Id + "," +
                                  Run_Id.Value + ",'" +
                                  DT.Rows[0]["Name"] + "','" +
                                  (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "','" +
                                  ((DateTime)DT.Rows[0]["LastChanged"]).ToString("yyyyMMdd HH:mm:ss") + "','" +
                                  (string)DT.Rows[0]["User"] + "','" +
                                  (string)DT.Rows[0]["VWRecipe"] + "');").DB_Input();
        }

        private void WriteActualValuesToRun(Run run)
        {
            new MSSQLEAdapter("Orders", "INSERT " +
                                  "INTO ActualValues (Order_Id, Box_Id, Charge_Id, Run_Id, PaintTemp) " +
                                  "VALUES (" +
                                  run.Order_Id + "," +
                                  run.Box_Id + "," +
                                  run.Charge_Id + "," +
                                  run.Id + ",'" +
                                  Math.Round((float)ActualPaintTemp.Value, 0) + "');").DB_Input();

        }

        private void WriteErrorsToRun(Run run)
        {
            IAlarmItem[] TT = CurrentAlarmList.Alarms.Where(x => x.Group.Name == "Errors" && x.AlarmState == AlarmState.Active && x.Param2 >= StartError && x.Param2 <= EndError).ToArray();

            if (TT.Length != 0)
                foreach (IAlarmItem AI in TT)
                {
                    bool result = new MSSQLEAdapter("Orders", "INSERT " +
                                                    "INTO Errors (Order_Id, Box_Id, Charge_Id, Run_Id, Error, ActivationTime, DeactivationTime, LocalizableText, [User]) " +
                                                    "VALUES (" +
                                                    run.Order_Id + "," +
                                                    run.Box_Id + "," +
                                                    run.Charge_Id + "," +
                                                    run.Id + ",1,'" +
                                                    AI.ActivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.DeactivationTime.ToString("yyyyMMdd HH:mm:ss") + "','" +
                                                    AI.LocalizableText + "','" +
                                                    ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();
                }
        }


        #endregion

    }
}
