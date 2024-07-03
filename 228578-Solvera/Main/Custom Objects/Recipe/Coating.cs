using HMI.CO.General;
using HMI.Resources;
using System;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class Coating
    {
        public Coating()
        {
        }

        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public int Paint_Id { set; get; } = -1;
        public VWRecipe VWRecipe { set; get; } = new VWRecipe();

        public async Task LoadToPLC()
        {
            IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass(VWRecipe.Class);

            File.WriteAllText(Class.CurrentPath + @"\TempCoating.R", VWRecipe.Data);
            LoadFromFileToProcessResult result = await Class.LoadFromFileToProcessAsync("TempCoating");
            if (result.Result != SendRecipeResult.Succeeded)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from PC.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
            }
            else
            {
                //new MessageBoxTask("@RecipeSystem.Results.LoadOK", "@RecipeSystem.Results.Text2", MessageBoxIcon.Information);
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Handshake.from PC.Loaded", true);
            }

        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }
    }
}
