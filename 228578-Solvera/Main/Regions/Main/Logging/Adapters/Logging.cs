using HMI.CO.General;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;

namespace HMI.MainRegion.Logging.Adapters
{
    [ExportAdapter("Logging")]
    public class Logging : AdapterBase
    {

        public Logging()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }
            loggingService = GetService<ILoggingService>();
            OpenFilter = new ActionCommand(OpenFilterExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private readonly ILoggingService loggingService;

        private IEnumerable<IHistoricalLoggingEntry> loggingEntries = null;
        public IEnumerable<IHistoricalLoggingEntry> LoggingEntries
        {
            get { return loggingEntries; }
            private set
            {
                if (loggingEntries != value)
                {
                    loggingEntries = value;
                    OnPropertyChanged("LoggingEntries");
                }
            }
        }

        private Visibility wait { get; set; } = Visibility.Hidden;
        public Visibility Wait
        {
            get { return wait; }
            set
            {
                wait = value;
                OnPropertyChanged("Wait");
            }
        }

        #endregion

        #region - - - Commands - - - 
        public ICommand OpenFilter { get; set; }

        private void OpenFilterExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion1", "Logging_Filter");
        }
        #endregion

        #region - - - Event Handlers - - -
        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
                RequestLoggingEntries(loggingService.CreateHistoricalLoggingFilter(DateTime.Now.AddHours(-24), DateTime.Now));
            }
            base.OnViewLoaded(sender, e);
        }

        protected override void OnViewUnloaded(object sender, ViewUnloadedEventArg e)
        {
            if (sender.GetType().Name == e.View.GetType().Name)
            {
            }
            base.OnViewUnloaded(sender, e);
        }
        private void GetLoggingEntriesAsyncCompleted(object sender, GetHistoricalLoggingEntriesCompletedEventArgs e)
        {
            LoggingEntries = e.HistoricalLoggingEntries.OrderByDescending(x => x.TimeStamp).ToList();
            Wait = Visibility.Hidden;

            if (e.Success == HistoricalLoggingEntriesSuccess.Failed)
            {
                new MessageBoxTask("@Logging.LoggingFilterView.GetLogEntriesError", "@Logging.LoggingFilterView.Caption", MessageBoxIcon.Error);
            }
            loggingService.GetHistoricalLoggingEntriesAsyncCompleted -= GetLoggingEntriesAsyncCompleted;
        }
        #endregion

        #region - - - Methods - - -

        public void RequestLoggingEntries(IHistoricalLoggingFilter f)
        {
            Wait = Visibility.Visible;
            loggingService.GetHistoricalLoggingEntriesAsyncCompleted += GetLoggingEntriesAsyncCompleted;
            var X = loggingService.GetHistoricalLoggingEntriesAsync(f);
        }

        #endregion

    }
}