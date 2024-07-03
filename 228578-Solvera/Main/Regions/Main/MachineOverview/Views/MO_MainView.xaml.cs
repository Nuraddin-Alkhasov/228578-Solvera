using HMI.CO.General;
using HMI.Resources.UserControls.MO;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Logging;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_MainView")]
    public partial class MO_MainView
    {
        BackgroundWorker AddObjects = new BackgroundWorker();
        BackgroundWorker ClearObjects = new BackgroundWorker();
        private readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        private readonly ILoggingService loggingService = ApplicationService.GetService<ILoggingService>();
        
        public MO_MainView()
        {
            InitializeComponent();
            Modus = "CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State";
            ClearObjects.DoWork += ClearObjects_DoWork;
            ClearObjects.RunWorkerCompleted += ClearObjects_RunWorkerCompleted;

            AddObjects.WorkerSupportsCancellation = true;
            AddObjects.DoWork += AddObjects_DoWork;
            AddObjects.RunWorkerCompleted += AddObjects_RunWorkerCompleted;
        }

        MV_LD LD;
        MV_BSMP BSMP;
        MV_CD CD;
        MV_ST ST;
        MV_MCPZWZ MCPZWZ;
        MV_TM TM;
        MV_HZ HZ1;
        MV_CZ MVCZ;
        MV_PO MVPO;
        MV_CI CI;
        MV_US MVUS;

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



        IVariable IVModus;

        
        private IVariable Status;

        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!ClearObjects.IsBusy)
                ClearObjects.RunWorkerAsync(argument: true);

            Status = VS.GetVariable("CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.to.Control voltage.State");
            Status.Change += Status_Change;
        }

        private void ClearObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result) 
            {
                if(!AddObjects.IsBusy)
                    AddObjects.RunWorkerAsync();
            }
        }
        private void ClearObjects_DoWork(object sender, DoWorkEventArgs e)
        {

            Dispatcher.InvokeAsync(delegate
            {
                LayoutRoot.Children.Clear();
            });

            e.Result = e.Argument;

            Thread.Sleep(250);

        }
        short lastState = 9;
        private void Status_Change(object sender, VariableEventArgs e)
        {
            
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue)
            {
              
                switch ((short)e.Value) 
                {
                    case 3:
                        ON.IsDefault = true;
                        ON.IsBlinkEnabled = false;
                        powerOFF.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        if (lastState == 1) 
                        {
                           
                            loggingService.Log("Machine", "OnOff", "@Logging.Machine.Text5", DateTime.Now);
                        }
                        ON.IsDefault = true;
                        ON.IsBlinkEnabled = false;
                        powerOFF.Visibility = Visibility.Hidden;

                        break;
                    case 1:
                        ON.IsBlinkEnabled = true; powerOFF.Visibility = Visibility.Hidden; break;
                    case 0:
                       
                           
                        loggingService.Log("Machine", "OnOff", "@Logging.Machine.Text4", DateTime.Now);
                        
                        ON.IsDefault = false;
                        ON.IsBlinkEnabled = false;
                        powerOFF.Visibility = Visibility.Hidden;

                        break;
                    default: break;

                }
                lastState = (short)e.Value;
            }
        }

        private void LayoutRoot_Unloaded(object sender, RoutedEventArgs e)
        {
            //ClearObjects.RunWorkerAsync(argument: false);
        }
        private void AddObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //
            }
            else if (e.Cancelled)
            {
                ClearObjects.RunWorkerAsync(argument: true);
            }
            else
            {

            }
        }
        private void AddObjects_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                CI = new MV_CI
                {

                    Margin = new Thickness(672, 463, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                LayoutRoot.Children.Add(CI);
            });

            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                MVCZ = new MV_CZ()
                {
                    Margin = new Thickness(1012, 342, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVCZ);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                MCPZWZ = new MV_MCPZWZ()
                {
                    Margin = new Thickness(615, 240, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MCPZWZ);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                HZ1 = new MV_HZ()
                {

                    Margin = new Thickness(1569, 264, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(HZ1);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                MVUS = new MV_US()
                {
                    Margin = new Thickness(742, 418, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVUS);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                TM = new MV_TM()
                {
                    Margin = new Thickness(838, 461, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(TM);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                BSMP = new MV_BSMP
                {
                    Margin = new Thickness(231, 140, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(BSMP);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                MVPO = new MV_PO()
                {
                    Margin = new Thickness(615, 418, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(MVPO);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                ST = new MV_ST
                {
                    Margin = new Thickness(455, 442, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                LayoutRoot.Children.Add(ST);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                CD = new MV_CD
                {
                    Margin = new Thickness(146, 257, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                LayoutRoot.Children.Add(CD);
            });
            if (AddObjects.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(200);
            Dispatcher.InvokeAsync(delegate
            {
                Dispatcher.InvokeAsync(delegate
                {
                    LD = new MV_LD
                    {
                        Margin = new Thickness(63, 395, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    };
                    LayoutRoot.Children.Add(LD);
                });
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SP()
            {
                CPU = "CPU1",
                Station = 8,
                Header = "@Status.Text32",
                Type = "Basket"
            }.Open();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new SP()
            {
                CPU = "CPU2",
                Station = 11,
                Header = "@Status.Text41",
                Type = "Belt"
            }.Open();
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
