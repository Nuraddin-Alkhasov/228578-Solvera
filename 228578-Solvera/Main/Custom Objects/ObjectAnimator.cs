using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;

namespace HMI.CO.General
{
    public class ObjectAnimator
    {
        public static bool MBisAnimated;
        public void OpenDialog(UIElement Background, UIElement Dialog)
        {

            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation opacity = SetAnimation(Background.Opacity, 1, 200);
                      DoubleAnimation scale = SetAnimation(0.3, 1, 200);

                      Dialog.RenderTransform = new ScaleTransform();
                      Dialog.RenderTransformOrigin = new Point(1, 0.5);

                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                      Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                  });
            });
        }
        public void CloseDialog1(UIElement Background, UIElement Dialog)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation opacity = SetAnimation(Background.Opacity, 0, 100);
                      opacity.Completed += (o, s) => { ApplicationService.SetView("DialogRegion1", "EmptyView"); };
                      DoubleAnimation scale = SetAnimation(1, 0.3, 100);

                      Dialog.RenderTransform = new ScaleTransform();
                      Dialog.RenderTransformOrigin = new Point(0, 0.5);

                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                      Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                  });
            });


        }
        public void CloseDialog2(UIElement Background, UIElement Dialog)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetAnimation(Background.Opacity, 0, 100);
                    opacity.Completed += (o, s) => { ApplicationService.SetView("DialogRegion2", "EmptyView"); };
                    DoubleAnimation scale = SetAnimation(1, 0.3, 100);

                    Dialog.RenderTransform = new ScaleTransform();
                    Dialog.RenderTransformOrigin = new Point(0, 0.5);

                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                    Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });


        }
        public void OpenKeyboard(UIElement Background, UIElement Dialog)
        {

            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetAnimation(Background.Opacity, 1, 200);
                    DoubleAnimation scale = SetAnimation(0.3, 1, 200);


                    Dialog.RenderTransform = new ScaleTransform();
                    Dialog.RenderTransformOrigin = new Point(1, 0.5);

                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                    Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });
        }
        public void CloseKeyboard(UIElement Background, UIElement Dialog)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetAnimation(Background.Opacity, 0, 100);
                    opacity.Completed += (o, s) => { ApplicationService.SetView("TouchpadRegion", "EmptyView"); };
                    DoubleAnimation scale = SetAnimation(1, 0.3, 100);

                    Dialog.RenderTransform = new ScaleTransform();
                    Dialog.RenderTransformOrigin = new Point(0, 0.5);

                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                    Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                    Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });


        }
        public void OpenMessageBox(UIElement Background, UIElement Dialog)
        {
            MBisAnimated = true;
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation opacity = SetAnimation(Background.Opacity, 1, 200);
                      DoubleAnimation scale = SetAnimation(0.3, 1, 200);
                      opacity.Completed += (o, s) => { MBisAnimated = false; };

                      Dialog.RenderTransform = new ScaleTransform();
                      Dialog.RenderTransformOrigin = new Point(1, 0.5);

                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                      Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                      Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                  });
            });
        }
        public void CloseMessageBox(UIElement Background, UIElement Dialog)
        {
            MBisAnimated = true;
            Task obTask = Task.Run(() =>
           {
               Application.Current.Dispatcher.InvokeAsync(delegate
                 {
                     DoubleAnimation opacity = SetAnimation(Background.Opacity, 0, 100);
                     opacity.Completed += (o, s) => { ApplicationService.SetView("MessageBoxRegion", "EmptyView"); MBisAnimated = false; };
                     DoubleAnimation scale = SetAnimation(1, 0.3, 100);

                     Dialog.RenderTransform = new ScaleTransform();
                     Dialog.RenderTransformOrigin = new Point(0, 0.5);

                     Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scale);
                     Dialog.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scale);
                     Background.BeginAnimation(UIElement.OpacityProperty, opacity);
                 });
           });
        }
        public void ShowUIElement(UIElement UIe)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    UIe.Visibility = Visibility.Visible;
                    DoubleAnimation opacity = SetAnimation(UIe.Opacity, 1, 200);
                    UIe.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });
        }
        public void HideUIElement(UIElement UIe)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetAnimation(UIe.Opacity, 0, 100);
                    opacity.Completed += (o, s) => { UIe.Visibility = Visibility.Collapsed; };
                    UIe.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });
        }

        public void ShowMOElement(UIElement UIe)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    UIe.Visibility = Visibility.Visible;
                    DoubleAnimation opacity = SetAnimation(UIe.Opacity, 1, 500);
                    UIe.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });
        }
        public void HideMOElement(UIElement UIe)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetAnimation(UIe.Opacity, 0, 250);
                    opacity.Completed += (o, s) => { UIe.Visibility = Visibility.Collapsed; };
                    UIe.BeginAnimation(UIElement.OpacityProperty, opacity);
                });
            });
        }
        public void BlinkUIElement(UIElement UIe)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation opacity = SetOpacityForever(UIe.Opacity, 0, 500);
                    UIe.BeginAnimation(VisiWin.Controls.TextVarOut.OpacityProperty, opacity);
                });
            });
        }
        public void OpenMenu(Grid border, UIElement b1, UIElement b2)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation widthresize = SetAnimation(border.Width, 185, 200);
                      widthresize.Completed += (o, s) => { };
                      b1.Visibility = Visibility.Visible;
                      b2.Visibility = Visibility.Collapsed;
                      border.BeginAnimation(FrameworkElement.WidthProperty, widthresize);
                  });
            });
        }

        public void CloseMenu(Grid border, UIElement b1, UIElement b2)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation widthresize = SetAnimation(border.Width, 0, 100);
                      widthresize.Completed += (o, s) => { };
                      b1.Visibility = Visibility.Collapsed;
                      b2.Visibility = Visibility.Visible;
                      border.BeginAnimation(FrameworkElement.WidthProperty, widthresize);
                  });
            });


        }

        public void OpenAppBar(AppBarRegion.Views.AppBar ab, UIElement b1, UIElement b2)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      DoubleAnimation widthresize = SetAnimation(ab.ActualWidth, 220, 200);
                      widthresize.Completed += (o, s) => { };
                      b1.Visibility = Visibility.Visible;
                      b2.Visibility = Visibility.Collapsed;
                      ab.BeginAnimation(FrameworkElement.WidthProperty, widthresize);
                  });
            });
        }

        public void CloseAppBar(AppBarRegion.Views.AppBar ab, UIElement b1, UIElement b2)
        {
            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    DoubleAnimation widthresize = SetAnimation(ab.ActualWidth, 88, 100);
                    widthresize.Completed += (o, s) => { };
                    b1.Visibility = Visibility.Collapsed;
                    b2.Visibility = Visibility.Visible;
                    ab.BeginAnimation(FrameworkElement.WidthProperty, widthresize);
                });
            });


        }

        private DoubleAnimation SetAnimation(double _From, double _To, int _T)
        {
            return new DoubleAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromMilliseconds(_T),
            };
        }

        private DoubleAnimation SetOpacityForever(double _From, double _To, int _T)
        {
            return new DoubleAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromMilliseconds(_T),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
        }

        private ThicknessAnimation SetMargin(Thickness _From, Thickness _To, int _T)
        {
            return new ThicknessAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromMilliseconds(_T),
            };
        }
        private ColorAnimation SetColorAnimation(Color _To, int _T)
        {
            return new ColorAnimation
            {
                To = _To,
                Duration = TimeSpan.FromSeconds(_T),
            };
        }

    }
}
