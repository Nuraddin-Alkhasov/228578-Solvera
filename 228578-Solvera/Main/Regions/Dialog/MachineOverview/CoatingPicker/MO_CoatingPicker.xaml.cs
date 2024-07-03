using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.MO.Views
{

    [ExportView("MO_CoatingPicker")]
    public partial class MO_CoatingPicker
    {

        public MO_CoatingPicker()
        {
            InitializeComponent();
            DataContext = new Adapters.MO_CoatingPicker();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}