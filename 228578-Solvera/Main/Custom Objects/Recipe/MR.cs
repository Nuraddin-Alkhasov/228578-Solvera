using HMI.CO.General;
using HMI.CO.Protocol;
using HMI.Resources;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.CO.Recipe
{
    public class MR
    {

        public MR()
        {
        }
        #region - - - Properties - - - 
        public RecipeInfo Header { set; get; } = new RecipeInfo();
        public Article Article { set; get; } = new Article();
        public List<Coating> Layers { set; get; } = new List<Coating>();

        #endregion

        #region - - - Methods - - - 

        public void LoadToPLC(string Data1, string Data2, string Data3, string Order_Id, string Box_Id, string MR_Id)
        {
            //IVariableService VS = ApplicationService.GetService<IVariableService>();
            //new NewLoad()
            //{
            //    Data_1 = ApplicationService.GetVariableValue(Data1).ToString(),
            //    Data_2 = ApplicationService.GetVariableValue(Data2).ToString(),
            //    Data_3 = ApplicationService.GetVariableValue(Data3).ToString(),
            //    MR = Header.Name,
            //    MR_Id = VS.GetVariable(MR_Id),
            //    Order_Id = VS.GetVariable(Order_Id),
            //    Box_Id = VS.GetVariable(Box_Id),
            //}.DoWork();
        }

        public override string ToString()
        {
            return Header.Id.ToString() + " - " + Header.Name;
        }

        #endregion

    }
}
