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
    internal class Charge
    {
       
        public ReportConfiguration GetReportConfiguration(string Charge_Id)
        {
            string DefaultExportPath = new LocalResources().Paths.Reports.Charge;
            string FileName = "Order_";
            string Path = @"Main\Reports\Protocol\Charge\Charge.rdlc";


           
            DataTable Charges = new MSSQLEAdapter("Orders", "SELECT * FROM Charges WHERE Id = " + Charge_Id).DB_Output();
            
            string Order_Id = Charges.Rows.Count > 0 ? Charges.Rows[0]["Order_Id"].ToString() : "-1";
            DataTable Orders = new MSSQLEAdapter("Orders", "SELECT * FROM Orders WHERE Id = " + Order_Id).DB_Output();

            FileName += Orders.Rows.Count > 0 ? Orders.Rows[0]["Data_2"].ToString() : "XXX";

            string Box_Id = Charges.Rows.Count > 0 ? Charges.Rows[0]["Box_Id"].ToString() : "-1";
            DataTable Boxes = new MSSQLEAdapter("Orders", "SELECT * FROM Boxes WHERE Id = " + Box_Id).DB_Output();

            FileName += Boxes.Rows.Count > 0 ? "_Box_" + Boxes.Rows[0]["Box"].ToString() : "_Box_0";
            FileName += Charges.Rows.Count > 0 ? "_Charge_" + Charges.Rows[0]["Charge"].ToString() : "_Charge_0";

            string MR_Id = Boxes.Rows.Count > 0 ? Boxes.Rows[0]["MR_Id"].ToString() : "-1";
            DataTable Recipes_MR = new MSSQLEAdapter("Orders", "SELECT * FROM Recipes_MR WHERE Id = " + MR_Id).DB_Output();

            DataTable Runs = new MSSQLEAdapter("Orders", "SELECT * FROM Runs WHERE Charge_Id = " + Charge_Id).DB_Output();

            DataTable Errors = new MSSQLEAdapter("Orders", "SELECT * FROM Errors WHERE Charge_Id = " + Charge_Id).DB_Output();

            foreach (DataRow r in Errors.Rows) 
            {
                r["LocalizableText"] = ApplicationService.GetText(r["LocalizableText"].ToString());
            }

            DataTable GetSetValues = new MSSQLEAdapter("Orders", "SELECT " +
                "Runs.Run, " +
                "[SetValues].PaintType, " +
                "[SetValues].PaintTemp, " +
                "[SetValues].PZTemp, " +
                "[SetValues].WZTemp, " +
                "[SetValues].HZTemp, " +
                "[SetValues].CZTemp " +
                "FROM[VisiWin#Orders].[dbo].[SetValues] " +
                "INNER JOIN[VisiWin#Orders].[dbo].Runs " + 
                "ON[SetValues].Run_Id = Runs.Id " +
                "WHERE[SetValues].Charge_Id = "+ Charge_Id).DB_Output();

            DataTable GetActualValues = new MSSQLEAdapter("Orders", "SELECT " +
                 "Runs.Run, " +
                 "[ActualValues].PaintTemp, " +
                 "[ActualValues].PZTemp, " +
                 "[ActualValues].WZTemp, " +
                 "[ActualValues].HZTemp, " +
                 "[ActualValues].CZTemp " +
                 "FROM [VisiWin#Orders].[dbo].[ActualValues] " +
                 "INNER JOIN [VisiWin#Orders].[dbo].Runs " +
                 "ON [ActualValues].Run_Id = Runs.Id " +
                 "WHERE [ActualValues].Charge_Id = " + Charge_Id).DB_Output();

            var config = new ReportConfiguration
            {
                Path = Path,
                DefaultExportPath = DefaultExportPath,
                FileName = FileName
            };

            config.DataSources.Add(new ReportDataSource("Order", Orders));
            config.DataSources.Add(new ReportDataSource("Boxes", Boxes));
            config.DataSources.Add(new ReportDataSource("Recipes_MR", Recipes_MR));
            config.DataSources.Add(new ReportDataSource("Charges", Charges));
            config.DataSources.Add(new ReportDataSource("Runs", Runs));
            config.DataSources.Add(new ReportDataSource("Errors", Errors));
            config.DataSources.Add(new ReportDataSource("GetActualValues", GetActualValues));
            config.DataSources.Add(new ReportDataSource("GetSetValues", GetSetValues));
           
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
                new ParameterInfo("Box", "@Reports.Text12"),
                new ParameterInfo("Charge", "@Reports.Text11"),
                new ParameterInfo("Weight", "@Reports.Text8"),
                new ParameterInfo("Run", "@Reports.Text15"),
                new ParameterInfo("Start", "@Reports.Text2"),
                new ParameterInfo("End", "@Reports.Text3"),
                new ParameterInfo("CS", "@Reports.Text18"),
                new ParameterInfo("CE", "@Reports.Text19"), 
                new ParameterInfo("PZS", "@Reports.Text24"),
                new ParameterInfo("PZE", "@Reports.Text25"),
                new ParameterInfo("WZS", "@Reports.Text20"),
                new ParameterInfo("WZE", "@Reports.Text21"),
                new ParameterInfo("HZS", "@Reports.Text22"),
                new ParameterInfo("HZE", "@Reports.Text23"),
                new ParameterInfo("CZS", "@Reports.Text16"),
                new ParameterInfo("CZE", "@Reports.Text17"),
                new ParameterInfo("SetValues", "@Reports.Text26"),
                new ParameterInfo("PaintType", "@Reports.Text28"),
                new ParameterInfo("PaintTemp", "@Reports.Text29"),
                new ParameterInfo("PZ", "@Reports.Text30"),
                new ParameterInfo("WZ", "@Reports.Text31"),
                new ParameterInfo("HZ", "@Reports.Text32"),
                new ParameterInfo("CZ", "@Reports.Text33"),
                new ParameterInfo("ActualValues", "@Reports.Text27"),
                new ParameterInfo("Errors", "@Reports.Text34"),
                new ParameterInfo("Nr", "@Reports.Text35"),
                new ParameterInfo("ActivationTime", "@Reports.Text37"),
                new ParameterInfo("DeactivationTime", "@Reports.Text38"),
                new ParameterInfo("Error", "@Reports.Text36")
            }; 
        }
    }
}