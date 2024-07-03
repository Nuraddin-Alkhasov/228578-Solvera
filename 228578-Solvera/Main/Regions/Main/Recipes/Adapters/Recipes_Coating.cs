using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Adapters
{
    [ExportAdapter("Recipes_Coating")]
    public class Recipes_Coating : AdapterBase
    {

        public Recipes_Coating()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

        }

        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        #endregion

        #region - - - Commands - - -



        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }


        #endregion

        #region - - - Methods - - -

        public void LoadCoating(Coating c)
        {
            if (c.Header.Id > 0)
            {
                Coating temp = new Coating();
                ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Visible;
                Task obTask = Task.Run(async () =>
                {
                    File.WriteAllText(Class.CurrentPath + @"\" + c.Header.Name + ".R", c.VWRecipe.Data);

                    await Task.Delay(1500);

                });
                obTask.ContinueWith(x =>
                {
                   
                    Dispatcher.Invoke(async delegate
                    {
                        LoadFromFileToBufferResult result = await Class.LoadFromFileToBufferAsync(c.Header.Name);
                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                          ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Hidden;

                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            UpdateName(c);
        }

        private void UpdateName(Coating c)
        {
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = c.Header;
        }
        #endregion


    }
}