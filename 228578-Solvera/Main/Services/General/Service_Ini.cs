using HMI.Interfaces;
using HMI.Services.Custom_Objects;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Services
{
    [ExportService(typeof(IIni))]
    [Export(typeof(IIni))]
    public class Service_Ini : ServiceBase, IIni
    {

        public Service_Ini()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }


        #region OnProject


        protected override void OnLoadProjectStarted()
        {
            new VWSafeStart().DoWork();
            base.OnLoadProjectStarted();
        }

        protected override void OnLoadProjectCompleted()
        {

            InitializeRecipe();
            base.OnLoadProjectCompleted();
        }

        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        private void InitializeRecipe()
        {
            IRecipeClass T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Article");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");
            T.StartEdit();
        }

        #endregion

    }
}
