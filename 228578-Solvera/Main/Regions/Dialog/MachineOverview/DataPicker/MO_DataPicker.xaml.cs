using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_DataPicker")]
    public partial class MO_DataPicker
    {

        public MO_DataPicker()
        {
            InitializeComponent();
            DataContext = new Adapters.MO_DataPicker();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}