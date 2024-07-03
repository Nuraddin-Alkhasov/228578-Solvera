namespace HMI.CO.Reports
{
    public class ParameterInfo
    {
        public ParameterInfo(string name, string localiableString)
        {
            this.Name = name;
            this.LocaliableString = localiableString;
        }
        public string Name { get; private set; }       

        public string LocaliableString { get; private set; }
    }
}
