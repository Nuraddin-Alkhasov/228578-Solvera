using HMI.CO.General;
using HMI.CO.Recipe;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Language;

namespace HMI.Resources.UserControls
{
    public partial class MR_Coating : UserControl
    {
        public MR_Coating()
        {
            InitializeComponent();
            DataContext = null;
        }
        ILanguageService textService = ApplicationService.GetService<ILanguageService>();
        public string LocalizableLabelText
        {
            set
            {
                A.LocalizableLabelText = value;
            }
        }

        public int Id { set; get; }
        private Coating coating = new Coating();
        public Coating Coating
        {
            set
            {
                coating = value;
                if (coating != null)
                {
                    _name.Value = value.Header.Name;
                    _descr.Value = value.Header.Description;
                    if (value.VWRecipe.Data != "")
                    {
                        VWVariable aa = value.VWRecipe.VWVariables.First(x => x.Item.ToString() == "CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD HMI.PC.Station.Step[0].Dipping.DT");
                        _tank.Value = textService.GetText("@Lists.Tank.Text" + aa.Value.ToString());
                    }
                    else { _tank.Value = ""; }
                    _paint.SelectedIndex = -1;
                    if (value.Header.Name.Length > 1)
                    {
                        _img.SymbolResourceKey = "R_Coating";

                    }
                    else
                    {
                        _img.SymbolResourceKey = "Nor";

                    }
                }

            }
            get { return coating; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
            _paint.ItemsSource = null;
            _paint.StateList = GetPaintTypes();
            foreach (State i in _paint.StateList)
            {
                if (i.Value == Coating.Paint_Id.ToString()) { _paint.SelectedItem = i; }
            }
        }


        public override string ToString() { return "MR_Coating"; }

        private void _paint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_paint.SelectedItem != null) 
            {
                Coating.Paint_Id = Convert.ToInt32(((State)_paint.SelectedItem).Value);

            }
            
        }

        private StateCollection GetPaintTypes()
        {
            StateCollection Temp_SC = new StateCollection();
            for (int i = 1; i <= 10; i++)
            {

                string temp = ApplicationService.GetVariableValue("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + i + "]").ToString();
                if (temp != "")
                {
                    Temp_SC.Add(new State()
                    {
                        Text = temp,
                        Value = i.ToString()
                    });
                }
            }
            return Temp_SC;
        }
    }
}
