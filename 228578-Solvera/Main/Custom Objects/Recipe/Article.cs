using HMI.CO.General;
using HMI.CO.Protocol;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class Article
    {

        public Article()
        {
        }

        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public ArticleInfo Info { get; set; } = new ArticleInfo();
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();
        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempArticle.R", VWRecipe.Data);

            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempArticle");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                new MessageBoxTask("@MachineOverview.Text103", "@MachineOverview.Text102", MessageBoxIcon.Exclamation);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Loaded", true);
            }

        }
        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }
    }
}
