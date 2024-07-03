using HMI.Resources.UserControls.MO;
using System;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;

namespace HMI.MainRegion.MO.Views
{

    [ExportView("MO_Paints_1")]
    public partial class MO_Paints_1
    {
        public MO_Paints_1()
        {
            InitializeComponent();
          
        }

        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Task obTask = Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {

                    await Application.Current.Dispatcher.InvokeAsync((Action)delegate
                    {
                        PaintType PT = new PaintType()
                        {
                            Header = "@Lists.Paint.Text" + (2 + i).ToString(),
                            Paint = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name[" + i + "]",
                            Type = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Color[" + i + "]",
                            Type2 = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Base / Top[" + i + "]",
                           // IsSolvent = "CPU1.PLC.Blocks.03 Coating.10 DT.DB Vat Para Temp.Solvent[" + i + "]",
                            WatchDog = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.isMonitoring[" + i + "]",
                            MaxCoatings = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.maxCoatings[" + i + "]",
                            Pump = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Pump[" + i + "].isOn",
                            PumpOn = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Pump[" + i + "].On time",
                            PumpOff = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Pump[" + i + "].Off time",
                            WZUL = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Temperature[" + i + "].UL",
                            WZ = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Temperature[" + i + "].Set",
                            WZLL = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Temperature[" + i + "].LL",
                            CZUL = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Cooling[" + i + "].UL",
                            CZ = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Cooling[" + i + "].Set",
                            CZLL = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Cooling[" + i + "].LL",
                            ViscosityH = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Viscosity[" + i + "].Hours",
                            ViscosityM = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Viscosity[" + i + "].Minutes",
                        };
                        P.Children.Add(PT);
                    });
                    await Task.Delay(300);
                }
            });
        }

        private void View_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Task obTask = Task.Run(async () =>
            {
                await Dispatcher.InvokeAsync((Action)delegate
                {
                    P.Children.Clear();
                });
            });
        }
    }
}