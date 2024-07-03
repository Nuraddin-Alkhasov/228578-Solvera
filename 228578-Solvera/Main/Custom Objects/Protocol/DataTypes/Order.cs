using HMI.CO.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading;
using VisiWin.ApplicationFramework;

namespace HMI.CO.Protocol
{
    public class Order : AdapterBase
    {
        public Order()
        {
        }

        public int Id { set; get; } = -1;
        public string Data_1 { set; get; } = "";
        public string Data_2 { set; get; } = "";
        public string Data_3 { set; get; } = "";
        public bool IsError { set; get; } = false;
        public int Boxes { set; get; } = 0;
        public float Weight { set; get; } = 0;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";
        public List<Box> BoxList { set; get; } = new List<Box>();

        public void FillBoxList()
        {
            List<Box> temp = new List<Box>();
            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Boxes WHERE Order_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Box((int)r["MR_Id"])
                    {
                        Id = (int)r["Id"],
                        Order_Id = Id,
                        Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        BoxNr = (int)r["Box"],
                        Charges = (int)r["Charges"],
                        Weight = (float)r["Weight"],
                        IsError = (bool)r["IsError"],
                        User = (string)r["User"]
                    });

                }
            }
            BoxList = temp;
        }

    }
}
