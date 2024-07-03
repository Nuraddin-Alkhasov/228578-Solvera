using HMI.CO.General;
using HMI.CO.Recipe;
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
    [ExportAdapter("Coating_Selector")]
    public class Coating_Selector : AdapterBase
    {

        public Coating_Selector()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            Select = new ActionCommand(SelectExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
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

        private List<Coating> coatings { get; set; } = new List<Coating>();
        public List<Coating> Coatings
        {
            get { return coatings; }
            set
            {
                coatings = value;

                OnPropertyChanged("Coatings");
            }
        }
        private List<Coating> TCoatings { get; set; } = new List<Coating>();
        private Coating selectedC { get; set; } = new Coating();
        public Coating SelectedC
        {
            get { return selectedC; }
            set
            {
                selectedC = value;
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


                OnPropertyChanged("SelectedC");
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
                        IEnumerable<Coating> enumerable = Coatings.Where(x => x.Header.Name.Contains(value));
                        Coatings = Convert(enumerable);
                        SelectedC = new Coating();
                    }
                    else
                    {
                        Coatings = TCoatings;
                    }
                    filter = value;
                    OnPropertyChanged("Filter");
                }
            }
        }

        private string Identifier { set; get; } = "";

        #endregion

        #region - - - Commands - - -

        public ICommand Select { get; set; }
        private void SelectExecuted(object parameter)
        {
            if (SelectedC.Header.Id > 0)
            {
                switch (Identifier)
                {
                    case "MO_CoatingPicker":
                        MO.Views.MO_CoatingPicker vp = (MO.Views.MO_CoatingPicker)iRS.GetView("MO_CoatingPicker");
                        MO.Adapters.MO_CoatingPicker dcp = (MO.Adapters.MO_CoatingPicker)vp.DataContext;
                        dcp.C = SelectedC;
                        break;
                    default: break;
                }

                CloseExecuted(null);
            }

        }



        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Coating_Selector v = (Views.Coating_Selector)iRS.GetView("Coating_Selector");
            new ObjectAnimator().CloseDialog2(v, v.border);
        }




        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            Identifier = ApplicationService.ObjectStore.GetValue("Coating_Selector_KEY") as string;
            ApplicationService.ObjectStore.Remove("Coating_Selector_KEY");

            GetCoatings();

            filter = "";
            OnPropertyChanged("Filter");

            Views.Coating_Selector v = (Views.Coating_Selector)iRS.GetView("Coating_Selector");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void GetCoatings()
        {
            if (Wait != Visibility.Visible)
            {
                Wait = Visibility.Visible;
                List<Coating> temp = new List<Coating>();
                Task obTask = Task.Run(async () =>
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * " +
                        "FROM Recipes_Coating; ").DB_Output();

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            await Task.Delay(20);
                            temp.Add(new Coating()
                            {

                                Header = new RecipeInfo()
                                {
                                    Id = (int)r["Id"],
                                    Name = (string)r["Name"],
                                    Description = r["Description"] == DBNull.Value ? "" : ((string)r["Description"]),
                                    LastChanged = ((DateTime)r["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                                    User = (string)r["User"]
                                },
                                VWRecipe = new VWRecipe((string)r["VWRecipe"])
                            });
                        }


                    }

                });

                obTask.ContinueWith(x =>
                {
                    Application.Current.Dispatcher.Invoke(delegate
                    {
                        TCoatings = Coatings = temp;
                        SelectedC = Coatings[0];
                        Wait = Visibility.Hidden;
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

          


        }


        public List<Coating> Convert(IEnumerable original)
        {
            return new List<Coating>(original.Cast<Coating>());
        }

        #endregion


    }
}