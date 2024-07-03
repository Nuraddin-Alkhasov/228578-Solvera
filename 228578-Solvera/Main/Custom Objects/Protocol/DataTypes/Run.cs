using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace HMI.CO.Protocol
{

    public class Run
    {
        public Run()
        {
        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int Charge_Id { set; get; } = -1;
        public int ActualValues_Id { set; get; } = -1;
        public int SetValues_Id { set; get; } = -1;
        public int RunNr { set; get; } = 0;
        public bool IsError { set; get; } = false;
        public string Start { set; get; } = "";
        public string C_S { set; get; } = "";
        public string C_E { set; get; } = "";
        public string PZ_S { set; get; } = "";
        public string PZ_E { set; get; } = "";
        public int PZTrend_Id { set; get; } = -1;
        public string WZ_S { set; get; } = "";
        public string WZ_E { set; get; } = "";
        public int WZTrend_Id { set; get; } = -1;
        public string HZ_S { set; get; } = "";
        public string HZ_E { set; get; } = "";
        public int HZTrend_Id { set; get; } = -1;
        public string CZ_S { set; get; } = "";
        public string CZ_E { set; get; } = "";
        public int CZTrend_Id { set; get; } = -1;
        public string End { set; get; } = "";
        public string User { set; get; } = "";

        public List<Error> ErrorList { set; get; } = new List<Error>();
        public ActualValues ActualValues { set; get; } = new ActualValues();
        public SetValues SetValues { set; get; } = new SetValues();
        public Trend PZTrend { set; get; } = new Trend();
        public Trend WZTrend { set; get; } = new Trend();
        public Trend HZTrend { set; get; } = new Trend();
        public Trend CZTrend { set; get; } = new Trend();

        public int SelectedTrendId { set; get; } = 1;
        public void FillErrorList()
        {
            List<Error> temp = new List<Error>();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Errors WHERE Run_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Error()
                    {
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = (int)r["Box_Id"],
                        Charge_Id = (int)r["Charge_Id"],
                        Run_Id = Id,
                        ErrorNr = (int)r["Error"],
                        ActivationTime = ((DateTime)r["ActivationTime"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        DeactivationTime = r["DeactivationTime"] == DBNull.Value ? "" : ((DateTime)r["DeactivationTime"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        LocalizableText = (string)r["LocalizableText"],
                        User = (string)r["User"]
                    });

                }
            }
            ErrorList = temp;
        }
        public void FillActualValues(int ActualValue_Id)
        {
            ActualValues temp = new ActualValues();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From ActualValues WHERE Id = " + ActualValue_Id).DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {

                temp = new ActualValues()
                {
                    Id = ActualValue_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    PaintTemp = (float)DT.Rows[0]["PaintTemp"],
                    PHZTempMin = (float)DT.Rows[0]["PZTempMin"],
                    PHZTemp = (float)DT.Rows[0]["PZTemp"],
                    PHZTempMax = (float)DT.Rows[0]["PZTempMax"],
                    WZTempMin = (float)DT.Rows[0]["WZTempMin"],
                    WZTemp = (float)DT.Rows[0]["WZTemp"],
                    WZTempMax = (float)DT.Rows[0]["WZTempMax"],
                    HZTempMin = (float)DT.Rows[0]["HZTempMin"],
                    HZTemp = (float)DT.Rows[0]["HZTemp"],
                    HZTempMax = (float)DT.Rows[0]["HZTempMax"],
                    CZTempMin = (float)DT.Rows[0]["CZTempMin"],
                    CZTemp = (float)DT.Rows[0]["CZTemp"],
                    CZTempMax = (float)DT.Rows[0]["CZTempMax"]
                };

            }
            ActualValues = temp;
        }
        public void FillSetValues(int SetValues_Id)
        {
            SetValues temp = new SetValues();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From SetValues WHERE Id = " + SetValues_Id).DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new SetValues()
                {
                    Id = SetValues_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    PaintType = (string)DT.Rows[0]["PaintType"],
                    PaintTemp = (float)DT.Rows[0]["PaintTemp"],
                    PHZTemp = (float)DT.Rows[0]["PZTemp"],
                    WZTemp = (float)DT.Rows[0]["WZTemp"],
                    HZTemp = (float)DT.Rows[0]["HZTemp"],
                    CZTemp = (float)DT.Rows[0]["CZTemp"],
                };
            }
            SetValues = temp;
        }
        public void FillPZTrend(int Run_Id)
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Run_Id = " + Run_Id + " AND TrendType_Id = 1").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = PZTrend_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            PZTrend = temp;

        }
        public void FillWZTrend(int Run_Id)
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Run_Id = " + Run_Id + " AND TrendType_Id = 2").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = PZTrend_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            WZTrend = temp;

        }
        public void FillHZTrend(int Run_Id)
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Run_Id = " + Run_Id + " AND TrendType_Id = 3").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = PZTrend_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            HZTrend = temp;

        }
        public void FillCZTrend(int Run_Id)
        {
            Trend temp = new Trend();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Trends WHERE Run_Id = " + Run_Id + " AND TrendType_Id = 4").DB_Output();
            Thread.Sleep(20);
            if (DT.Rows.Count > 0)
            {
                temp = new Trend()
                {
                    Id = PZTrend_Id,
                    Order_Id = (int)DT.Rows[0]["Order_Id"],
                    Box_Id = (int)DT.Rows[0]["Box_Id"],
                    Charge_Id = (int)DT.Rows[0]["Charge_Id"],
                    Run_Id = (int)DT.Rows[0]["Run_Id"],
                    TrendType_Id = (int)DT.Rows[0]["TrendType_Id"],
                    Start = DT.Rows[0]["Start"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                    End = DT.Rows[0]["End"] == DBNull.Value ? "" : ((DateTime)DT.Rows[0]["End"]).ToString("dd.MM.yyyy HH:mm:ss")
                };
                temp.SetTrendPoints((string)DT.Rows[0]["Trend"]);
            }
            CZTrend = temp;

        }
    }
}
