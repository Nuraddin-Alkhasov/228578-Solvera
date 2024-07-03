using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using System;
using System.ComponentModel;
using LiveCharts;
using System.Windows.Media;
using System.Data;
using VisiWin.Language;
using HMI.CO.General;

namespace HMI.MainRegion.Dashboard.Widgets
{
    /// <summary>
    /// Interaction logic for DashboardWidgetBar.xaml
    /// </summary>
    [ExportDashboardWidget("DB_Widget_TY", "Dashboard.Text15", "@Dashboard.Text13", 1, 2)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_TYC : View
    {
        public DB_Widget_TYC()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();

            BackgroundWorker BGW = new BackgroundWorker();
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.RunWorkerAsync();



        }
        double[] DataFromSQL = new double[2];
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable D1 = new MSSQLEAdapter("Orders", "SELECT Count(Id) as Charges " +
                                    "FROM Charges " +
                                    "WHERE Start >= '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd ") + "00:00:00' AND Start<='" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd ") + "23:59:59'; ").DB_Output();
            DataTable D2 = new MSSQLEAdapter("Orders", "SELECT Count(Id) as Charges " +
                                                 "FROM Charges " +
                                                 "WHERE Start >= '" + DateTime.Now.ToString("yyyyMMdd ") + "00:00:00' AND Start<='" + DateTime.Now.ToString("yyyyMMdd ") + "23:59:59'; ").DB_Output();
            DataFromSQL[0] = D1.Rows.Count == 0
                ? 0
                : D1.Rows[0]["Charges"] != System.DBNull.Value ? Math.Round(Convert.ToDouble(D1.Rows[0]["Charges"]), 1) : 0;

            DataFromSQL[1] = D2.Rows.Count == 0
                ? 0
                : D2.Rows[0]["Charges"] != System.DBNull.Value ? Math.Round(Convert.ToDouble(D2.Rows[0]["Charges"]), 1) : 0;
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (pieeee != null)
            {
                PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                pieeee.ChartLegend.FontSize = 14;
                pieeee.ChartLegend.Foreground = Brushes.White;
                DataContext = this;
                ILanguageService textService = ApplicationService.GetService<ILanguageService>();

                pieeee.Series[0].Values[0] = DataFromSQL[0];
                pieeee.Series[1].Values[0] = DataFromSQL[1];

                notToday.Title = textService.GetText("@Dashboard.Text26");
                Today.Title = textService.GetText("@Dashboard.Text1");

            }
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}
