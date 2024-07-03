using HMI.Resources.UserControls;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;


namespace HMI.MainRegion.Recipes.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    [ExportView("Recipes_Article")]
    public partial class Recipes_Article
    {
        public Recipes_Article()
        {
            InitializeComponent();
            DataContext = new Adapters.Recipes_Article();
        }

        ArticleGeneral ag;
        ArticleRecipe ar;

        public void LoadArticle()
        {
            Task t1 = Task.Run(async () =>
            {
                await Task.Delay(0);
                await Dispatcher.InvokeAsync(delegate
                {
                    ag = new ArticleGeneral();
                    stack.Children.Add(ag);
                });
            });
            t1.ContinueWith(x1 =>
            {
                Task t2 = Task.Run(async () =>
                {
                    await Task.Delay(200);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        ar = new ArticleRecipe();
                        stack.Children.Add(ar);
                    });
                });

            }, TaskContinuationOptions.OnlyOnRanToCompletion);


        }
        public void UnloadArticle()
        {
            Task.Run(() =>
            {
                Dispatcher.InvokeAsync(delegate
                {
                    stack.Children.Remove(ag);
                    stack.Children.Remove(ar);
                });
            });

        }

    }
}