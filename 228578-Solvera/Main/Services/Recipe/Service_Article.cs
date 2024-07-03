using HMI.CO.General;
using HMI.CO.Protocol;
using HMI.CO.Recipe;
using HMI.Interfaces;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Services
{
    [ExportService(typeof(IArticle))]
    [Export(typeof(IArticle))]
    public class Service_H_LiftTiltingDevice : ServiceBase, IArticle
    {
        IVariableService VS;
        IVariable AToPLC;


        public Service_H_LiftTiltingDevice()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region - - - OnProject - - - 


        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            VS = ApplicationService.GetService<IVariableService>();
            AToPLC = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.to PC.GetRecipe");
            AToPLC.Change += AToPLC_Change;

            base.OnLoadProjectCompleted();
        }

        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        #endregion

        #region - - - Event Handlers - - -

        void AToPLC_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue && bool.Parse(e.Value.ToString()))
            {
                AToPLC.Value = false;
                Task obTask = Task.Run(async () =>
                {
                    await A_To_PLCAsync();
                });
            }

        }

        #endregion


        #region - - - Methods - - -

        async Task A_To_PLCAsync()
        {
            try
            {
                bool ManualMode = (bool)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.Manual loading");
                MR MR = new MR();
                if (ManualMode)
                {
                    uint MR_Id = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Header.MRId");
                    MR = GetMRData(MR_Id);
                    if (MR.Article.Header.Id == -1)
                    {
                        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Not loaded", true);
                        new MessageBoxTask("@RecipeSystem.Results.Text9", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    string Barcode = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.to.Barcode#STRING10").ToString();

                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                                "FROM Barcodes " +
                                                                "WHERE Barcode = '" + Barcode + "'").DB_Output();
                    if (DT.Rows.Count == 0)
                    {
                        ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Not loaded", true);
                        new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MR = GetMRData((uint)(int)DT.Rows[0]["MR_Id"]);
                    }

                }

                int counter = 0;
                for (int i = 0; i < MR.Layers.Count; i++)
                {
                    if (MR.Layers[i].Header.Id != -1)
                    {
                        counter = counter + 1;
                    }
                }


                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Layers", counter);

                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Data.from.Paint", MR.Layers[0].Paint_Id);

                new NewLoad()
                {
                    MR = MR.Header.Name,
                    MR_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Header.MRId")
                }.SetMRIdToPLC();

                await MR.Article.LoadToPLC();

            }
            catch (Exception ex)
            {
                ApplicationService.SetVariableValue("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Handshake.from PC.Not loaded", true);
                new MessageBoxTask("@RecipeSystem.Results.Text8", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);

                string Message = "Error at line - " + new StackTrace(ex, true).GetFrame(new StackTrace(ex, true).FrameCount - 1).GetFileLineNumber().ToString() + " - " + Environment.NewLine;
                Message += "Message : " + ex.Message + Environment.NewLine;
                Message += "Stacktrace : " + ex.StackTrace + Environment.NewLine;

                File.WriteAllText("C:\\VW_" + DateTime.Now.ToString() + ".txt", Message);
            }


        }

        MR GetMRData(uint _mr_id)
        {
            MR temp = new MR();
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                       "FROM Recipes_MR " +
                                                       "WHERE Id = " + _mr_id + ";").DB_Output();
            if (DT.Rows.Count > 0)
            {
                temp.Header = new RecipeInfo()
                {
                    Id = (int)DT.Rows[0]["Id"],
                    Name = (string)DT.Rows[0]["Name"],
                    Description = (string)DT.Rows[0]["Description"]
                };

                temp.Layers = new List<CO.Recipe.Coating>()
                {
                    new CO.Recipe.Coating() { Header = new RecipeInfo(){ Id = (int)DT.Rows[0]["C1_Id"]}, Paint_Id=(int)DT.Rows[0]["C1_P"] },
                    new CO.Recipe.Coating() { Header = new RecipeInfo(){ Id = (int)DT.Rows[0]["C2_Id"]} },
                    new CO.Recipe.Coating() { Header = new RecipeInfo(){ Id = (int)DT.Rows[0]["C3_Id"]} },
                    new CO.Recipe.Coating() { Header = new RecipeInfo(){ Id = (int)DT.Rows[0]["C4_Id"]} },
                    new CO.Recipe.Coating() { Header = new RecipeInfo(){ Id = (int)DT.Rows[0]["C5_Id"]} },
                };

                temp.Article = GetArticleData((int)DT.Rows[0]["Article_Id"]);
            }

            return temp;
        }

        Article GetArticleData(int _id)
        {
            Article temp = new Article();
            if (_id != -1)
            {
                DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *  FROM Recipes_Article WHERE Id = " + _id + "; ").DB_Output();

                if (DT.Rows.Count > 0)
                {
                    temp = new Article()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = _id,
                            Name = (string)DT.Rows[0]["Name"],
                            Description = (string)DT.Rows[0]["Description"],
                        },
                        VWRecipe = new VWRecipe("Article", (string)DT.Rows[0]["VWRecipe"])
                    };
                }
            }
            return temp;
        }
        #endregion
    }
}
