using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.MainRegion.Recipes.Views;
using HMI.Resources;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;
using VisiWin.Recipe;

namespace HMI.MainRegion.Recipes.Adapters
{
    [ExportAdapter("Recipes_Article")]
    public class Recipes_Article : AdapterBase
    {

        public Recipes_Article()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            languageService.LanguageChanged += LanguageService_LanguageChanged;

            HC = new ActionCommand(HCExecuted);
            DC = new ActionCommand(DCExecuted);
            BS = new ActionCommand(BSExecuted);

            BT = new ActionCommand(BTExecuted);
            MC = new ActionCommand(MCExecuted);
            POReturn = new ActionCommand(POReturnExecuted);
        }

        #region - - - Properties - - -
        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Article");
        private readonly ILanguageService languageService = ApplicationService.GetService<ILanguageService>();
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private bool ldIsChecked { get; set; } = true;
        public bool LDIsChecked
        {
            get { return ldIsChecked; }
            set
            {
                ldIsChecked = value;
                if (value)
                    Content = new Recipe_Article_LD();
                OnPropertyChanged("LDIsChecked");
            }
        }
        object content;
        public object Content
        {
            get { return content; }
            set
            {
                this.content = value;
                this.OnPropertyChanged("Content");
            }
        }
        private List<Art> arts { set; get; } = new List<Art>();
        public List<Art> Arts
        {
            get { return arts; }
            set
            {
                arts = value;
                OnPropertyChanged("Arts");
            }
        }
        private Art selectedArt { set; get; } = new Art();
        public Art SelectedArt
        {
            get { return selectedArt; }
            set
            {
                selectedArt = value;
                OnPropertyChanged("SelectedArt");
            }
        }

        private List<Dictionary> types { set; get; } = new List<Dictionary>();
        public List<Dictionary> Types
        {
            get { return types; }
            set
            {
                types = value;
                OnPropertyChanged("Types");
            }
        }
        private Dictionary selectedType { set; get; } = new Dictionary();
        public Dictionary SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        private List<Dictionary> sizes { set; get; } = new List<Dictionary>();
        public List<Dictionary> Sizes
        {
            get { return sizes; }
            set
            {
                sizes = value;
                OnPropertyChanged("Sizes");
            }
        }
        private Dictionary selectedSize { set; get; } = new Dictionary();
        public Dictionary SelectedSize
        {
            get { return selectedSize; }
            set
            {
                selectedSize = value;
                OnPropertyChanged("SelectedSize");
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand HC { get; set; }
        private void HCExecuted(object parameter)
        {
            Content = new Recipe_Article_HC();
        }
        public ICommand DC { get; set; }
        private void DCExecuted(object parameter)
        {
            Content = new Recipe_Article_DC();
        }
        public ICommand BS { get; set; }
        private void BSExecuted(object parameter)
        {
            Content = new Recipe_Article_BS();
        }
        public ICommand BT { get; set; }
        private void BTExecuted(object parameter)
        {
            Content = new Recipe_Article_BT();
        }
        public ICommand MC { get; set; }
        private void MCExecuted(object parameter)
        {
            Content = new Recipe_Article_MC();
        }
        public ICommand POReturn { get; set; }
        private void POReturnExecuted(object parameter)
        {
            Content = new Recipe_Article_PO();
        }
        

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {

                FillArticleData();
                LDIsChecked = true;
            }

            base.OnViewLoaded(sender, e);
        }
        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            base.OnViewUnloaded(sender, e);
        }
        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            FillArticleData();
        }

        #endregion

        #region - - - Methods - - -

        private void FillArticleData()
        {

            List<Art> temp_a = new List<Art>();
            List<Dictionary> temp_t = new List<Dictionary>();
            List<Dictionary> temp_s = new List<Dictionary>();
            Task obTask = Task.Run(() =>
            {

                DataTable DT = new MSSQLEAdapter("Recipes", "Select * From Article_Arts;").DB_Output();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        temp_a.Add(new Art()
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Art"],
                            Image = (string)r["Image"],
                        });
                    }
                }


                DT = new MSSQLEAdapter("Recipes", "Select * From Article_Types;").DB_Output();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        temp_t.Add(new Dictionary()
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Type"]
                        });
                    }
                }


                DT = new MSSQLEAdapter("Recipes", "Select * From Article_Sizes;").DB_Output();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        temp_s.Add(new Dictionary()
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Size"]
                        });
                    }
                }



            });
            obTask.ContinueWith(x =>
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    int sa_Id = selectedArt.Id;
                    int st_Id = selectedType.Id;
                    int ss_Id = selectedSize.Id;

                    Arts = temp_a;
                    Types = temp_t;
                    Sizes = temp_s;

                    if (sa_Id > 0) { SelectedArt = Arts.Where(xf => xf.Id == sa_Id).First(); }
                    if (st_Id > 0) { SelectedType = Types.Where(xf => xf.Id == st_Id).First(); }
                    if (ss_Id > 0) { SelectedSize = Sizes.Where(xf => xf.Id == ss_Id).First(); }
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public void SetSelectedArticleInfo(ArticleInfo ai)
        {
            SelectedArt = arts.Where(x => x.Id == ai.Art.Id).First();
            SelectedType = types.Where(x => x.Id == ai.Type.Id).First();
            SelectedSize = sizes.Where(x => x.Id == ai.Size.Id).First();
        }

        public void LoadArticle(Article a)
        {
            if (a.Header.Id > 0)
            {
                Article temp = new Article();
                ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Visible;
                Task obTask = Task.Run(async () =>
                {
                     File.WriteAllText(Class.CurrentPath + @"\" + a.Header.Name + ".R", a.VWRecipe.Data);

                     DataTable art = new MSSQLEAdapter("Recipes", "SELECT * FROM Article_Arts WHERE Id = " + a.Info.Art.Id + "; ").DB_Output();
                     temp.Info.Art = new Art()
                     {
                         Id = (int)art.Rows[0]["Id"],
                         Name = (string)art.Rows[0]["Art"],
                         Image = (string)art.Rows[0]["Image"]
                     };

                     DataTable size = new MSSQLEAdapter("Recipes", "SELECT * FROM Article_Sizes WHERE Id = " + a.Info.Size.Id + "; ").DB_Output();
                     temp.Info.Size = new Dictionary()
                     {
                         Id = (int)size.Rows[0]["Id"],
                         Name = (string)size.Rows[0]["Size"],
                     };

                     DataTable type = new MSSQLEAdapter("Recipes", "SELECT * FROM Article_Types WHERE Id = " + a.Info.Type.Id + "; ").DB_Output();
                     temp.Info.Type = new Dictionary()
                     {
                         Id = (int)type.Rows[0]["Id"],
                         Name = (string)type.Rows[0]["Type"],
                     };

                    await Task.Delay(500);
                });
                obTask.ContinueWith(x =>
                {
                    Dispatcher.Invoke(async delegate
                    {
                        SelectedArt = Arts.First(ta => ta.Id == temp.Info.Art.Id);
                        SelectedSize = Sizes.First(ta => ta.Id == temp.Info.Size.Id);
                        SelectedType = Types.First(ta => ta.Id == temp.Info.Type.Id);
                        LoadFromFileToBufferResult result = await Class.LoadFromFileToBufferAsync(a.Header.Name);
                        if (result.Result != LoadRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                        }
                        ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Wait = Visibility.Hidden;
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            UpdateName(a);
        }

        private void UpdateName(Article a)
        {
            ((Adapters.Recipes_PN)((Views.Recipes_PN)iRS.GetView("Recipes_PN")).DataContext).Recipe = a.Header;
        }

        #endregion


    }
}