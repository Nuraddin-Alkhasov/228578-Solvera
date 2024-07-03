using System;
using VisiWin.ApplicationFramework;

namespace HMI.CO.Recipe
{
    public class RecipeInfo
    {

        public RecipeInfo()
        {
        }

        public int Id { set; get; } = -1;
        public string Name { set; get; } = "";
        public string Description { set; get; } = "";
        public string LastChanged { get; set; } = "";
        public string User { get; set; } = "";

    }
}
