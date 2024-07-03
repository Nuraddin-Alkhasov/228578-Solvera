using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.Resources.UserControls.MO
{
    public partial class M_WorkMode_R : UserControl
    {
        public M_WorkMode_R()
        {
            InitializeComponent();
            TS.LanguageChanged += TS_LanguageChanged;
        }
        #region - - - Properties - - -

        IVariableService VS = ApplicationService.GetService<IVariableService>();
        ILanguageService TS = ApplicationService.GetService<ILanguageService>();
        IVariable SS;
        IVariable WM;

        string header { set; get; } = "";
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                H.Header = TS.GetText(value);
            }
        }

        string automaric { set; get; } = "";
        public string Automatic
        {
            get { return automaric; }
            set
            {
                automaric = value;
            }
        }

        string manual { set; get; } = "";
        public string Manual
        {
            get { return manual; }
            set
            {
                manual = value;
            }
        }

        string setUP { set; get; } = "";
        public string SetUp
        {
            get { return setUP; }
            set
            {
                setUP = value;
            }
        }

        public string Start
        {
             get { return ""; } 
            set
            {
                btnstart.VariableName = value;
            }
        }

        public string StartStatus
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    SS = VS.GetVariable(value);
                    SS.Change += SS_Change;
                }
            }
        }

        public string Stop
        {
            set
            {
                btnstop.VariableName = value;
            }
        }

        public string WorkingModeStatus
        {
            set
            {
                if (VS.IsExistingVariable(value))
                {
                    WM = VS.GetVariable(value);
                    WM.Change += WorkingMode_ValueChanged;
                }
            }
        }

        #endregion

        #region - - - Event Handlers - - -

        private void TS_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            H.Header = TS.GetText(Header);
        }

        private void SS_Change(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                switch ((short)e.Value)
                {
                    case 0: btnstart.IsDefault = false; btnstart.IsBlinkEnabled = false; break;
                    case 1: btnstart.IsDefault = true; btnstart.IsBlinkEnabled = false; break;
                    case 2: btnstart.IsDefault = false; btnstart.IsBlinkEnabled = true; break;
                }
            }
        }

        private void WorkingMode_Click(object sender, RoutedEventArgs e)
        {
            if ((short)WM.Value == 3)
            {
                ApplicationService.SetVariableValue(SetUp, false);
                ApplicationService.SetVariableValue(Manual, true);
                ApplicationService.SetVariableValue(Automatic, false);
            }
            else
            {
                ApplicationService.SetVariableValue(SetUp, false);
                ApplicationService.SetVariableValue(Manual, false);
                ApplicationService.SetVariableValue(Automatic, true);
            }
        }

        private void WorkingMode_ValueChanged(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good)
            {
                switch ((short)e.Value)
                {
                    default:                    //no mode
                        WorkingMode.LocalizableText = "@Lists.OperatingMode.Text1";
                        BtnToInvisible();
                        BtnToCenter();
                        WorkingMode.Tag = "0";
                        break;
                    case 1:                    //hand 
                        WorkingMode.LocalizableText = "@Lists.OperatingMode.Text2";
                        BtnToInvisible();
                        BtnToCenter();
                        WorkingMode.Tag = "1";
                        break;
                    case 2:                    //set up
                        WorkingMode.LocalizableText = "@Lists.OperatingMode.Text3";
                        BtnToInvisible();
                        BtnToCenter();
                        WorkingMode.Tag = "2";
                        break;
                    case 3:                    //auto
                        WorkingMode.LocalizableText = "@Lists.OperatingMode.Text4";
                        btnToVisible();
                        btnToLeft();
                        WorkingMode.Tag = "3";
                        break;
                }
            }
        }

        #endregion

        #region - - - Methods - - -
        private void btnToVisible()
        {
            btnstart.IsEnabled = true;
            btnstop.IsEnabled = true;
            btnstart.Visibility = Visibility.Visible;
            btnstop.Visibility = Visibility.Visible;

            var animation = new DoubleAnimation
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3),
            };

            btnstart.BeginAnimation(UIElement.OpacityProperty, animation);
            btnstop.BeginAnimation(UIElement.OpacityProperty, animation);
        }
        private void BtnToInvisible()
        {
            btnstart.IsEnabled = false;
            btnstop.IsEnabled = false;

            var animation = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
            };

            btnstart.BeginAnimation(UIElement.OpacityProperty, animation);
            btnstop.BeginAnimation(UIElement.OpacityProperty, animation);

            Task obTask = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(800);
                Application.Current.Dispatcher.InvokeAsync((Action)delegate
                {
                    if (btnstart.Opacity == 0)
                    {
                        btnstart.Visibility = Visibility.Collapsed;
                        btnstop.Visibility = Visibility.Collapsed;
                    }

                });
            });

        }
        private void BtnToCenter()
        {
            var sb = new Storyboard();
            var ta = new ThicknessAnimation();
            ta.BeginTime = new TimeSpan(0);
            ta.SetValue(Storyboard.TargetNameProperty, "WorkingMode");
            Storyboard.SetTargetProperty(ta, new PropertyPath(MarginProperty));

            ta.To = new Thickness(25, 0, 0, 0);
            ta.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            sb.Children.Add(ta);
            sb.Begin(this);


        }
        private void btnToLeft()
        {
            var sb = new Storyboard();
            var ta = new ThicknessAnimation();
            ta.BeginTime = new TimeSpan(0);
            ta.SetValue(Storyboard.TargetNameProperty, "WorkingMode");
            Storyboard.SetTargetProperty(ta, new PropertyPath(MarginProperty));

            ta.To = new Thickness(0, 0, 0, 0);
            ta.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            sb.Children.Add(ta);
            sb.Begin(this);


        }

        #endregion
    }
}
