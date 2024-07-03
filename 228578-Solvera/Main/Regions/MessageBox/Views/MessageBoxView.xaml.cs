using HMI.Resources;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MessageBoxRegion.Views
{

    [ExportView("MessageBoxView")]
    public partial class MessageBoxView
    {

        public static bool isOpen;

        public MessageBoxView()
        {
            InitializeComponent();
            DataContext = new Adapters.MessageBox();

        }



        public static MessageBoxResult Show(string text, string caption, MessageBoxButton type = MessageBoxButton.OK, MessageBoxResult defaultResult = MessageBoxResult.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            DialogParams dp = new DialogParams
            {
                HeaderText = caption,
                Content = text,
                Type = (InternalDialogButtons)type,
                DefaultResult = (InternalDialogResult)defaultResult,
                Icon = icon,
                Modal = true
            };

            object result = null;
            ApplicationService.ObjectStore.Remove("MessageBoxView_RESULT");
            ApplicationService.SetView("MessageBoxRegion", "MessageBoxView", dp);


            while ((result = ApplicationService.ObjectStore["MessageBoxView_RESULT"]) == null)
            {
                Adapters.MessageBox.DoEvents();
            }

            ApplicationService.ObjectStore.Remove("MessageBoxView_RESULT");
            ApplicationService.ObjectStore.Remove("MessageBoxView_KEY");



            return (MessageBoxResult)result;
        }


    }
}