using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.DialogRegion.Recipes.Views
{

    [ExportView("Recipe_Selector")]
    public partial class Recipe_Selector
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public Recipe_Selector()
        {
            InitializeComponent();

            DataContext = new Adapters.Recipe_Selector();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

    }
}