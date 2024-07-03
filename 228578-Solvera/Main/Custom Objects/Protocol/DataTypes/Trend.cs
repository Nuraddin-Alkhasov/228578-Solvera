using System;
using System.Collections.Generic;

namespace HMI.CO.Protocol
{
    public class Trend
    {

        public Trend()
        {
        }
        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int Charge_Id { set; get; } = -1;
        public int Run_Id { set; get; } = -1;
        public int TrendType_Id { set; get; } = -1;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";

        public List<Point> Points = new List<Point>();

        public void SetTrendPoints(string text)
        {
            if (text.Length > 0)
            {
                string[] t1 = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string s in t1)
                {
                    string[] t2 = s.Split(';');
                    if (s.Length > 0)
                    {
                        Points.Add(new Point() { TimeStamp = DateTime.Parse(t2[0]), Value = Convert.ToDouble(t2[1]) });

                    }
                }
            }
        }


    }
    public class Point
    {
        public DateTime TimeStamp = DateTime.MinValue;
        public double Value = 0;
    }
}
