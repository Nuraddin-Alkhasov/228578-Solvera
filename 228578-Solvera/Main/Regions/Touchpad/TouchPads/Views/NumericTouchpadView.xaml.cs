using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using HMI.CO.General;

namespace HMI.TouchpadRegion
{
    [ExportView("NumericTouchpadView")]
    public partial class NumericTouchpadView
    {

        public NumericTouchpadView() { InitializeComponent(); }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            string CHANNELNAME_TOUCHTARGET = "vw:TouchTarget";


            if (ApplicationService.ObjectStore.ContainsKey(CHANNELNAME_TOUCHTARGET))
            {
                numericVarIn = ApplicationService.ObjectStore.GetValue(CHANNELNAME_TOUCHTARGET) as NumericVarIn;
                lblNumericPadDescription.Text = numericVarIn.LabelText;

                ApplicationService.ObjectStore.Remove(CHANNELNAME_TOUCHTARGET);

            }
            new ObjectAnimator().OpenKeyboard(this, border);

        }
        private void TouchKeyboard_Close(object sender, RoutedEventArgs e)
        {
            if (numericVarIn != null)
                if (numericVarIn.Value < numericVarIn.LimitMin || numericVarIn.Value > numericVarIn.LimitMax)
                {
                    var rand = new Random();
                    var temp = numericVarIn.Value;
                    numericVarIn.Value = rand.Next((int)numericVarIn.LimitMin, (numericVarIn.LimitMax < numericVarIn.LimitMin) ? (int)numericVarIn.LimitMin : (int)numericVarIn.LimitMax);
                    numericVarIn.Value = temp;
                }
            new ObjectAnimator().CloseKeyboard(this, border);
        }
    }
}