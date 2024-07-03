using HMI.CO.General;
using HMI.MessageBoxRegion.Views;
using HMI.Resources;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;

namespace HMI.MessageBoxRegion.Adapters
{
    [ExportAdapter("MessageBox")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MessageBox : AdapterBase
    {

        public MessageBox()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            CloseMB = new ActionCommand(CloseMBExecuted);

        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        DialogParams dbParams = null;
        public string HeaderLocalizableText
        {
            get { return (string)GetValue(HeaderLocalizableTextProperty); }
            set { SetValue(HeaderLocalizableTextProperty, value); } 
        }
        public static readonly DependencyProperty HeaderLocalizableTextProperty = DependencyProperty.Register("HeaderLocalizableText", typeof(string), typeof(MessageBox), new PropertyMetadata(""));
        public string HeaderText
        {
            get
            {
                return (string)GetValue(HeaderTextProperty);
            }

            set
            {
                SetValue(HeaderTextProperty, value);
            }
        }
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(MessageBox), new PropertyMetadata(""));

        public string Content
        {
            get
            {
                return (string)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(string), typeof(MessageBox), new PropertyMetadata(""));

        public string Icon
        {
            get
            {
                return (string)GetValue(IconProperty);
            }
            set { SetValue(IconProperty, value); } 
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(MessageBox), new PropertyMetadata(null));

        public Visibility IconVisible
        {
            get
            {
                return (Visibility)GetValue(IconVisibleProperty);
            }

            set { SetValue(IconVisibleProperty, value); } 
        }
        public static readonly DependencyProperty IconVisibleProperty = DependencyProperty.Register("IconVisible", typeof(Visibility), typeof(MessageBox), new PropertyMetadata(Visibility.Collapsed));

        public Visibility LeftButtonVisible
        {
            get
            {
                return (Visibility)GetValue(LeftButtonVisibleProperty);
            }
            set { SetValue(LeftButtonVisibleProperty, value); } 
        }
        public static readonly DependencyProperty LeftButtonVisibleProperty = DependencyProperty.Register("LeftButtonVisible", typeof(Visibility), typeof(MessageBox), new PropertyMetadata(Visibility.Visible));

        public string LeftButtonLocalizableText
        {
            get
            {
                return (string)GetValue(LeftButtonLocalizableTextProperty);
            }
            set { SetValue(LeftButtonLocalizableTextProperty, value); } 
        }
        public static readonly DependencyProperty LeftButtonLocalizableTextProperty = DependencyProperty.Register("LeftButtonLocalizableText", typeof(string), typeof(MessageBox), new PropertyMetadata(""));

        public Visibility MiddleButtonVisible
        {
            get
            {
                return (Visibility)GetValue(MiddleButtonVisibleProperty);
            }

            set { SetValue(MiddleButtonVisibleProperty, value); } 
        }
        public static readonly DependencyProperty MiddleButtonVisibleProperty = DependencyProperty.Register("MiddleButtonVisible", typeof(Visibility), typeof(MessageBox), new PropertyMetadata(Visibility.Visible));

        public string MiddleButtonLocalizableText
        {
            get
            {
                return (string)GetValue(MiddleButtonLocalizableTextProperty);
            }

            set { SetValue(MiddleButtonLocalizableTextProperty, value); }
        }
        public static readonly DependencyProperty MiddleButtonLocalizableTextProperty = DependencyProperty.Register("MiddleButtonLocalizableText", typeof(string), typeof(MessageBox), new PropertyMetadata(""));

        public Visibility RightButtonVisible
        {
            get
            {
                return (Visibility)GetValue(RightButtonVisibleProperty);
            }
            set { SetValue(RightButtonVisibleProperty, value); } 
        }
        public static readonly DependencyProperty RightButtonVisibleProperty = DependencyProperty.Register("RightButtonVisible", typeof(Visibility), typeof(MessageBox), new PropertyMetadata(Visibility.Visible));

        public string RightButtonLocalizableText
        {
            get
            {
                return (string)GetValue(RightButtonLocalizableTextProperty);
            }
            set { SetValue(RightButtonLocalizableTextProperty, value); } 
        }
        public static readonly DependencyProperty RightButtonLocalizableTextProperty = DependencyProperty.Register("RightButtonLocalizableText", typeof(string), typeof(MessageBox), new PropertyMetadata(""));

        #endregion

        #region - - - Commands - - -

        public ICommand CloseMB { get; set; }
        private void CloseMBExecuted(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Left": ApplicationService.ObjectStore.SetValue("MessageBoxView_RESULT", InternalDialogResult.Yes); break;
                case "Middle": ApplicationService.ObjectStore.SetValue("MessageBoxView_RESULT", InternalDialogResult.Cancel); break;
                case "Right": ApplicationService.ObjectStore.SetValue("MessageBoxView_RESULT", InternalDialogResult.No); break;
                default:
                    ApplicationService.ObjectStore.SetValue("MessageBoxView_RESULT", dbParams.DefaultResult);
                    break;
            }

            MessageBoxView mbv = (MessageBoxView)iRS.GetView("MessageBoxView");
            new ObjectAnimator().CloseMessageBox(mbv, mbv.border);
        }

        #endregion

        #region - - - Methods - - -



        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            dbParams = ApplicationService.ObjectStore.GetValue("MessageBoxView_KEY") as DialogParams;
            ApplicationService.ObjectStore.Remove("MessageBoxView_KEY");

            HeaderLocalizableText = (string.IsNullOrEmpty(dbParams.HeaderText) || !dbParams.HeaderText.StartsWith("@")) ? "" : dbParams.HeaderText;
            HeaderText = (string.IsNullOrEmpty(dbParams.HeaderText) || dbParams.HeaderText.StartsWith("@")) ? "" : dbParams.HeaderText;

            ILanguageService textService = ApplicationService.GetService<ILanguageService>();

            if (dbParams.Content.StartsWith("@"))
            {
                Content = textService.GetText(dbParams.Content);
            }
            else
            {
                Content = dbParams.Content;
            }




            switch (dbParams.Icon)
            {
                case MessageBoxIcon.Asterisk: Icon = "MBAsterixIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Error: Icon = "MBErrorIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Exclamation: Icon = "MBExclamationIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Hand: Icon = "MBHandIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Information: Icon = "MBInformationIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Question: Icon = "MBQuestionIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Stop: Icon = "MBStopIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.Warning: Icon = "MBWarningIcon"; IconVisible = Visibility.Visible; break;
                case MessageBoxIcon.None: Icon = ""; IconVisible = Visibility.Collapsed; break;
                default: Icon = ""; IconVisible = Visibility.Collapsed; break;
            }

            switch (dbParams.Type)
            {
                case InternalDialogButtons.OK:
                    LeftButtonVisible = Visibility.Collapsed;
                    MiddleButtonVisible = Visibility.Visible;
                    RightButtonVisible = Visibility.Collapsed;
                    MiddleButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdOK";
                    break;

                case InternalDialogButtons.OKCancel:
                    LeftButtonVisible = Visibility.Visible;
                    LeftButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdOK";
                    MiddleButtonVisible = Visibility.Collapsed;
                    RightButtonVisible = Visibility.Visible;
                    RightButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdCancel";
                    break;
                case InternalDialogButtons.YesNo:
                    LeftButtonVisible = Visibility.Visible;
                    LeftButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdYes";
                    MiddleButtonVisible = Visibility.Collapsed;
                    RightButtonVisible = Visibility.Visible;
                    RightButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdNo";
                    break;
                case InternalDialogButtons.YesNoCancel:
                    LeftButtonVisible = Visibility.Visible;
                    LeftButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdYes";
                    MiddleButtonVisible = Visibility.Visible;
                    MiddleButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdNo";
                    RightButtonVisible = Visibility.Visible;
                    RightButtonLocalizableText = "@[ClientSystem].Dialogs.Common.cmdCancel";
                    break;
                case InternalDialogButtons.Custom:
                    break;
                default:
                    break;
            }

            MessageBoxView mbv = (MessageBoxView)iRS.GetView("MessageBoxView");
            new ObjectAnimator().OpenMessageBox(mbv, mbv.border);

            base.OnViewLoaded(sender, e);
        }




        #endregion

        #region - - - DoEvents - - - 

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]

        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);

            Thread.Sleep(10);
        }

        public static object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
        #endregion
    }
}