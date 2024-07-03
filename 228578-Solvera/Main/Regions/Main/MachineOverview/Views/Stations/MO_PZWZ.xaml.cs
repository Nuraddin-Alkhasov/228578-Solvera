using HMI.CO.General;
using HMI.CO.Trend;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using HMI.Resources.UserControls.MO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.MainRegion.MO
{

    [ExportView("MO_PZWZ")]
    public partial class MO_PZWZ
    {
        BackgroundWorker AddObjects = new BackgroundWorker();
        BackgroundWorker ClearObjects = new BackgroundWorker();
        IVariableService VS = ApplicationService.GetService<IVariableService>();
        public MO_PZWZ()
        {
            InitializeComponent();
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
            Clocked = "CPU2.PLC.Blocks.04 Tray handling.02 TO.01 Chain.DB TO Chain HMI.PC.Clocked";

            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;

            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;
        }

        private IVariable IVModus;

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 8,
                Header = "@Status.Text32",
                Type = "Basket",
                CPU="CPU1"
            }.Open();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP
            {
                Station = 11,
                Header = "@Status.Text41",
                Type = "Belt",
                CPU="CPU2"
            }.Open();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "PZ",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text4",
                Min = 0,
                Max = 120,
                BackViewName = "MO_PZWZ"
            });
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MainRegion", "Trend",
            new TrendData()
            {
                ArchiveName = "WZ",
                TrendName_1 = "AV",
                CurveTag_1 = "@TrendSystem.Text1",
                TrendName_2 = "SV",
                CurveTag_2 = "@TrendSystem.Text2",
                Header = "@TrendSystem.Text5",
                Min = 0,
                Max = 120,
                BackViewName = "MO_PZWZ"
            });
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

     

        private void fEmpty_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text57", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Mode.Empty", true);
            }
        }

        private void dEmpty_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxView.Show("@MachineOverview.Text53", "@MachineOverview.Text57", MessageBoxButton.YesNo, MessageBoxResult.No, MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                ApplicationService.SetVariableValue("CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.from.Option.Run Empty", true);
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

            for (int i = 0; i <= 10; i++)
            {
                if (AddObjects.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                PZWZTray T = null;
                Dispatcher.InvokeAsync(delegate
                {
                    T = GetPZWZTray(i);
                    switch (i)
                    {
                        case 0: T.Margin = new Thickness(1590, 455, 0, 0); break;
                        case 1: T.Margin = new Thickness(1497, 455, 0, 0); break;
                        case 2: T.Margin = new Thickness(1404, 455, 0, 0); break;
                        case 3: T.Margin = new Thickness(1311, 455, 0, 0); break;
                        case 4: T.Margin = new Thickness(1218, 455, 0, 0); break;
                        case 5: T.Margin = new Thickness(1125, 455, 0, 0); break;
                        case 6: T.Margin = new Thickness(1032, 455, 0, 0); break;
                        case 7: T.Margin = new Thickness(939, 455, 0, 0); break;
                        case 8: T.Margin = new Thickness(846, 455, 0, 0); break;
                        case 9: T.Margin = new Thickness(753, 455, 0, 0); break;
                        case 10: T.Margin = new Thickness(660, 455, 0, 0); break;
                    }

                    T.HorizontalAlignment = HorizontalAlignment.Left;
                    T.VerticalAlignment = VerticalAlignment.Top;

                    Trays.Children.Add(T);
                });

  

                uint ChargeNr = (uint)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Data.Charge");
                if (ChargeNr == 1)
                {
                    Dispatcher.InvokeAsync(delegate
                    {
                        Tracking TT = new Tracking()
                        {
                            Data = new Track((uint)ApplicationService.GetVariableValue("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Header.BoxId"))
                        };
                        switch (i)
                        {
                            case 10: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(749, 391, 0, 0); break;
                            case 9: TT.Y1 = 90; TT.X2 = 70; TT.Width = 200; TT.Height = 150; TT.Margin = new Thickness(843, 326, 0, 0); break;
                            case 8: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(935, 391, 0, 0); break;
                            case 7: TT.Y1 = 90; TT.X2 = 70; TT.Width = 200; TT.Height = 150; TT.Margin = new Thickness(1029, 326, 0, 0); break;
                            case 6: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(1121, 391, 0, 0); break;
                            case 5: TT.Y1 = 90; TT.X2 = 70; TT.Width = 200; TT.Height = 150; TT.Margin = new Thickness(1216, 326, 0, 0); break;
                            case 4: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(1308, 391, 0, 0); break;
                            case 3: TT.Y1 = 90; TT.X2 = 70; TT.Width = 200; TT.Height = 150; TT.Margin = new Thickness(1401, 326, 0, 0); break;
                            case 2: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(1493, 391, 0, 0); break;
                            case 1: TT.Y1 = 90; TT.X2 = 70; TT.Width = 200; TT.Height = 150; TT.Margin = new Thickness(1587, 326, 0, 0); break;
                            case 0: TT.Y1 = 25; TT.X2 = 35; TT.Width = 120; TT.Height = 85; TT.Margin = new Thickness(1679, 391, 0, 0); break;

                        }

                        TT.X1 = 0;
                        TT.Y2 = -2;
                        TT.VerticalAlignment = VerticalAlignment.Top;
                        TT.HorizontalAlignment = HorizontalAlignment.Left;

                        Trays.Children.Add(TT);
                    });

                 
                }

                Thread.Sleep(250);
            }

        }
        private void IVModus_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                Mod.Visibility = Visibility.Visible;
                fEmpty.IsDefault = false;
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
                        txt.LocalizableText = "@Lists.Modus.Text3"; fEmpty.IsDefault = true; break;
                    default: Mod.Visibility = Visibility.Collapsed; break;
                }
            }
        }


        private PZWZTray GetPZWZTray(int i)
        {
            return new PZWZTray()
            {
                IsTray = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Tray.isTray", 
                IsMaterial = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Charge.isMaterial",
                SetLayer = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Layers.Set",
                ActualLayer = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Charge.Layers.Actual",
                
                IsDischarge = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Tray.Functions.Discharge",
                IsWatch = "CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[" + i + "].Tray.Functions.Watch",
                Station = 12,
                Place = i,
                Type = "Tray",
                CPU = "CPU2",
                Header = "@Status.Text" + (42+i).ToString()
            };

        }
    }
}




