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
    [ExportAdapter("Protocol_MR")]
    public class Protocol_MR : AdapterBase
    {

        public Protocol_MR()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        private Box selectedBox;
        public Box SelectedBox
        {
            get { return selectedBox; } 
            set
            {

                selectedBox = value;
                OnPropertyChanged("SelectedBox");

            }
        }


        #endregion

        #region - - - Commands - - -
        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.Protocol_MR v = (Views.Protocol_MR)iRS.GetView("Protocol_MR");
            new ObjectAnimator().CloseDialog1(v, v.border);
        }


        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            SelectedBox = ApplicationService.ObjectStore.GetValue("Protocol_MR_KEY") as Box;
            ApplicationService.ObjectStore.Remove("Protocol_MR_KEY");
            Views.Protocol_MR v = (Views.Protocol_MR)iRS.GetView("Protocol_MR");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -

        #endregion


    }
}