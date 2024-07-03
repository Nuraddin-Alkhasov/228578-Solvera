using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("MR_Browser")]
    public partial class MR_Browser
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public MR_Browser()
        {
            InitializeComponent();

            DataContext = new Adapters.MR_Browser();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}