
namespace HMI.CO.Trend
{
    public class TrendData
    {

        public TrendData()
        {
        }

        public string ArchiveName { set; get; } = "";
        public string TrendName_1 { set; get; } = "";
        public string CurveTag_1 { set; get; } = "";
        public string TrendName_2 { set; get; } = "";
        public string CurveTag_2 { set; get; } = "";
        public string Header { set; get; } = "";
        public int Min { set; get; } = 0;
        public int Max { set; get; } = 100;
        public string BackViewName { set; get; } = "";
    }
}
