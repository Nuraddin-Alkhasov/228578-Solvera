using HMI.CO.General;
using HMI.CO.Protocol;
using HMI.CO.Recipe;
using HMI.DialogRegion.MO.Views;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;
using VisiWin.Controls;

namespace HMI.DialogRegion.MO.Adapters
{
    [ExportAdapter("MO_Status_1")]
    public class MO_Status_1 : AdapterBase
    {

        public MO_Status_1()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Update = new ActionCommand(UpdateExecuted);
            Delete = new ActionCommand(DeleteExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -

        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        string header { set; get; } = "";
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }
        string data1 { set; get; } = "";
        public string Data_1
        {
            get { return data1; }
            set
            {
                data1 = value;
                OnPropertyChanged("Data_1");
            }
        }

        string data2 { set; get; } = "";
        public string Data_2
        {
            get { return data2; }
            set
            {
                data2 = value;
                OnPropertyChanged("Data_2");
            }
        }

        string data3 { set; get; } = "";
        public string Data_3
        {
            get { return data3; }
            set
            {
                data3 = value;
                OnPropertyChanged("Data_3");
            }
        }
        int box { set; get; } = 0;
        public int Box
        {
            get { return box; }
            set
            {
                box = value;
                OnPropertyChanged("Box");
            }
        }
        int charge { set; get; } = 0;
        public int Charge
        {
            get { return charge; }
            set
            {
                charge = value;
                OnPropertyChanged("Charge");
            }
        }

        float weight { set; get; } = 0;
        public float Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }

        int run { set; get; } = 0;
        public int Run
        {
            get { return run; }
            set
            {
                run = value;
                OnPropertyChanged("Run");
            }
        }

        string painta { set; get; } = " - - - ";
        public string PaintA
        {
            get { return painta; }
            set
            {
                painta = value;
                OnPropertyChanged("PaintA");
            }
        }
        string paintn { set; get; } = " - - - ";
        public string PaintN
        {
            get { return paintn; }
            set
            {
                paintn = value;
                OnPropertyChanged("PaintN");
            }
        }

        int layersSet { set; get; } = 0;
        public int LayersSet
        {
            get { return layersSet; }
            set
            {
                layersSet = value;
                OnPropertyChanged("LayersSet");
            }
        }


        object content { set; get; } = new object();
        public object Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        MR mr { set; get; } = new MR();
        public MR MR
        {
            get { return mr; }
            set
            {
                mr = value;
                OnPropertyChanged("MR");
            }
        }

        string user { set; get; } = "";
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private SP SPData { set; get; } = new SP();

        StateCollection paintTypes = new StateCollection();
        public StateCollection PaintTypes
        {
            get { return paintTypes; }
            set
            {
                if (value != null)
                {
                    paintTypes = value;
                    OnPropertyChanged("PaintTypes");
                }
            }
        }
        #endregion

        #region - - - Commands - - -

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {
            SPData.Close();

            Views.MO_Status_1 v = (Views.MO_Status_1)iRS.GetView("MO_Status_1");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }

        public ICommand Delete { get; set; }
        private void DeleteExecuted(object parameter)
        {
            if (MessageBoxView.Show("@Status.Text26", "@Status.Text27", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {

                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.Data.Delete", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.Data.Delete", false);
                    CloseExecuted(null);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
            loggingService.Log("Machine", "SP", "@Logging.Machine.Text8", DateTime.Now);

           
        }

        public ICommand Update { get; set; }
        private void UpdateExecuted(object parameter)
        {
            if (MessageBoxView.Show("@Status.Text29", "@Status.Text28", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                Task taskA = Task.Run(() =>
                {
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.Data.Update", true);
                });
                taskA.ContinueWith(async x =>
                {
                    await Task.Delay(1000);
                    ApplicationService.SetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.Data.Update", false);
                    CloseExecuted(null);

                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
                loggingService.Log("Machine", "SP", "@Logging.Machine.Text9", DateTime.Now);
              
            }
        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                SPData = ApplicationService.ObjectStore.GetValue("MO_Status_1_KEY") as SP;
                ApplicationService.ObjectStore.Remove("MO_Status_1_KEY");
                Header = SPData.Header;

                SetData();



;                switch (SPData.Type)
                {
                    case "Box": Content = new MO_Status_Box1(); break;
                    case "Belt": Content = new object(); break;
                    case "Basket": Content = new MO_Status_Basket();  break;
                    case "Tray": Content = new MO_Status_Tray(); break;
                    default: Content = new object(); break;
                }

                Views.MO_Status_1 v = (Views.MO_Status_1)iRS.GetView("MO_Status_1");
                new ObjectAnimator().OpenDialog(v, v.border);

            }
          
            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        private void SetData() 
        {
            //Task obTask = Task.Run(() =>
            // {
            try
            {
                string[] Layers = new string[5];
                uint OrderId = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Header.OrderId");
                if (OrderId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Orders WHERE Id = " + OrderId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Data_1 = (string)DT.Rows[0]["Data_1"];
                        Data_2 = (string)DT.Rows[0]["Data_2"];
                        Data_3 = (string)DT.Rows[0]["Data_3"];
                    }
                }
                else
                {
                    Data_1 = "";
                    Data_2 = "";
                    Data_3 = "";
                }

                uint BoxId = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Header.BoxId");
                if (BoxId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Boxes WHERE Id = " + BoxId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Box = (int)DT.Rows[0]["Box"];
                    }
                }
                else
                {
                    Box = 0;
                    MR = new MR();
                }
                MR.Header.Id = (int)(uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Header.MRId");
                LayersSet = 0;
                if (MR.Header.Id > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Recipes", "SELECT * From Recipes_MR WHERE Id = " + MR.Header.Id + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        MR.Header.Name = (string)DT.Rows[0]["Name"];
                        MR.Article.Header.Id = (int)DT.Rows[0]["Article_Id"];
                        Layers[0] = (int)DT.Rows[0]["C1_P"] != -1 ? ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (int)DT.Rows[0]["C1_P"] + "]").ToString() : " - - - ";
                        Layers[1] = (int)DT.Rows[0]["C2_P"] != -1 ? ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (int)DT.Rows[0]["C2_P"] + "]").ToString() : " - - - ";
                        Layers[2] = (int)DT.Rows[0]["C3_P"] != -1 ? ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (int)DT.Rows[0]["C3_P"] + "]").ToString() : " - - - ";
                        Layers[3] = (int)DT.Rows[0]["C4_P"] != -1 ? ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (int)DT.Rows[0]["C4_P"] + "]").ToString() : " - - - ";
                        Layers[4] = (int)DT.Rows[0]["C5_P"] != -1 ? ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + (int)DT.Rows[0]["C5_P"] + "]").ToString() : " - - - ";
                        for (int i = 1; i <= 5; i++)
                        {
                            LayersSet += (int)DT.Rows[0]["C" + i.ToString() + "_Id"] != -1 ? 1 : 0;
                        }
                    }

                    DT = new MSSQLEAdapter("Recipes", "SELECT * From Recipes_Article WHERE Id = " + MR.Article.Header.Id + ";").DB_Output();
                    DT = new MSSQLEAdapter("Recipes", "SELECT * From Article_Arts WHERE Id = " + DT.Rows[0]["Art_Id"] + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        MR.Article.Info.Art.Image = (string)DT.Rows[0]["Image"];
                    }
                }

                uint ChargeId = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Header.ChargeId");
                if (ChargeId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Charges WHERE Id = " + ChargeId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Charge = (int)DT.Rows[0]["Charge"];
                        Weight = (float)DT.Rows[0]["Weight"];
                    }
                }
                else
                {
                    Charge = 0;
                    Weight = 0;
                }

                uint RunId = (uint)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Header.RunId");
                if (RunId > 0)
                {
                    DataTable DT = new MSSQLEAdapter("Orders", "SELECT * From Runs WHERE Id = " + RunId + ";").DB_Output();
                    if (DT.Rows.Count > 0)
                    {
                        Run = (int)DT.Rows[0]["Run"];
                    }
                }
                else
                {
                    Run = 0;
                }

                PaintTypes = GetPaintTypes();
            }
            catch { }

            //short ActualLayer = (short)ApplicationService.GetVariableValue("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Charge.Layers.Actual");
            //if (ActualLayer == 0)
            //{
            //    PaintA = " - - - ";
            //    PaintN = Layers[0];
            //}
            //else
            //{
            //    PaintA = Layers[ActualLayer - 1];
            //    if (ActualLayer == 5)
            //    {
            //        PaintN = " - - - ";
            //    }
            //    else
            //    {
            //        PaintN = Layers[ActualLayer];
            //    }
            //}

            OnPropertyChanged("MR");
          //  });



        }

        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();
            Temp_SC.Add(new State()
            {
                Text = " - - - ",
                Value = "0"
            });
            for (int i = 1; i <= 10; i++)
            {

                string temp = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + i + "]").ToString();
                if (temp != "")
                {
                    Temp_SC.Add(new State()
                    {
                        Text = temp,
                        Value = i.ToString()
                    });
                }
            }
            return Temp_SC;
        }

        #endregion


    }
}