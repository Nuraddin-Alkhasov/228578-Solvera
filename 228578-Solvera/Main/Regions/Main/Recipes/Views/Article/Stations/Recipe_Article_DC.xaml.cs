using HMI.CO.General;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.Recipes.Views
{

    [ExportView("Recipe_Article_DC")]
    public partial class Recipe_Article_DC
    {

        public Recipe_Article_DC()
        {
            this.InitializeComponent();
        }
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

    }
}