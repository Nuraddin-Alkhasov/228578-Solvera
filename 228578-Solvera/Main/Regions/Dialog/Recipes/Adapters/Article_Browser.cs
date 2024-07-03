using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.DialogRegion.Recipes.Adapters
{
    [ExportAdapter("Article_Browser")]
    public class Article_Browser : AdapterBase
    {

        public Article_Browser()
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

        private List<Article> articles { get; set; } = new List<Article>();
        public List<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;

                OnPropertyChanged("Articles");
            }
        }
        private List<Article> TArticles { get; set; } = new List<Article>();

        private Article selectedArticle { get; set; } = new Article();
        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                selectedArticle = value;
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


                OnPropertyChanged("SelectedArticle");
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
                        Articles = new List<Article>();
                        foreach (Article a in TArticles)
                        {
                            if (a.Header.Name.ToUpper().Contains(value.ToUpper()))
                            {
                                Articles.Add(a);
                            }
                        }
                        SelectedArticle = new Article();
                    }
                    else
                    {
                        Articles = TArticles;
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
            if (SelectedArticle.Header.Id > 0)
            {
                ((MainRegion.Recipes.Adapters.Recipes_Article)(iRS.GetView("MainRegion", "Recipes_Article") as MainRegion.Recipes.Views.Recipes_Article).DataContext).LoadArticle(SelectedArticle);
                CloseExecuted(null);
            }
        }

        public ICommand Save { get; set; }
        private void SaveExecuted(object parameter)
        {
            if (NameBuffer.Length >= 3)
            {
                MainRegion.Recipes.Views.Recipes_Article art = iRS.GetView("MainRegion", "Recipes_Article") as MainRegion.Recipes.Views.Recipes_Article;
                MainRegion.Recipes.Adapters.Recipes_Article aa = art.DataContext as MainRegion.Recipes.Adapters.Recipes_Article;
                ArticleInfo AI = new ArticleInfo() { Art = aa.SelectedArt, Size = aa.SelectedSize, Type = aa.SelectedType };
                if (AI.Art.Id != -1 || AI.Size.Id != -1 || AI.Type.Id != -1)
                {
                    Article a = Articles.Where(x => x.Header.Name == NameBuffer).ToArray().Length > 0 ? Articles.Where(x => x.Header.Name == NameBuffer).ToArray()[0] : new Article();
                    if (a.Header.Id > 0)
                    {
                        if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

               
                    Wait = Visibility.Visible;
                    Task obTask = Task.Run(async () =>
                    {
                        SaveToFileFromBufferResult e = await Class.SaveToFileFromBufferAsync(NameBuffer, DescriptionBuffer, true);
                        if (e.Result != SaveRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (a.Header.Id > 0)
                            {
                                new MSSQLEAdapter("Recipes", "UPDATE Recipes_Article " +
                                                      "SET " +
                                                      "Description = '" + DescriptionBuffer + "', " +
                                                      "Art_Id = " + AI.Art.Id + ", " +
                                                      "Type_Id = " + AI.Type.Id + ", " +
                                                      "Size_Id = " + AI.Size.Id + ", " +
                                                      "VWRecipe = '" + File.ReadAllText(Class.CurrentPath + @"\\" + NameBuffer + ".R") + "', " +
                                                      "LastChanged = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "', " +
                                                      "[User] = '" + ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "' " +
                                                      "WHERE Id = " + a.Header.Id + ";").DB_Input();

                            }
                            else
                            {
                                new MSSQLEAdapter("Recipes", "INSERT " +
                                                      "INTO Recipes_Article (Name, Description, Art_Id, Type_Id, Size_Id, VWRecipe, [User]) " +
                                                      "VALUES ('" +
                                                      NameBuffer + "','" +
                                                      DescriptionBuffer + "'," +
                                                      AI.Art.Id + "," +
                                                      AI.Type.Id + "," +
                                                      AI.Size.Id + ",'" +
                                                      File.ReadAllText(Class.CurrentPath + @"\\" + NameBuffer + ".R") + "','" +
                                                      ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "');").DB_Input();
                            }
                        }

                        await Task.Delay(500);

                        Wait = Visibility.Hidden;
                        CloseExecuted(null);
                    });

                    obTask.ContinueWith(x =>
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            UpdateName();
                        });
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
               
            }
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (SelectedArticle.Header.Id > 0)
            {
                if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                {
                    Wait = Visibility.Visible;

                    Task obTask = Task.Run(async () =>
                    {

                        new MSSQLEAdapter("Recipes", "DELETE " +
                                                "FROM Recipes_Article " +
                                                "WHERE Id = " + SelectedArticle.Header.Id + "; ").DB_Output();

                        await Task.Delay(500);



                        Wait = Visibility.Hidden;
                    });
                    obTask.ContinueWith(x =>
                    {
                        Dispatcher.Invoke(delegate
                        {
                            Articles.Remove(SelectedArticle);
                            List<Article> temp = articles;
                            Articles = new List<Article>();
                            Articles = temp;
                            SelectedArticle = new Article();

                            UpdateName();
                        });
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
            }
        }

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            Views.Article_Browser v = (Views.Article_Browser)iRS.GetView("Article_Browser");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            RecipeInfo temp = ApplicationService.ObjectStore.GetValue("Article_Browser_KEY") as RecipeInfo;
            ApplicationService.ObjectStore.Remove("Article_Browser_KEY");
            GetArticles(temp);

            filter = "";
            OnPropertyChanged("Filter");

            Views.Article_Browser v = (Views.Article_Browser)iRS.GetView("Article_Browser");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetArticles(RecipeInfo recipe)
        {
            if (Wait != Visibility.Visible) 
            {
                Wait = Visibility.Visible;
                List<Article> temp = new List<Article>();
                Task obTask = Task.Run(async () =>
                {
                    try
                    {
                        DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * FROM Recipes_Article; ").DB_Output();

                        if (DT.Rows.Count > 0)
                        {
                            foreach (DataRow r in DT.Rows)
                            {
                                await Task.Delay(20);

                                temp.Add(new Article()
                                {

                                    Header = new RecipeInfo()
                                    {
                                        Id = (int)r["Id"],
                                        Name = (string)r["Name"],
                                        Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                        LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                        User = (string)r["User"]
                                    },
                                    Info = new ArticleInfo()
                                    {
                                        Art = new Art()
                                        {
                                            Id = (int)r["Art_Id"]
                                        },
                                        Type = new Dictionary()
                                        {
                                            Id = (int)r["Type_Id"]
                                        },
                                        Size = new Dictionary()
                                        {
                                            Id = (int)r["Size_Id"]
                                        }
                                    },
                                    VWRecipe = new VWRecipe()
                                    {
                                        Class = "Article",
                                        Data = (string)r["VWRecipe"]
                                    },
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
                            TArticles = Articles = temp;
                            if (Articles.Where(t => t.Header.Name == recipe.Name).Count() != 0)
                            {
                                SelectedArticle = Articles.Where(t => t.Header.Name == recipe.Name).First();
                            }
                            else { SelectedArticle = new Article(); }
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
        public List<Article> Convert(IEnumerable original)
        {
            return new List<Article>(original.Cast<Article>());
        }

        #endregion


    }
}