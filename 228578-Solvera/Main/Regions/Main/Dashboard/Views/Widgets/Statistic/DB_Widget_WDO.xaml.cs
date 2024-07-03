using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using System;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data;
using VisiWin.Language;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using HMI.CO.General;

namespace MI.MainRegion.Dashboard.Widgets
{

    [ExportDashboardWidget("DB_Widget_WDO", "Dashboard.Text16", "@Dashboard.Text13", 1, 2)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DB_Widget_WDO : View
    {
        public DB_Widget_WDO()
        {
            InitializeComponent();

            BackgroundWorker BGW = new BackgroundWorker();
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.RunWorkerAsync();


        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ILanguageService textService = ApplicationService.GetService<ILanguageService>();
            SeriesCollection = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = textService.GetText("@Dashboard.Text30"),
                            Values = new ChartValues<double>
                            {
                                 DataFromSQL[0],
                                 DataFromSQL[1],
                                 DataFromSQL[2],
                                 DataFromSQL[3],
                                 DataFromSQL[4],
                                 DataFromSQL[5],
                                 DataFromSQL[6]
                            }
                        }
                     };
            ObservableCollection<double> temp = CopyArray(SeriesCollection[0].Values);
            Double maxValue = Convert.ToDouble((from x in temp select x).Max());
            Double minValue = Convert.ToDouble((from x in temp select x).Min());


            oy.MaxValue = maxValue == 0 ? 10 : maxValue;
            oy.MinValue = 0;
            oySeparator.Step = Math.Ceiling((oy.MaxValue - oy.MinValue) / 10);
            oxSeparator.Step = 1;

            oy.Title = textService.GetText("@Dashboard.Text30");

            DataContext = this;
            Labels = new[] {
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-6).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-5).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-4).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-3).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-2).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.AddDays(-1).DayOfWeek),
                        textService.GetText("@Lists.Weekdays."+ DateTime.Now.DayOfWeek)
                    };
            chart.Series = SeriesCollection;
        }

        double[] DataFromSQL;
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable d1 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.ToString("yyyyMMdd") + " 00:00:00' AND Start <='" + DateTime.Now.ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d2 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d3 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-2).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-2).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d4 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-3).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-3).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d5 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-4).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-4).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d6 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-5).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-5).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();
            DataTable d7 = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Start >= '" + DateTime.Now.AddDays(-6).ToString("yyyyMMdd") + " 00:00:00' AND Start<='" + DateTime.Now.AddDays(-6).ToString("yyyyMMdd") + " 23:59:59';").DB_Output();

            DataFromSQL = new double[]
            {
                d7.Rows.Count,
                d6.Rows.Count,
                d5.Rows.Count,
                d4.Rows.Count,
                d3.Rows.Count,
                d2.Rows.Count,
                d1.Rows.Count
            };
        }

        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private ObservableCollection<double> CopyArray(IChartValues array)
        {
            ObservableCollection<double> returnValue = new ObservableCollection<double>();

            foreach (object o in array)
            {
                returnValue.Add(Convert.ToDouble(o));
            }

            return returnValue;
        }
        private void Border_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            new ObjectAnimator().OpenDialog(this, border);
        }
    }
}
