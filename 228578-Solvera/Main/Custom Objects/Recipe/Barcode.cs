namespace HMI.CO.Recipe
{
    class Barcode
    {
        public Barcode()
        {
        }
        public int Id { set; get; } = -1;
        public string BC { set; get; } = "";
        public MR MR { set; get; } = new MR();


    }
}
