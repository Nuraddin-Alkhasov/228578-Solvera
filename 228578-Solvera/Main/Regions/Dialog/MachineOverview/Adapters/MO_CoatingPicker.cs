using HMI.CO.General;
using HMI.CO.Recipe;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Logging;

namespace HMI.DialogRegion.MO.Adapters
{
    [ExportAdapter("MO_CoatingPicker")]
    public class MO_CoatingPicker : AdapterBase
    {

        public MO_CoatingPicker()
        {

            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            loggingService = GetService<ILoggingService>();
            SelectCoatingRecipe = new ActionCommand(SelectCoatingRecipeExecuted);
            Load = new ActionCommand(LoadExecuted);
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -

        private ILoggingService loggingService;
        private readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

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

        Coating c { set; get; } = new Coating();
        public Coating C
        {
            get { return c; }
            set
            {
                c = value;
                OnPropertyChanged("C");
            }
        }

        string user { set; get; } = "";
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        #endregion

        #region - - - Commands - - -

        public ICommand Close { get; set; }
        private void CloseExecuted(object parameter)
        {

            Views.MO_CoatingPicker v = (Views.MO_CoatingPicker)iRS.GetView("MO_CoatingPicker");
            new ObjectAnimator().CloseDialog1(v, v.border);

        }

        public ICommand SelectCoatingRecipe { get; set; }
        private void SelectCoatingRecipeExecuted(object parameter)
        {

            ApplicationService.SetView("DialogRegion2", "Coating_Selector", "MO_CoatingPicker");

        }

        public ICommand Load { get; set; }
        private void LoadExecuted(object parameter)
        {
            Wait = Visibility.Visible;
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Coating.00 Main.DB Coating Main PD.Charge.Layers.Actual", 0);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Coating.00 Main.DB Coating Main PD.Header.Data.MRId", C.Header.Id);
            ApplicationService.SetVariableValue("CPU1.PLC.Blocks.03 Coating.00 Main.DB Coating Main HMI.PC.Handshake.to PC.GetRecipe", true);

            Task obTask = Task.Run(async () =>
            {
                await Task.Delay(1000);
                Wait = Visibility.Hidden;
                CloseExecuted(null);
            });

        }

        #endregion

        #region - - - Event handlers - - -

        protected override void OnViewLoaded(object sender, ViewLoadedEventArg e)
        {
            User = ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString();

            Views.MO_CoatingPicker v = (Views.MO_CoatingPicker)iRS.GetView("MO_CoatingPicker");
            new ObjectAnimator().OpenDialog(v, v.border);

            base.OnViewLoaded(sender, e);
        }

        #endregion

        #region - - - Methods - - -
       

        #endregion


    }
}