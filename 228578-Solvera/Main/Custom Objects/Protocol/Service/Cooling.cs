using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.Alarm;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Trend;

namespace HMI.CO.Protocol
{
    class Cooling
    {
        public Cooling(string _Start, string _End, string _Error)
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

        ITrendService trendService = ApplicationService.GetService<ITrendService>();
        IArchive TrendArchive;

        ICurrentAlarms2 CurrentAlarmList = ApplicationService.GetService<IAlarmService>().GetCurrentAlarms2();

        IVariable Start;
        IVariable End;
        IVariable Error;
        public IVariable Index { set; get; }
        public IVariable TH_Run_Id { set; get; }
        public List<IVariable> CZ_Run_Ids { set; get; } = new List<IVariable>();
        public int StartError { set; get; }
        public int EndError { set; get; }
        public IVariable SetCZTemp { set; get; }

        #endregion

        #region - - - Event Handlers - - - 
        private void Start_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Start.Value = false;
                Task.Run(() =>
                {
                    Run r = GetRun((int)(uint)CZ_Run_Ids[CZ_Run_Ids.Count-1].Value);
                    if (r.Id > 0)
                    {
                        WriteDateTimeToRun("CZ_S", r);
                        WriteSetValuesToRun(r);

                    }
                });
            }
        }

        private void End_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                End.Value = false;
                 
                   Run r = GetRun((int)(uint)TH_Run_Id.Value);
                    if (r.Id > 0)
                    {
                        WriteDateTimeToRun("CZ_E", r);
                    if ((short)Index.Value >= 0 && (short)Index.Value <= 1) 
                    {
                        TrendArchive = trendService.GetArchive("CZ1");

                    }
                    if ((short)Index.Value >= 2 && (short)Index.Value <= 3)
                    {
                        TrendArchive = trendService.GetArchive("CZ2");

                    }
                    if ((short)Index.Value >= 4 && (short)Index.Value <= 5)
                    {
                        TrendArchive = trendService.GetArchive("CZ3");

                    }
                    if ((short)Index.Value >= 6 && (short)Index.Value <= 7)
                    {
                        TrendArchive = trendService.GetArchive("CZ4");
                    }

                    if (TrendArchive != null) 
                    {
                        TrendArchive.GetTrendsDataCompleted += WriteActualValuesToRun;
                        
                        r.CZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                        if (r.CZ_S != "" && r.CZ_E != "")
                            TrendArchive.GetTrendsDataAsync(
                            TrendArchive.TrendNames.ToArray(),
                            DateTime.ParseExact(r.CZ_S, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture),
                            DateTime.ParseExact(r.CZ_E, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture), null, 0);

                    }
                }
                
            }
        }

        private void Error_Event(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Error.Value = false;
                Task.Run(() =>
                {
                    foreach (IVariable v in CZ_Run_Ids)
                    {
                        if ((int)(uint)v.Value > 0)
                        {
                            Run r = GetRun((int)(uint)v.Value);
                            if (r.Id > 0)
                                WriteErrorsToRun(r);
                        }
                    }
                });
            }
        }


        private void WriteActualValuesToRun(object sender, GetTrendsDataCompletedEventArgs e)
        {
            IDataSample[] Data = e.Data[0];
            Task.Run(() =>
            {
                double CZTempMin = Math.Round(Convert.ToDouble(Data[0].YValue), 1);
                double CZTemp = (double)Data[0].YValue;
                double CZTempMax = CZTempMin;
                string trend = "";
                for (int i = 0; i <= Data.Length - 1; i++)
                {
                    string time = ((DateTime)Data[i].XValue).ToString("HH:mm:ss");
                    double value = Math.Round(Convert.ToDouble(Data[i].YValue), 1);

                    if (value < CZTempMin) { CZTempMin = value; }
                    if (value > CZTempMax) { CZTempMax = value; }
                    CZTemp += value;

                    trend += time + ";";
                    trend += value + Environment.NewLine;
                }
                CZTemp = CZTemp / Data.Length;
                Run r = GetRun((int)(uint)TH_Run_Id.Value);

                
                new MSSQLEAdapter("Orders", "Update ActualValues " +
                                    "SET " +
                                    "CZTempMin = " + Math.Round(CZTempMin, 0) + ", " +
                                    "CZTemp = " + Math.Round(CZTemp, 0) + ", " +
                                    "CZTempMax = " + Math.Round(CZTempMax, 0) + " " +
                                    "WHERE Id = " + r.ActualValues_Id + ";").DB_Input();
               
                new MSSQLEAdapter("Orders", "INSERT " +
                            "INTO Trends " +
                            "(Order_Id, Box_Id, Charge_Id, Run_Id, TrendType_Id, Trend, [Start], [End]) " +
                            "VALUES (" +
                            r.Order_Id + "," +
                            r.Box_Id + "," +
                            r.Charge_Id + "," +
                            r.Id + ",4,'" +
                            trend + "','" +
                            r.CZ_S + "','" +
                            r.CZ_E + "')").DB_Input();
               
            });
            TrendArchive.GetTrendsDataCompleted -= WriteActualValuesToRun;
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
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    SetValues_Id = (int)DT.Rows[0]["SetValues_Id"],
                    ActualValues_Id = (int)DT.Rows[0]["ActualValues_Id"],
                    CZ_S = DT.Rows[0]["CZ_S"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["CZ_S"]).ToString("yyyyMMdd HH:mm:ss"),
                    CZ_E = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
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
            new MSSQLEAdapter("Orders", "Update SetValues " +
                                  "SET CZTemp = " + Math.Round((float)SetCZTemp.Value, 0) + " " +
                                  "WHERE Id = " + run.SetValues_Id + " ;").DB_Input();

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
