using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;

namespace HMI.Resources.UserControls
{
    [ExportView("EmptyView")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EmptyView
    {
        public EmptyView()
        {
            InitializeComponent();
        }
    }
}