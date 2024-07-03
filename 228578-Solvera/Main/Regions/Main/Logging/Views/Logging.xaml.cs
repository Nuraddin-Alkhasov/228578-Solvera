
using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.MainRegion.Logging.Views
{
    /// <summary>
    /// Interaction logic for AlarmHistoryView.xaml
    /// </summary>
    [ExportView("Logging")]
    public partial class Logging
    {
        public Logging()
        {
            InitializeComponent();
            DataContext = new Adapters.Logging();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}