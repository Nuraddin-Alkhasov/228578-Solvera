using HMI.CO.General;
using HMI.CO.Protocol;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;

namespace HMI.MainRegion.Protocol.Adapters
{
    [ExportAdapter("Protocol")]
    public class Protocol : AdapterBase
    {
        public Protocol()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            OpenFilter = new ActionCommand(OpenFilterExecuted);
        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        public string LastSQLQuery { set; get; }

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



        #endregion

        #region - - - Commands - - - 
        public ICommand OpenFilter { get; set; }

        private void OpenFilterExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Protocol_Filter");
        }


        #endregion

        #region - - - Orders - - -

        private ObservableCollection<Order> orders = new ObservableCollection<Order>();
        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                if (!Equals(value, orders))
                {
                    orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }

        private Order selectedOrder = null;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (!Equals(value, selectedOrder))
                {
                    selectedOrder = value;
                    if (selectedOrder != null)
                    {
                        Wait = Visibility.Visible;
                        Task obTask = Task.Run(() =>
                        {
                            selectedOrder.FillBoxList();
                        });
                        obTask.ContinueWith(x =>
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                                OnPropertyChanged("SelectedOrder");
                            });
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);

                    }

                    OnPropertyChanged("SelectedOrder");
                }
            }
        }

        public void LoadOrderList(string sql)
        {
            LastSQLQuery = sql;
            Wait = Visibility.Visible;
            ObservableCollection<Order> temp = new ObservableCollection<Order>();
            Task obTask = Task.Run(async () =>
            {
                DataTable DT = new MSSQLEAdapter("Orders", sql).DB_Output();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow r in DT.Rows)
                    {
                        await Task.Delay(20);
                        temp.Add(new Order()
                        {
                            Id = (int)r["Id"],
                            Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                            End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                            Data_1 = (string)r["Data_1"],
                            Data_2 = (string)r["Data_2"],
                            Data_3 = (string)r["Data_3"],
                            Boxes = (int)r["Boxes"],
                            Weight = (float)r["Weight"],
                            IsError = (bool)r["IsError"],
                            User = (string)r["User"]
                        });
                    }
                }
            });

            obTask.ContinueWith(x =>
              {
                  Application.Current.Dispatcher.Invoke(delegate
                  {
                      Orders.Clear();
                      Orders = temp;
                      Wait = Visibility.Hidden;
                  });
              }, TaskContinuationOptions.OnlyOnRanToCompletion);

        }
        #endregion

        #region - - - Boxes - - -

        private Box selectedBox = null;
        public Box SelectedBox
        {
            get { return selectedBox; }
            set
            {
                IsBoxSelected = false;
                if (!Equals(value, selectedBox))
                {
                    selectedBox = value;
                    if (selectedBox != null)
                    {
                        Wait = Visibility.Visible;
                        Task obTask = Task.Run(() =>
                        {
                            selectedBox.FillChargesList();
                            selectedBox.SetMR(selectedBox.MR.Header.Id);
                        });
                        obTask.ContinueWith(x =>
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                IsBoxSelected = true;
                                Wait = Visibility.Hidden;
                                OnPropertyChanged("SelectedBox");
                            });
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);

                    }

                    OnPropertyChanged("SelectedBox");
                }
            }
        }

        private bool isBoxSelected = false;
        public bool IsBoxSelected
        {
            get { return isBoxSelected; }
            set
            {
                isBoxSelected = value;
                OnPropertyChanged("IsRunSelected");
            }
        }

        #endregion

        #region - - - Charges - - -

        private Charge selectedCharge = null;
        public Charge SelectedCharge
        {
            get { return selectedCharge; }
            set
            {
                if (!Equals(value, selectedCharge))
                {
                    selectedCharge = value;
                    if (selectedCharge != null)
                    {
                        Wait = Visibility.Visible;
                        Task obTask = Task.Run(() =>
                        {
                            selectedCharge.FillRunList();
                        });
                        obTask.ContinueWith(x =>
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                                OnPropertyChanged("SelectedCharge");
                            });
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);

                    }

                    OnPropertyChanged("SelectedCharge");
                }
            }
        }

        #endregion

        #region - - - Runs - - -

        private Run selectedRun = null;
        public Run SelectedRun
        {
            get { return selectedRun; }
            set
            {
                IsRunSelected = false;
                if (!Equals(value, selectedRun))
                {
                    selectedRun = value;

                    if (selectedRun != null)
                    {

                        Wait = Visibility.Visible;
                        Task obTask = Task.Run(() =>
                        {
                            selectedRun.FillErrorList();
                            selectedRun.FillSetValues(selectedRun.SetValues_Id);
                            selectedRun.FillActualValues(selectedRun.ActualValues_Id);
                            selectedRun.FillPZTrend(selectedRun.Id);
                            selectedRun.FillWZTrend(selectedRun.Id);
                            selectedRun.FillHZTrend(selectedRun.Id);
                            selectedRun.FillCZTrend(selectedRun.Id);
                        });
                        obTask.ContinueWith(x =>
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                Wait = Visibility.Hidden;
                                IsRunSelected = true;
                                OnPropertyChanged("SelectedRun");
                            });
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);

                    }

                    OnPropertyChanged("SelectedRun");
                }
            }
        }

        private bool isRunSelected = false;
        public bool IsRunSelected
        {
            get { return isRunSelected; }
            set
            {
                isRunSelected = value;
                OnPropertyChanged("IsRunSelected");
            }
        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (e.View.GetType().Name == "Protocol_Orders")
            {
                LoadOrderList("Select * From Orders WHERE [Start] >= '" + GetDataTimeFormated(DateTime.Now.AddDays(-1)) + "' AND [Start] <= '" + GetDataTimeFormated(DateTime.Now) + "' ");
            }

            base.OnViewLoaded(sender, e);
        }

        private string GetDataTimeFormated(DateTime dt)
        {
            return dt.ToString("yyyyMMdd HH:mm:ss");
        }
        #endregion


    }
}