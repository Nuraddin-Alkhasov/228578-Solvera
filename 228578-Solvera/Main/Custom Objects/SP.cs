using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;

namespace HMI.CO.General
{
    public class SP
    {

        public SP()
        {
            
        }
        public int Station { set; get; } = 0;
        public int Place { set; get; } = 0;
        public string Header { set; get; } = "";
        public string Type { set; get; } = "";

        public string CPU { set; get; } = "";

        private string VStation = "";
        private string VPlace = "";

        public void Open()
        {
            
            VStation = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.Station"; 
            switch (Station) 
            {
                case 6: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.ST"; break;
                case 12: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.TO"; break;
                case 13: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.HZ"; break;
                case 15: VPlace = CPU + ".PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.from.CZ"; break;
            }

            
                ApplicationService.SetVariableValue(VStation, Station);
                ApplicationService.SetVariableValue(VPlace, Place);
           

            switch (CPU) 
            {
                case "CPU1":
                   
                   
                  
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "MO_Status_1", this);
                        });
                    });
                    break;
                case "CPU2":
                   

                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);

                        await Application.Current.Dispatcher.InvokeAsync(delegate
                        {
                            ApplicationService.SetView("DialogRegion1", "MO_Status_2", this);
                        });
                    });
                    break;
                    default: break;
            }
            
        }
        public void Close() 
        {
            ApplicationService.SetVariableValue(VStation, 0);
            ApplicationService.SetVariableValue(VPlace, 0);
        }
    }
}
