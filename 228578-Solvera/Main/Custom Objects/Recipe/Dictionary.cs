using VisiWin.ApplicationFramework;
using VisiWin.Language;

namespace HMI.CO.Recipe
{
    public class Dictionary
    {
        ILanguageService textService = ApplicationService.GetService<ILanguageService>();
        public Dictionary()
        {
        }

        public int Id { set; get; } = -1;
        public string Name { set; get; } = "";
        public override string ToString()
        {
            return textService.GetText(Name);
        }
    }
}
