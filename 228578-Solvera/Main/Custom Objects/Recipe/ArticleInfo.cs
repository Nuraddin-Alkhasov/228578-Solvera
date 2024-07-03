using VisiWin.ApplicationFramework;

namespace HMI.CO.Recipe
{
    public class ArticleInfo
    {

        public ArticleInfo()
        {
        }

        public Art Art { set; get; } = new Art();
        public Dictionary Size { set; get; } = new Dictionary();
        public Dictionary Type { get; set; } = new Dictionary();
        public override string ToString()
        {
            return Art.Name;
        }
    }
}
