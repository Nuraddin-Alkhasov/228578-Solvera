
namespace HMI.CO.General
{
    public class WaitData
    {
        public string LocalizableText;
        public int Type;
        public string Ergospin;
        public WaitData(int _Type, string _LocalizableText, string _ergospin)
        {
            Type = _Type;
            LocalizableText = _LocalizableText;
            Ergospin = _ergospin;
        }
    }
}
