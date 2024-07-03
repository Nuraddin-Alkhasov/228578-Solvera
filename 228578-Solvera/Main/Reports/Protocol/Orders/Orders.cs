using VisiWin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HMI.CO.Reports;
using HMI.CO.General;
using System.Data;
using HMI.Resources;
using System;

namespace HMI.Reports
{
    internal class Orders
    {

        public ReportConfiguration GetReportConfiguration(string sql)
        {    
            string DefaultExportPath = new LocalResources().Paths.Reports.Orders;
            string FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string Path = @"Main\Reports\Protocol\Orders\Orders.rdlc";
        
            DataTable Orders = new MSSQLEAdapter("Orders", sql).DB_Output();

            var config = new ReportConfiguration
            {
                Path = Path,
                DefaultExportPath = DefaultExportPath,
                FileName = FileName
            };

            config.DataSources.Add(new ReportDataSource("GetOrders", Orders));

            foreach (var paraInfo in Parameters.LocalizableParameter)
            {
                config.ReportParameters.Add(new ReportParameter(paraInfo.Name, ApplicationService.GetText(paraInfo.LocaliableString)));
            }

            return config;
            
         
        }

        private class Parameters
        {
            public static readonly IEnumerable<ParameterInfo> LocalizableParameter = new Collection<ParameterInfo>
                                                                                         {
                                                                                             new ParameterInfo("Orders", "@Reports.Text1"),
                                                                                             new ParameterInfo("Start", "@Reports.Text2"),
                                                                                             new ParameterInfo("End", "@Reports.Text3"),
                                                                                             new ParameterInfo("Order", "@Reports.Text4"),
                                                                                             new ParameterInfo("Batch", "@Reports.Text5"),
                                                                                             new ParameterInfo("Item", "@Reports.Text6"),
                                                                                             new ParameterInfo("Boxes", "@Reports.Text7"),
                                                                                             new ParameterInfo("Weight", "@Reports.Text8"),
                                                                                             new ParameterInfo("User", "@Reports.Text9")
                                                                                         };
        }
    }
}