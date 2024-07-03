using System.Windows;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using HMI.CO.General;

namespace HMI.TouchpadRegion
{
    [ExportView("PasswordTouchpadView")]
    public partial class PasswordTouchpadView
    {
        public PasswordTouchpadView()
        {
            InitializeComponent();
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            string CHANNELNAME_TOUCHTARGET = "vw:TouchTarget";
            if (ApplicationService.ObjectStore.ContainsKey(CHANNELNAME_TOUCHTARGET))
            {
                TextVarIn varIn = ApplicationService.ObjectStore.GetValue(CHANNELNAME_TOUCHTARGET) as TextVarIn;
                lblAlphaPadDescription.LocalizableText = varIn.LocalizableLabelText;

                ApplicationService.ObjectStore.Remove(CHANNELNAME_TOUCHTARGET);
            }
            new ObjectAnimator().OpenKeyboard(this, border);
        }

        private void TouchKeyboard_Close(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().CloseKeyboard(this, border);
        }
    }
}