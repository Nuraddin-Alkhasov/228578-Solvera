using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Resources.UserControls
{
    public partial class CoatingStep1 : UserControl
    {
        public CoatingStep1()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Type", 1);
        }


        #region - - - Properties - - -

        public IRecipeClass Class = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Coating");

        #endregion

        #region - - - Event Handlers - - -
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }

        private void StepType_Changed(object sender, SelectionChangedEventArgs e)
        {
            ThicknessAnimation a;
            ThicknessAnimation b;
            ResetData(_type.SelectedIndex);
            switch (_type.SelectedIndex)
            {
                case 0:
                    pic.SymbolResourceKey = "Nor";
                    Task obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {

                            a = SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                            if (Type1.Visibility == Visibility.Visible)
                            {
                                a.Completed += (o, s) => { Type1.Visibility = Visibility.Collapsed; };
                                Type1.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                a.Completed += (o, s) => { Type2.Visibility = Visibility.Collapsed; };
                                Type2.BeginAnimation(MarginProperty, a);
                            }
                        });
                    });
                    break;
                case 1:
                    pic.SymbolResourceKey = "Dip";
                    obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            if (Type2.Visibility == Visibility.Visible)
                            {
                                a = SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                                a.Completed += (o, s) =>
                                {
                                    Type2.Visibility = Visibility.Collapsed;
                                    Type1.Visibility = Visibility.Visible;
                                    b = SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                    Type1.BeginAnimation(MarginProperty, b);
                                };
                                Type2.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                Type1.Visibility = Visibility.Visible;
                                b = SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                Type1.BeginAnimation(MarginProperty, b);
                            }

                        });
                    });
                    break;
                case 2:
                    pic.SymbolResourceKey = "Spin";
                    obTask = Task.Run(() =>
                    {
                        Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            if (Type1.Visibility == Visibility.Visible)
                            {
                                a = SetMargin(new Thickness(0, 30, 0, 0), new Thickness(0, 710, 0, 0), 200);
                                a.Completed += (o, s) =>
                                {
                                    Type1.Visibility = Visibility.Collapsed;
                                    Type2.Visibility = Visibility.Visible;
                                    b = SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                    Type2.BeginAnimation(MarginProperty, b);
                                };
                                Type1.BeginAnimation(MarginProperty, a);
                            }
                            else
                            {
                                Type2.Visibility = Visibility.Visible;
                                b = SetMargin(new Thickness(0, 710, 0, 0), new Thickness(0, 30, 0, 0), 400);
                                Type2.BeginAnimation(MarginProperty, b);
                            }

                        });
                    }); break;
                default:
                    break;
            }
        }

        private void TankType_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tanks.SelectedIndex == 1)
            {
                A50_Click("a", null);
                astraight.IsEnabled = false;
                a40.IsEnabled = false;
                a50.IsEnabled = true;
            }
            else
            {
                astraight.IsEnabled = true;
                a40.IsEnabled = true;
                a50.IsEnabled = true;
            }
        }

        private void Angle_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((float)e.Value == 0.0f)
            {
                astraight.IsChecked = true; Astraight_Click(null, null);
            }
            if ((float)e.Value == 40.0f)
            {
                a40.IsChecked = true; A40_Click(null, null);
            }
            if ((float)e.Value == 50.0f)
            {
                a50.IsChecked = true; A50_Click(null, null);
            }
        }

        private void Astraight_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null) { angle.Value = 0; }
            streight.Visibility = Visibility.Collapsed;
            stime.Visibility = Visibility.Visible;
            stime.LocalizableLabelText = "@RecipeSystem.Text56";
            stime.RawLimitMin = 5;
            stime.RawLimitMax = 59;
            dtime.Visibility = Visibility.Collapsed;
            border1.Visibility = Visibility.Collapsed;
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight time", 0);

        }

        private void A40_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null) { angle.Value = 40; }
            streight.Visibility = Visibility.Visible;
            stime.Visibility = Visibility.Visible;
            stime.RawLimitMin = 0;
            stime.RawLimitMax = 0;
            dtime.Visibility = Visibility.Visible;
            stime.LocalizableLabelText = "@RecipeSystem.Text70";
            border1.Visibility = Visibility.Visible;
        }

        private void A50_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null) { angle.Value = 50; }
            streight.Visibility = Visibility.Collapsed;
            stime.Visibility = Visibility.Collapsed;
            dtime.Visibility = Visibility.Visible;
            border1.Visibility = Visibility.Collapsed;
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight time", 0);

        }

        #endregion

        #region - - - Methods - - -

        private ThicknessAnimation SetMargin(Thickness _From, Thickness _To, int _T)
        {
            return new ThicknessAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromMilliseconds(_T),
            };
        }

        private void ResetData(int _type)
        {
            switch (_type)
            {
                case 1: ResetSpinning(); break;
                case 2: ResetDipping(); break;
                default: ResetDipping(); ResetSpinning(); break;
            }
        }
        private void ResetDipping()
        {
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Angle", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Reverse", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Draining", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Planet", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.Straight time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.DT", 0);
        }
        private void ResetSpinning()
        {
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.1.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.1.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.2.Planet", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.2.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.2.Time", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.3.Rotor", 0);
            Class.SetValue("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Spinning.3.Time", 0);
        }
        #endregion

    }
}
