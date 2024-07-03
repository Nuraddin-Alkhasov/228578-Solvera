using System;
using System.Windows;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using System.Linq;
using HMI.CO.General;

namespace HMI.TouchpadRegion
{
    [ExportView("AlphaTouchpadView")]
    public partial class AlphaTouchpadView
    {
        public AlphaTouchpadView() { InitializeComponent(); } 

        private void TouchKeyboard_Close(object sender, RoutedEventArgs e)
        {
            if (textVarIn1.Value != null)
            {
                if (textVarIn1.TextLengthMin != 0 && textVarIn1.TextLengthMax != 0)
                    if (textVarIn1.Value.Length < textVarIn1.TextLengthMin || textVarIn1.Value.Length > textVarIn1.TextLengthMax)
                    {
                        Random rand = new Random();
                        string temp = textVarIn1.Value;

                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                        textVarIn1.Value = new string(Enumerable.Repeat(chars, (int)textVarIn1.TextLengthMax).Select(s => s[rand.Next(s.Length)]).ToArray());
                        textVarIn1.Value = temp;
                    }
            }

            new ObjectAnimator().CloseKeyboard(this, border);
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            string CHANNELNAME_TOUCHTARGET = "vw:TouchTarget";
            if (ApplicationService.ObjectStore.ContainsKey(CHANNELNAME_TOUCHTARGET))
            {
                textVarIn1 = (TextVarIn)ApplicationService.ObjectStore.GetValue(CHANNELNAME_TOUCHTARGET);
                if (textVarIn1 != null)
                {
                    lblAlphaPadDescription.Text = textVarIn1.LabelText;
                    ApplicationService.ObjectStore.Remove(CHANNELNAME_TOUCHTARGET);
                }
            }
            new ObjectAnimator().OpenKeyboard(this, border);

        }
    }
}