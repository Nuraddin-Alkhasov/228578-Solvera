using HMI.CO.General;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;

namespace HMI.Resources.UserControls
{
    public partial class ArticleRecipe : UserControl
    {
        public ArticleRecipe()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Task obTask = Task.Run(() =>
            {
                new ObjectAnimator().ShowUIElement(this);

                Application.Current.Dispatcher.InvokeAsync(delegate
                {
                    ThicknessAnimation a = SetMargin(new Thickness(0, 500, 0, 0), new Thickness(0, 0, 0, 0), 200);
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
