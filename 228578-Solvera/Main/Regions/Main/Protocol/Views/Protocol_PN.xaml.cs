using HMI.CO.Reports;
using HMI.Reports;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.MainRegion.Protocol.Views
{
    /// <summary>
    /// Interaction logic for ProtocolPN.xaml
    /// </summary>
    [ExportView("Protocol_PN")]
    public partial class Protocol_PN
    {
        public Protocol_PN()
        {
            InitializeComponent();
            DataContext = new Adapters.Protocol();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Adapters.Protocol P = (Adapters.Protocol)DataContext;

            P.Wait = Visibility.Visible;
            string sql = P.LastSQLQuery;
            string Order_Id = P.SelectedOrder != null ? P.SelectedOrder.Id.ToString() : "-1";
            string Charge_Id = P.SelectedCharge != null ? P.SelectedCharge.Id.ToString() : "-1";

            Task obTask;

            switch (pn_protocol.SelectedPanoramaRegionIndex)
            {

                case 0:
                    obTask = Task.Run(() =>
                    {
                        ReportConfiguration RC = new Orders().GetReportConfiguration(sql);
                        new Report(RC, "-1").Export();
                    });       break;
                case 1:
                    obTask = Task.Run(() =>
                    {
                        ReportConfiguration RC = new Order().GetReportConfiguration(Order_Id);
                        new Report(RC, "-1").Export();
                    }); break;
                case 2:
                    obTask = Task.Run(() =>
                    {
                        ReportConfiguration RC = new Charge().GetReportConfiguration(Charge_Id);
                        new Report(RC, Charge_Id).Export();
                    }); break;
                default:
                    obTask = Task.Run(() => { }); break;

            }

            obTask.ContinueWith(async x =>
            {
                await Task.Delay(1000);
                Application.Current.Dispatcher.Invoke(delegate
                {
                    P.Wait = System.Windows.Visibility.Hidden;
                });
            });
        }

        private void Pn_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            switch (pn_protocol.SelectedPanoramaRegionIndex)
            {
                case 0: header.LocalizableText = "@Protocol.Text1"; break;
                case 1: header.LocalizableText = "@Protocol.Text2"; break;
                case 2: header.LocalizableText = "@Protocol.Text3"; break;
                default:
                    break;
            }
        }
    }
}