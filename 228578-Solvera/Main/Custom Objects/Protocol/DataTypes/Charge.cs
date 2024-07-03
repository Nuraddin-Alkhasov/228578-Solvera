using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;

namespace HMI.CO.Protocol
{

    public class Charge : AdapterBase
    {
        public Charge()
        {

        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int ChargeNr { set; get; } = 0;
        public float Weight { set; get; } = 0;
        public bool IsOptimized { set; get; } = false;
        public int Runs { set; get; } = 0;
        public bool IsError { set; get; } = false;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";

        public List<Run> RunList { set; get; } = new List<Run>();

        public void FillRunList()
        {
            List<Run> temp = new List<Run>();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Runs WHERE Charge_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Run()
                    {
                        Id = (int)r["Id"],
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = (int)r["Box_Id"],
                        Charge_Id = Id,
                        ActualValues_Id = (int)r["ActualValues_Id"],
                        SetValues_Id = (int)r["SetValues_Id"],
                        IsError = (bool)r["IsError"],
                        RunNr = (int)r["Run"],
                        Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        C_S = r["C_S"] == DBNull.Value ? "" : ((DateTime)r["C_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        C_E = r["C_E"] == DBNull.Value ? "" : ((DateTime)r["C_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        PZ_S = r["PZ_S"] == DBNull.Value ? "" : ((DateTime)r["PZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        PZ_E = r["PZ_E"] == DBNull.Value ? "" : ((DateTime)r["PZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        PZTrend_Id = (int)r["PZTrend_Id"],
                        WZ_S = r["WZ_S"] == DBNull.Value ? "" : ((DateTime)r["WZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        WZ_E = r["WZ_E"] == DBNull.Value ? "" : ((DateTime)r["WZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        WZTrend_Id = (int)r["WZTrend_Id"],
                        HZ_S = r["HZ_S"] == DBNull.Value ? "" : ((DateTime)r["HZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        HZ_E = r["HZ_E"] == DBNull.Value ? "" : ((DateTime)r["HZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        HZTrend_Id = (int)r["HZTrend_Id"],
                        CZ_S = r["CZ_S"] == DBNull.Value ? "" : ((DateTime)r["CZ_S"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        CZ_E = r["CZ_E"] == DBNull.Value ? "" : ((DateTime)r["CZ_E"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        CZTrend_Id = (int)r["CZTrend_Id"],
                        End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        User = (string)r["User"]
                    });

                }
            }
            RunList = temp;
        }


    }
}
