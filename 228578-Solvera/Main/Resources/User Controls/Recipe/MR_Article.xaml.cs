using HMI.CO.General;
using HMI.CO.Recipe;
using System.Windows;
using System.Windows.Controls;

namespace HMI.Resources.UserControls
{
    public partial class MR_Article : UserControl
    {
        public MR_Article()
        {
            InitializeComponent();
        }


        private Article article = new Article();
        public Article Article
        {
            set
            {
                article = value;
                if (article != null)
                {
                    _name.Value = value.Header.Name;
                    _descr.Value = value.Header.Description;
                    _img.SymbolResourceKey = value.Info.Art.Image;
                }

            }
            get { return article; }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new ObjectAnimator().ShowUIElement(this);
        }


        public override string ToString() { return "MR_Article"; }
    }
}
