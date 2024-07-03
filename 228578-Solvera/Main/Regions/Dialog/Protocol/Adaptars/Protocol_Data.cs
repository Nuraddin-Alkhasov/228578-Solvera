using HMI.CO.General;
using HMI.CO.Protocol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;


namespace HMI.DialogRegion.Protocol.Adapters
{
    [ExportAdapter("Protocol_Data")]
    public class Protocol_Data : AdapterBase
    {

        public Protocol_Data()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Close = new ActionCommand(CloseExecuted);
            ShowCoating = new ActionCommand(ShowCoatingExecuted);
            ShowPZTrend = new ActionCommand(ShowPZTrendExecuted);
            ShowWZTrend = new ActionCommand(ShowWZTrendExecuted);
            ShowHZTrend = new ActionCommand(ShowHZTrendExecuted);
            ShowCZTrend = new ActionCommand(ShowCZTrendExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private Run selectedRun;
        public Run SelectedRun
        {
            get { return selectedRun; }
            set
            {
                selectedRun = value;

                IsPHZTrend = value.PZTrend.Points.Count > 0;
                IsWZTrend = value.WZTrend.Points.Count > 0;
                IsHZTrend = value.HZTrend.Points.Count > 0;
                IsCZTrend = value.CZTrend.Points.Count > 0;

                OnPropertyChanged("SelectedRun");

            }
        }

        private bool isPHZTrend;
        public bool IsPHZTrend
        {
            get { return isPHZTrend; }
            set
            {

                isPHZTrend = value;
                OnPropertyChanged("IsPHZTrend");

            }
        }

        private bool isWZTrend;
        public bool IsWZTrend
        {
            get { return isWZTrend; }
            set
            {

                isWZTrend = value;
                OnPropertyChanged("IsWZTrend");

            }
        }
        private bool isHZTrend;
        public bool IsHZTrend
        {
            get { return isHZTrend; }
            set
            {

                isHZTrend = value;
                OnPropertyChanged("IsHZTrend");

            }
        }
        private bool isCZTrend;
        public bool IsCZTrend
        {
            get { return isCZTrend; }
            set
            {

                isCZTrend = value;
                OnPropertyChanged("IsCZTrend");

            }
        }
        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Protocol_Data v = (Views.Protocol_Data)iRS.GetView("Protocol_Data");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }
        public ICommand ShowCoating { get; set; }
        private void ShowCoatingExecuted(object parameter)
        {
        }
        public ICommand ShowPZTrend { get; set; }
        private void ShowPZTrendExecuted(object parameter)
        {
            SelectedRun.SelectedTrendId = 1;
            ApplicationService.SetView("DialogRegion2", "Protocol_Trend", SelectedRun);
        }
        public ICommand ShowWZTrend { get; set; }
        private void ShowWZTrendExecuted(object parameter)
        {
            SelectedRun.SelectedTrendId = 2;
            ApplicationService.SetView("DialogRegion2", "Protocol_Trend", SelectedRun);
        }
        public ICommand ShowHZTrend { get; set; }
        private void ShowHZTrendExecuted(object parameter)
        {
            SelectedRun.SelectedTrendId = 3;
            ApplicationService.SetView("DialogRegion2", "Protocol_Trend", SelectedRun);
        }
        public ICommand ShowCZTrend { get; set; }
        private void ShowCZTrendExecuted(object parameter)
        {
            SelectedRun.SelectedTrendId = 4;
            ApplicationService.SetView("DialogRegion2", "Protocol_Trend", SelectedRun);
        }



        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            SelectedRun = ApplicationService.ObjectStore.GetValue("Protocol_Data_KEY") as Run;
            ApplicationService.ObjectStore.Remove("Protocol_Data_KEY");
            Views.Protocol_Data v = (Views.Protocol_Data)iRS.GetView("Protocol_Data");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        #endregion


    }
}