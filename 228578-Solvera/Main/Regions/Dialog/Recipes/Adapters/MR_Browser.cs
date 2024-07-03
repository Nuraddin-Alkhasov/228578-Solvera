using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using HMI.Resources.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    [ExportAdapter("MR_Browser")]
    public class MR_Browser : AdapterBase
    {

        public MR_Browser()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Load = new ActionCommand(LoadExecuted);
            Save = new ActionCommand(SaveExecuted);
            Delete = new ActionCommand(DeleteExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Article");
        private Visibility wait { get; set; } = Visibility.Hidden;
        public Visibility Wait
        {
            get { return wait; }
            set
            {
                wait = value;
                OnPropertyChanged("Wait");
            }
        }

        private List<MR> mrs { get; set; } = new List<MR>();
        public List<MR> MRs
        {
            get { return mrs; }
            set
            {
                mrs = value;

                OnPropertyChanged("MRs");
            }
        }
        private List<MR> TMRs { get; set; } = new List<MR>();

        private MR selectedMR { get; set; } = new MR();
        public MR SelectedMR
        {
            get { return selectedMR; }
            set
            {
                selectedMR = value;
                IsSelected = false;
                if (value != null)
                {
                    NameBuffer = value.Header.Name;
                    DescriptionBuffer = value.Header.Description;

                    if (value.Header.Id > 0)
                    {
                        IsSelected = true;
                    }
                }


                OnPropertyChanged("SelectedMR");
            }
        }

        private string nameBuffer = "";
        public string NameBuffer
        {
            get { return nameBuffer; }
            set
            {
                nameBuffer = value;
                OnPropertyChanged("NameBuffer");
            }
        }

        private string descriptionBuffer = "";
        public string DescriptionBuffer
        {
            get { return descriptionBuffer; }
            set
            {
                descriptionBuffer = value;
                OnPropertyChanged("DescriptionBuffer");
            }
        }
        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private string filter = "";
        public string Filter
        {
            get { return filter; }
            set
            {
                if (filter != value)
                {
                    if (value != "")
                    {
                        MRs = new List<MR>();
                        foreach (MR c in TMRs)
                        {
                            if (c.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                MRs.Add(c);
                            }
                        }
                       
                        SelectedMR = new MR();
                    }
                    else
                    {
                        MRs = TMRs;
                    }
                    filter = value;
                    OnPropertyChanged("Filter");
                }
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Load { get; set; }
        private void LoadExecuted(object parameter)
        {
            if (SelectedMR.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_MR)(iRS.GetView("MainRegion", "Recipes_MR") as MainRegion.Recipes.Views.Recipes_MR).DataContext).LoadMR(SelectedMR);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
                MR mr = MRs.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? MRs.First(x => x.Header.Name == NameBuffer) : new MR();
                if (mr.Header.Id > 0)
                {
                    if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                MainRegion.Recipes.Views.Recipes_MR v = (MainRegion.Recipes.Views.Recipes_MR)iRS.GetView("Recipes_MR");
                MainRegion.Recipes.Adapters.Recipes_MR dc = (MainRegion.Recipes.Adapters.Recipes_MR)v.DataContext;


                mr.Header.Name = NameBuffer;
                mr.Header.Description = DescriptionBuffer;

                if (dc.ArticleBuffer.Article.Header.Id == -1) 
                {
                    new MessageBoxTask("@RecipeSystem.Results.Text3", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                    Wait = Visibility.Hidden;
                    CloseExecuted(null);
                    return;
                }

                mr.Article = dc.ArticleBuffer.Article;
                
                List<Coating> temp = new List<Coating>();
                for (int i = 0; i < dc.CoatingBuffer.Count; i++)
                {
                    if (dc.CoatingBuffer[i].ToString() == "MR_Coating")
                    {
                        temp.Add(((MR_Coating)dc.CoatingBuffer[i]).Coating);
                    }
                }

                if (temp[0].Header.Id == -1)
                {
                    new MessageBoxTask("@RecipeSystem.Results.Text3", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                    Wait = Visibility.Hidden;
                    CloseExecuted(null);
                    return;
                }

                mr.Layers = temp;

                Wait = Visibility.Visible;
               // Task obTask = Task.Run(async () =>
                //{ 
                    if (mr.Header.Id > 0)
                    {
                        string UpdateData = ", Article_Id = " + dc.ArticleBuffer.Article.Header.Id.ToString();
                        for (int i = 0; i < mr.Layers.Count; i++)
                        {
                            UpdateData += ", C" + (i + 1).ToString() + "_Id = " + mr.Layers[i].Header.Id.ToString();
                            UpdateData += ", C" + (i + 1).ToString() + "_P = " + mr.Layers[i].Paint_Id.ToString();
                        if (mr.Layers[i].Paint_Id == -1) 
                        {
                            new MessageBoxTask("@RecipeSystem.Results.Text3", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                            Wait = Visibility.Hidden;
                            CloseExecuted(null);
                            return;
                        }
                        }
                    if (mr.Layers.Count < 5) 
                    {
                        for (int i = mr.Layers.Count; i < 5; i++)
                        {
                            UpdateData += ", C" + (i + 1).ToString() + "_Id = -1" ;
                            UpdateData += ", C" + (i + 1).ToString() + "_P = -1" ;
                        }
                    }
                        
                    new MSSQLEAdapter("Recipes", "UPDATE Recipes_MR " +
                                            "SET " +
                                            "Description = '" + DescriptionBuffer + "'" +
                                            UpdateData +
                                            ",LastChanged = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                            "[User] = '" + ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "' " +
                                            "WHERE Id = " + mr.Header.Id + ";").DB_Input();
                    }
                    else
                    {
                        string ColumnNames = ", Article_Id";
                        string Values = "," + mr.Article.Header.Id.ToString();

                        for (int i = 0; i < mr.Layers.Count; i++)
                        {
                            ColumnNames += ", C" + (i + 1).ToString() + "_Id, C" + (i + 1).ToString() + "_P";
                            Values += ", " + mr.Layers[i].Header.Id.ToString() + ", " + mr.Layers[i].Paint_Id.ToString();
                        }

                        new MSSQLEAdapter("Recipes", "INSERT " +
                                            "INTO Recipes_MR (Name, Description " + ColumnNames + ", [User]) " +
                                            "VALUES ('" +
                                            NameBuffer + "', '" +
                                            DescriptionBuffer + "'" +
                                            Values + ", '" +
                                            ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
                    }

               //     await Task.Delay(500);

                    Wait = Visibility.Hidden;
                    CloseExecuted(null);
               // });

              //  obTask.ContinueWith(x =>
               // {
               //     Dispatcher.Invoke(delegate
                //    {
                        UpdateName();
                        dc.LastLoadedSavedMR = mr;
                  //  });
              //  }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (SelectedMR.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task obTask = Task.Run(async () =>
                    {

                        new MSSQLEAdapter("Recipes", "DELETE " +
                                                "FROM Recipes_MR " +
                                                "WHERE Id = " + SelectedMR.Header.Id + "; ").DB_Output();

                        await Task.Delay(500);



                        Wait = Visibility.Hidden;
                    });
                    obTask.ContinueWith(x =>
                    {
                        Dispatcher.Invoke(delegate
                        {
                            MRs.Remove(SelectedMR);
                            List<MR> temp = mrs;
                            MRs = new List<MR>();
                            MRs = temp;
                            SelectedMR = new MR();

                            UpdateName();
                        });
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
            }
        }

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            Views.MR_Browser v = (Views.MR_Browser)iRS.GetView("MR_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("MR_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("MR_Browser_KEY");

            GetMRs(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.MR_Browser v = (Views.MR_Browser)iRS.GetView("MR_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetMRs(RecipeInfo recipe)
        {
            if (Wait != Visibility.Visible) 
            {
                Wait = Visibility.Visible;
                List<MR> temp = new List<MR>();
                Task obTask = Task.Run(async () =>
                {
                    try
                    {
                        DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_MR; ").DB_Output();

                        if (DT.Rows.Count > 0)
                        {
                            foreach (DataRow r in DT.Rows)
                            {
                                await Task.Delay(20);

                                temp.Add(new MR()
                                {

                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Id"],
                                        Name = (string)r["Name"],
                                        Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                        LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                        User = (string)r["User"]
                                    },
                                    Article = new Article()
                                    {
                                        Header = new RecipeInfo()
                                        {
                                            Id = (int)r["Article_Id"]
                                        }

                                    },
                                    Layers = new List<Coating>()
                            {
                                 new Coating()
                                 {
                                    Header= new RecipeInfo(){ Id = (int)r["C1_Id"]},
                                    Paint_Id=(int)r["C1_P"],
                                 },
                                 new Coating()
                                 {
                                    Header= new RecipeInfo(){ Id = (int)r["C2_Id"]},
                                    Paint_Id=(int)r["C2_P"],
                                 },
                                 new Coating()
                                 {
                                    Header= new RecipeInfo(){ Id = (int)r["C3_Id"]},
                                    Paint_Id=(int)r["C3_P"],
                                 },
                                 new Coating()
                                 {
                                    Header= new RecipeInfo(){ Id = (int)r["C4_Id"]},
                                    Paint_Id=(int)r["C4_P"],
                                 },
                                 new Coating()
                                 {
                                    Header= new RecipeInfo(){ Id = (int)r["C5_Id"]},
                                    Paint_Id=(int)r["C5_P"],
                                 },
                            }
                                });
                            }


                        }
                    }
                    catch { }
                });

                obTask.ContinueWith(x =>
                {
                    Application.Current.Dispatcher.Invoke(delegate
                    {
                        try
                        {
                            TMRs = MRs = temp;
                            if (MRs.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedMR = MRs.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedMR = new MR(); }
                        }
                        catch { }


                        Wait = Visibility.Hidden;
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            


        }

        private void UpdateName()
        {
            ((MainRegion.Recipes.Adapters.Recipes_PN)((MainRegion.Recipes.Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = new RecipeInfo() { Name = NameBuffer, Description = DescriptionBuffer };
        }

        public List<MR> Convert(IEnumerable original)
        {
            return new List<MR>(original.Cast<MR>());
        }

        #endregion


    }
}