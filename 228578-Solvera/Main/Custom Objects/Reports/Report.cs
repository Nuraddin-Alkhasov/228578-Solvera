using HMI.CO.General;
using HMI.CO.Reports;
using HMI.Resources;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.CO.Reports
{
    class Report
    {
        ReportConfiguration RC { get; set; }
        string Charge_Id { get; set; } = "-1";
        public Report(ReportConfiguration rc, string charge_Id) 
        {
            RC = rc;
            Charge_Id = charge_Id;
        }

        public void Export() 
        {
            using (var localReport = new LocalReport())
            {
                using (var fs = new FileStream(System.IO.Path.GetFullPath(RC.Path), FileMode.Open, FileAccess.Read))
                {
                    localReport.LoadReportDefinition(fs);
                }

                foreach (var subReport in RC.SubReportInfos)
                {
                    localReport.SubreportProcessing += new SubreportProcessingEventHandler(this.CreateEventHandlerFor(subReport));
                    using (var fs = new FileStream(System.IO.Path.GetFullPath(subReport.ReportPath), FileMode.Open, FileAccess.Read))
                    {
                        localReport.LoadSubreportDefinition(subReport.ReportName, fs);
                    }
                }
                foreach (var rds in RC.DataSources)
                {
                    localReport.DataSources.Add(rds);
                }
                
                localReport.SetParameters(RC.ReportParameters);
                byte[] renderedReport = new byte[] { new byte() };
                try
                {
                    renderedReport = localReport.Render("PDF");
                }
                catch
                {

                }

                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(RC.DefaultExportPath));

                string ExportFileName = RC.FileName + ".pdf";
                PrepareFile(RC.DefaultExportPath + ExportFileName);

                try
                {
                    using (var fs = new FileStream(RC.DefaultExportPath + ExportFileName, FileMode.CreateNew, FileAccess.Write))
                    {
                       fs.Write(renderedReport, 0, renderedReport.Length);
                       fs.Flush();
                    }
                }
                catch
                {
                    
                }

            }

            if (Charge_Id != "-1") 
            {
                DataTable Runs = new MSSQLEAdapter("Orders", "SELECT " +
                 "Runs.Run, " +
                 "Recipes_Coating.VWRecipe, " +
                 "Runs.PZTrend_Id, " +
                 "Runs.WZTrend_Id, " +
                 "Runs.HZTrend_Id, " +
                 "Runs.CZTrend_Id " +
                 "FROM[VisiWin#Orders].[dbo].Runs " +
                 "INNER JOIN[VisiWin#Orders].[dbo].SetValues " +
                 "ON[SetValues].Run_Id = Runs.Id " +
                 "INNER JOIN[VisiWin#Orders].[dbo].Recipes_Coating " +
                 "ON[SetValues].RecipeCoating_Id = Recipes_Coating.Id " +
                 "WHERE[SetValues].Charge_Id = " + Charge_Id).DB_Output();

                foreach (DataRow r in Runs.Rows)
                {
                    string TempName = RC.DefaultExportPath + RC.FileName + "_R_" + r["Run"].ToString() + "_VWRecipe.xml";
                    PrepareFile(TempName);
                    File.WriteAllText(TempName, r["VWRecipe"].ToString());

                    DataTable PZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE Id = " + r["PZTrend_Id"].ToString()).DB_Output();
                    if (PZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_R_" + r["Run"].ToString() + "_PZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, PZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable WZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE Id = " + r["WZTrend_Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_R_" + r["Run"].ToString() + "_WZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, WZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable HZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE Id = " + r["HZTrend_Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_R_" + r["Run"].ToString() + "_HZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, HZ.Rows[0]["Trend"].ToString());
                    }

                    DataTable CZ = new MSSQLEAdapter("Orders", "SELECT * FROM Trends WHERE Id = " + r["CZTrend_Id"].ToString()).DB_Output();
                    if (WZ.Rows.Count > 0)
                    {
                        TempName = RC.DefaultExportPath + RC.FileName + "_R_" + r["Run"].ToString() + "_CZTrend.csv";
                        PrepareFile(TempName);
                        File.WriteAllText(TempName, CZ.Rows[0]["Trend"].ToString());
                    }
                }
            }
         
        } 

        private Action<object, SubreportProcessingEventArgs> CreateEventHandlerFor(SubReportInfo sri)
        {
            return (sender, e) =>
            {
                if (e.ReportPath == sri.ReportName)
                {
                    e.DataSources.Clear();
                    foreach (var rds in sri.ReportDataSources)
                    {
                        e.DataSources.Add(rds);
                    }
                }
            };
        }

        private void PrepareFile(string s) 
        {
            if (File.Exists(s))
            {
                File.Delete(s);
            }
        }

    }
}
