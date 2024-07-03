using System.Collections.ObjectModel;
using Microsoft.Reporting.WinForms;

namespace HMI.CO.Reports
{
    public class SubReportInfo
    {
        public SubReportInfo()
        {
            this.ReportDataSources = new Collection<ReportDataSource>();
        }

        public Collection<ReportDataSource> ReportDataSources { get; private set; }

        public string ReportName { get; set; }

        public string ReportPath { get; set; }
    }
}