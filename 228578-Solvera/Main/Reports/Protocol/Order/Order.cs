using VisiWin.ApplicationFramework;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HMI.Resources;
using HMI.CO.Reports;
using HMI.CO.General;

namespace HMI.Reports
{
    internal class Order
    {
       

        public ReportConfiguration GetReportConfiguration(string Order_Id)
        {
            string DefaultExportPath = new LocalResources().Paths.Reports.Order;
            string FileName = "Order_";
            string Path = @"Main\Reports\Protocol\Order\Order.rdlc";

            DataTable Orders = new MSSQLEAdapter("Orders", "SELECT * FROM Orders WHERE Id = " + Order_Id).DB_Output();

            FileName += Orders.Rows.Count > 0 ? Orders.Rows[0]["Data_2"].ToString() : "XXX";
            DataTable GetCharges = new MSSQLEAdapter("Orders", "SELECT " +
                "Boxes.Box," +
                "Recipes_MR.[Name], " +
                "Charges.Charge, " +
                "[Charges].[Weight], " +
                "[Charges].IsOptimized, " +
                "[Charges].Runs, " +
                "[Charges].[Start], " +
                "[Charges].[End], " +
                "[Charges].[User] " +
                "FROM[VisiWin#Orders].[dbo].[Charges] " +
                "INNER JOIN[VisiWin#Orders].[dbo].Boxes " +
                "ON[Charges].Box_Id = Boxes.Id "+
                "INNER JOIN[VisiWin#Orders].[dbo].Recipes_MR "+
	            "ON Boxes.MR_Id = Recipes_MR.Id "+
                "WHERE[Charges].Order_Id = "+ Order_Id + "; ").DB_Output();

            var config = new ReportConfiguration
            {
                Path = Path,
                DefaultExportPath = DefaultExportPath,
                FileName = FileName
            };

            config.DataSources.Add(new ReportDataSource("Order", Orders));
            config.DataSources.Add(new ReportDataSource("GetCharges", GetCharges));
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
                                                                                             new ParameterInfo("Order", "@Reports.Text4"),
                                                                                             new ParameterInfo("Batch", "@Reports.Text5"),
                                                                                             new ParameterInfo("Item", "@Reports.Text6"),
                                                                                              new ParameterInfo("MR", "@Reports.Text10"),
                                                                                              new ParameterInfo("User", "@Reports.Text9"),
                                                                                               new ParameterInfo("Weight", "@Reports.Text8"),
                                                                                             new ParameterInfo("Boxes", "@Reports.Text7"),
                                                                                             new ParameterInfo("Charge", "@Reports.Text11"),
                                                                                               new ParameterInfo("Optimized", "@Reports.Text13"),
                                                                                               new ParameterInfo("Runs", "@Reports.Text14"),
                                                                                                 new ParameterInfo("Start", "@Reports.Text2"),
                                                                                             new ParameterInfo("End", "@Reports.Text3"),
                                                                                              new ParameterInfo("Box", "@Reports.Text12")
                                                                                              
                                                                                           
                                                                                            
                                                                                            
                                                                                             
                                                                                         };
        }
    }
}