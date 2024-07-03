using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;

namespace HMI.Resources.UserControls
{
    public partial class ArticleGeneral : UserControl
    {
        public ArticleGeneral()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);

            Task obTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    ThicknessAnimation a = SetMargin(new Thickness(0, 700, 0, 0), new Thickness(0, 0, 0, 0), 200);
                    BeginAnimation(MarginProperty, a);
                });
            });
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
    }
}
