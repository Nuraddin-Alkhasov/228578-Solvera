using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("Coating_Selector")]
    public partial class Coating_Selector
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public Coating_Selector()
        {
            InitializeComponent();

            DataContext = new Adapters.Coating_Selector();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}