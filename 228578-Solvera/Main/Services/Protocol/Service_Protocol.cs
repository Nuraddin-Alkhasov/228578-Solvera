using HMI.CO.Protocol;
using HMI.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Services
{

    [ExportService(typeof(Service_Protocol))]
    [Export(typeof(Service_Protocol))]
    class Service_Protocol : ServiceBase, IProtocol
    {
        private NewLoad NL;
        private NewCharge NC;
        private Coating C;
        private Preheating PZ;
        private Drying WZ;
        private Holding HZ;
        private Cooling CZ;
        private NewRun NR;
        private Unloading U;

        public Service_Protocol()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region OnProject

        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();

            NL = new NewLoad("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.NewLoad")
            {
                Data_1 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Customer.Data1#STRING20"),
                Data_2 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Customer.Data2#STRING20"),
                Data_3 = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD HMI.PC.Customer.Data3#STRING20"),
                MR_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.MRId"),
                Order_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.OrderId"),
                Box_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Header.BoxId"),
            };


            NC = new NewCharge("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.NewCharge")
            {
                Box_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Header.BoxId"),
                Charge_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Header.ChargeId"),
                ChargeNr = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Data.Charge"),
                Run_Id = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Header.RunId"),
                RunNr = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Data.Run"),
                WeightL = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Weight.Left"),
                WeightR = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Weight.Right"),
                Optimized = VS.GetVariable("CPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.isRMO")
            };

            C = new Coating(
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.Coating.Start",
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.Coating.End",
                "CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.Coating.isFault")
            {
                
                Run_Id = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Header.RunId"),
                MR_Id = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Header.MRId"),
                ActualLayer= VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layers.Actual"),
                SetPaintTemp = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Dipping tank.setTemperature"),
                ActualPaintTemp = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Dipping tank.isTemperature"),
                PaintType = VS.GetVariable("CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Dipping tank.Paint"),

                Paints = "CPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Parameter.Dipping tank.Name",
                StartError = 1521,
                EndError = 2032

            };

            PZ = new Preheating(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.PZ.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.PZ.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.PZ.isFault")
            {
                MC_Run_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Header.RunId"),
                PZ_Run_Id = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[6].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[7].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[8].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[9].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[10].Header.RunId"),
                },
                SetPZTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Parameter.Temperature.Set"),
                StartError = 4264,
                EndError = 4391
            };

            WZ = new Drying(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.WZ.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.WZ.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.WZ.isFault")
            {
                WZ_Run_Id = new List<IVariable>()
                { 
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[0].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[1].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[2].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[3].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[4].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[5].Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.02 TO.00 Main.DB TO PD.Place[6].Header.RunId"),






                },
                SetWZTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.03 WZ.01 Air.DB WZ Air HMI.Parameter.Temperature.Set"),
                StartError = 4392,
                EndError = 4519
            };

            HZ = new Holding(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.HZ.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.HZ.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.HZ.isFault")
            {
                HZ_Run_Ids = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[0].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[1].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[2].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[3].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[4].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[5].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[6].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[7].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[8].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.00 Main.DB HZ 1 PD.Place[9].PD.Header.RunId"),
                },
                TH_Run_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.04 TM.00 Main.DB TM PD.Header.RunId"),
                SetHZTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.05 HZ 1.01 Air.DB HZ 1 Air HMI.Parameter.Temperature.Set"),
                StartError = 4520,
                EndError = 4631
            };

            CZ = new Cooling(
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.CZ.Start",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.CZ.End",
                "CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.CZ.isFault")
            {
                CZ_Run_Ids = new List<IVariable>()
                {
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[0].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[1].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[2].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[3].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[4].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[5].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[6].PD.Header.RunId"),
                    VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[7].PD.Header.RunId"),
                },
                TH_Run_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.04 TM.00 Main.DB TM PD.Header.RunId"),
                SetCZTemp = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.01 Air 1.DB CZ Air 1 HMI.Parameter.Temperature.Set"),
                Index = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ PD.Place[0].Status.Coordinate"),
                StartError = 4632,
                EndError = 4951
            };

            NR = new NewRun("CPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.NewRun")
            {
                Charge_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Header.ChargeId"),
                Run_Id = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Header.RunId"),
                RunNr = VS.GetVariable("CPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Data.Run")
            };


            U = new Unloading("CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Protocol.Discharge")
            {
                Run_Id = VS.GetVariable("CPU2.PLC.Blocks.04 Tray handling.08 PO.00 Main.DB PO PD.Header.RunId")
            };
            base.OnLoadProjectCompleted();
        }
        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {

            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {

            base.OnUnloadProjectCompleted();
        }
        #region - - - Event Handlers - - -   

        #endregion

        #region - - - Private Methods - - -   



        #endregion


        #endregion
    }
}
