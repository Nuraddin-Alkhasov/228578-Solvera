using System;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.MainRegion.Recipes.Views
{
    [ExportView("Recipes_PN")]
    public partial class Recipes_PN
    {
        public Recipes_PN()
        {
            InitializeComponent();
            DataContext = new Adapters.Recipes_PN();
         
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(new Resources.LocalResources().Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }
    }
}
