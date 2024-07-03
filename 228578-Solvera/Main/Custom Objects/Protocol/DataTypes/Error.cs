namespace HMI.CO.Protocol
{
    public class Error
    {

        public Error()
        {
        }

        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int Charge_Id { set; get; } = -1;
        public int Run_Id { set; get; } = -1;
        public int ErrorNr { set; get; } = 0;
        public string ActivationTime { set; get; } = "";
        public string DeactivationTime { set; get; } = "";
        public string LocalizableText { set; get; } = "";
        public string User { set; get; } = "";
    }
}
