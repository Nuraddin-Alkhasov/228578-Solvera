using HMI.CO.General;
using HMI.CO.Trend;
using HMI.Resources.UserControls.MO;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_HZ")]
    public partial class MO_HZ
    {

        BackgroundWorker AddObjects = new BackgroundWorker();
        BackgroundWorker ClearObjects = new BackgroundWorker();
        IVariableService VS = ApplicationService.GetService<IVariableService>();

        private IVariable IVModus;

        public MO_HZ()
        {
            InitializeComponent();
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
            Clocked = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 HMI.PC.Clocked";

            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;
            
            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;
           

        }

       

       


        public string Modus
        {
            get { return ""; }
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    IVModus = VS.GetVariable(value);
                    IVModus.Change += IVModus_ValueChanged;
                }
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "HZ1",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text6",
                Min = 0,
                Max = 300,
                BackViewName = "MO_HZ"
            });
        }
     
       

      
        private void IVModus_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                Mod.Visibility = Visibility.Visible;
                switch ((byte)e.Value)
                {
                    case 1:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Green_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text1";
                        break;
                    case 2:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text2"; break;
                    case 3:
                        Mod.Background = (Brush)Application.Current.FindResource("FP_Yellow_Gradient");
                        txt.LocalizableText = "@Lists.Modus.Text3"; break;
                    default: Mod.Visibility = Visibility.Collapsed; break;
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
                            if (!ClearObjects.IsBusy)
                                ClearObjects.RunWorkerAsync();
                        }
                    }
                }
                IVClocked.Value = false;
            }
            
        }

        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!AddObjects.IsBusy)
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

            for (int i = 0; i <= 9; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                short Coord = (short)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].Status.Coordinate");
                HZTray T = null;
                Dispatcher.InvokeAsync(delegate
                {
                    T = GetHZTray(i, Coord);

                    switch (Coord)
                    {
                        case 0: T.Margin = new Thickness(668, 698, 0, 0); break;
                        case 1: T.Margin = new Thickness(942, 698, 0, 0); break;
                        case 3: T.Margin = new Thickness(668, 563, 0, 0); break;
                        case 2: T.Margin = new Thickness(942, 563, 0, 0); break;
                        case 4: T.Margin = new Thickness(668, 428, 0, 0); break;
                        case 5: T.Margin = new Thickness(942, 428, 0, 0); break;
                        case 7: T.Margin = new Thickness(668, 293, 0, 0); break;
                        case 6: T.Margin = new Thickness(942, 293, 0, 0); break;
                        case 8: T.Margin = new Thickness(668, 158, 0, 0); break;
                        case 9: T.Margin = new Thickness(942, 158, 0, 0); break;
                    }

                    T.HorizontalAlignment = HorizontalAlignment.Left;
                    T.VerticalAlignment = VerticalAlignment.Top;

                    Trays.Children.Add(T);
                });

                uint ChargeNr = (uint)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i.ToString() + "].PD.Charge.Data.Charge");
   
                if (ChargeNr == 1)
                {

                    Dispatcher.InvokeAsync(delegate
                    {
                        Tracking TT = new Tracking()
                        {
                            Data = new Track((uint)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i.ToString() + "].PD.Header.BoxId"))
                        };

                        switch (Coord)
                        {
                            case 0: TT.X1 = 130; TT.Y1 = -2; TT.X2 = 340; TT.Y2 = 40; TT.Width = 340; TT.Margin = new Thickness(340, 644, 0, 0); break;
                            case 1: TT.X1 = 0; TT.Y1 = 40; TT.X2 = 150; TT.Y2 = -2; TT.Width = 350; TT.Margin = new Thickness(1156, 644, 0, 0); break;
                            case 3: TT.X1 = 130; TT.Y1 = -2; TT.X2 = 340; TT.Y2 = 40; TT.Width = 340; TT.Margin = new Thickness(340, 509, 0, 0); break;
                            case 2: TT.X1 = 0; TT.Y1 = 40; TT.X2 = 150; TT.Y2 = -2; TT.Width = 350; TT.Margin = new Thickness(1156, 509, 0, 0); break;
                            case 4: TT.X1 = 130; TT.Y1 = -2; TT.X2 = 340; TT.Y2 = 40; TT.Width = 340; TT.Margin = new Thickness(340, 374, 0, 0); break;
                            case 5: TT.X1 = 0; TT.Y1 = 40; TT.X2 = 150; TT.Y2 = -2; TT.Width = 350; TT.Margin = new Thickness(1156, 374, 0, 0); break;
                            case 7: TT.X1 = 130; TT.Y1 = -2; TT.X2 = 340; TT.Y2 = 40; TT.Width = 340; TT.Margin = new Thickness(340, 239, 0, 0); break;
                            case 6: TT.X1 = 0; TT.Y1 = 40; TT.X2 = 150; TT.Y2 = -2; TT.Width = 350; TT.Margin = new Thickness(1156, 239, 0, 0); break;
                            case 8: TT.X1 = 130; TT.Y1 = -2; TT.X2 = 340; TT.Y2 = 40; TT.Width = 340; TT.Margin = new Thickness(340, 104, 0, 0); break;
                            case 9: TT.X1 = 0; TT.Y1 = 40; TT.X2 = 150; TT.Y2 = -2; TT.Width = 350; TT.Margin = new Thickness(1156, 104, 0, 0); break;
                        }
                        TT.Height = 100;
                        TT.VerticalAlignment = VerticalAlignment.Top;
                        TT.HorizontalAlignment = HorizontalAlignment.Left;
                        

                        Trays.Children.Add(TT);
                    });

                }
                Thread.Sleep(250);
            }
        }


        private HZTray GetHZTray(int i, int coord)
        {
            return new HZTray()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Tray.isTray", 
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Charge.isMaterial",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Charge.Layers.Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Charge.Layers.Actual",
                
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[" + i + "].PD.Tray.Functions.Watch",
                Station = 13,
                Place = i,
                Coord= i ,
                Type = "Tray",
                CPU="CPU2",
                Header = "@Status.Text" + (53 + i).ToString()

            };
        }
    }
}



