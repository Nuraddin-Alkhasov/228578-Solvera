using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace HMI.CO.General
{
    internal class MessageBoxTask
    {
        public MessageBoxTask(string Message, string Header, MessageBoxIcon Icon)
        {
            Task obTask = Task.Run(async () =>
            {
                while (ObjectAnimator.MBisAnimated)
                {
                    await Task.Delay(1000);
                }

                await Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      MessageBoxView.Show(Message, Header, MessageBoxButton.OK, MessageBoxResult.OK, Icon);
                  });

            });
        }
        public MessageBoxTask(Exception ex, string param, MessageBoxIcon Icon)
        {
            Task obTask = Task.Run(async () =>
            {
                while (ObjectAnimator.MBisAnimated)
                {
                    await Task.Delay(1000);
                }

                await Application.Current.Dispatcher.InvokeAsync(delegate
                  {
                      string Message = "Error at line - " + new StackTrace(ex, true).GetFrame(new StackTrace(ex, true).FrameCount - 1).GetFileLineNumber().ToString() + " - " + Environment.NewLine;
                      Message += "Message : " + ex.Message + Environment.NewLine;
                      Message += param == "" ? "" : param + Environment.NewLine;
                      Message += "Stacktrace : " + ex.StackTrace + Environment.NewLine;
                      MessageBoxView.Show(Message, " - Exception - " + DateTime.Now.ToString() + " -", MessageBoxButton.OK, MessageBoxResult.OK, Icon);
                  });

            });
        }
    }
}
