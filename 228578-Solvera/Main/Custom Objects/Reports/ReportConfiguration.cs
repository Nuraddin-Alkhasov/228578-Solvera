using System.Collections.ObjectModel;
using Microsoft.Reporting.WinForms;

namespace HMI.CO.Reports
{
    public class ReportConfiguration
    {
        public ReportConfiguration()
        {
            this.DataSources = new Collection<ReportDataSource>();
            this.ReportParameters = new Collection<ReportParameter>();
            this.SubReportInfos = new Collection<SubReportInfo>();
        }

        public Collection<ReportDataSource> DataSources { get; private set; }
        public string DefaultExportPath { get; set; }
        public string FileName { get; set; }
        public Collection<ReportParameter> ReportParameters { get; private set; }
        public string Path { get; set; }
        public Collection<SubReportInfo> SubReportInfos { get; private set; }
    }
}