using VisiWin.ApplicationFramework;
using VisiWin.Language;

namespace HMI.CO.Recipe
{
    public class Art
    {
        ILanguageService textService = ApplicationService.GetService<ILanguageService>();
        public Art()
        {
        }
        public int Id { set; get; } = -1;
        public string Name { set; get; } = "";
        public string Image { set; get; } = "Nor";
        public override string ToString()
        {
            return textService.GetText(Name);
        }
    }
}
