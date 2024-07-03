using HMI.CO.General;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Resources.UserControls.MO
{
    public partial class MV_CZ : UserControl
    {
        BackgroundWorker AddObjects = new BackgroundWorker();
        BackgroundWorker ClearObjects = new BackgroundWorker();
        IVariableService VS = ApplicationService.GetService<IVariableService>();
        public MV_CZ()
        {
            InitializeComponent();
            CZ1Temp1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.01 Air 1.DB CZ Air 1 HMI.Actual.Temperature";
            CZ1Fan1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.01 Air 1.DB CZ Air 1 HMI.Actual.Circulating fan.Motor.Actual.Speed 2";
            CZ2Temp1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.02 Air 2.DB CZ Air 2 HMI.Actual.Temperature";
            CZ2Fan1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.02 Air 2.DB CZ Air 2 HMI.Actual.Circulating fan.Motor.Actual.Speed 2";
            CZ3Temp1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Temperature";
            CZ3Fan1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Circulating fan.Motor.Actual.Speed 2";
            CZ4Temp1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.04 Air 4.DB CZ Air 4 HMI.Actual.Temperature";
            CZ4Fan1 = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.04 Air 4.DB CZ Air 4 HMI.Actual.Circulating fan.Motor.Actual.Speed 2";

            Clocked = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.PC.Clocked";

            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;

            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;
        }

        private IVariable IVClocked;

        public string Clocked
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVClocked = VS.GetVariable(value);
                    IVClocked.Change += IVClocked_ValueChanged;
                }
            }
        }
        public string CZ1Temp1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ1T1.VariableName = value;
                }
            }
        }
       
        public string CZ2Temp1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ2T1.VariableName = value;
                }
            }
        }
       
        public string CZ3Temp1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ3T1.VariableName = value;
                }
            }
        }
      
        public string CZ4Temp1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ4T1.VariableName = value;
                }
            }
        }
      
        public string CZ1Fan1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ1F1.VariableName = value;
                }
            }
        }
        
        public string CZ2Fan1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ2F1.VariableName = value;
                }
            }
        }
        
        public string CZ3Fan1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ3F1.VariableName = value;
                }
            }
        }
       
        public string CZ4Fan1
        {
             get { return ""; } 
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    CZ4F1.VariableName = value;
                }
            }
        }
        

        private void IVClocked_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                if (this.IsVisible)
                {
                    if ((bool)e.Value && Trays.IsLoaded)
                    {
                        if (AddObjects.IsBusy)
                        {
                            AddObjects.CancelAsync();
                        }
                        else
                        {
                            if(!ClearObjects.IsBusy)
                                ClearObjects.RunWorkerAsync();
                        }
                    }
                }
            }
        }
        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!AddObjects.IsBusy)
                AddObjects.RunWorkerAsync();
        }
        private void ClearObjects_DoWork(object sender, DoWorkEventArgs e)
        {

            Dispatcher.InvokeAsync(delegate
            {
                Trays.Children.Clear();
            });

            Thread.Sleep(250);

        }

        private void AddObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //
            }
            else if (e.Cancelled)
            {
                ClearObjects.RunWorkerAsync();
            }
            else
            {

            }
        }
        private void AddObjects_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                short Coord = (short)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i.ToString() + "].Status.Coordinate");

               

                MVTray T = null;
               
                Dispatcher.InvokeAsync(delegate
                {

                    T = GetCZTray(i);
                    switch (Coord)
                    {
                        case 0: T.Margin = new Thickness(8, 135, 0, 0); break;
                        case 1: T.Margin = new Thickness(72, 135, 0, 0); break;
                        case 2: T.Margin = new Thickness(139, 135, 0, 0); break;
                        case 3: T.Margin = new Thickness(203, 135, 0, 0); break;
                        case 4: T.Margin = new Thickness(270, 135, 0, 0); break;
                        case 5: T.Margin = new Thickness(334, 135, 0, 0); break;
                        case 6: T.Margin = new Thickness(401, 135, 0, 0); break;
                        case 7: T.Margin = new Thickness(465, 135, 0, 0); break;
                    }

                    T.HorizontalAlignment = HorizontalAlignment.Left;
                    T.VerticalAlignment = VerticalAlignment.Top;

                    Trays.Children.Add(T);
                });
                Thread.Sleep(250);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowMOElement(this);
        }
     
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "MO_CZ");
        }
        private void Trays_Loaded(object sender, RoutedEventArgs e)
        {

            if (AddObjects.IsBusy)
            {
                AddObjects.CancelAsync();
            }
            else
            {
                if (!ClearObjects.IsBusy)
                    ClearObjects.RunWorkerAsync();
            }
        }

        private MVTray GetCZTray(int i)
        {
            return new MVTray()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Tray.isTray",
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Charge.isMaterial",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Charge.Layers.Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Charge.Layers.Actual",
               
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[" + i + "].PD.Tray.Functions.Watch",
                Station = 15,
                Place = i,
                Type = "Tray",
                CPU = "CPU2",
                Header = "@Status.Text" + (63 + i).ToString()
            };
        }
    }
}
