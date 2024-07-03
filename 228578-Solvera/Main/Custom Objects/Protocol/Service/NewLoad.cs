using HMI.CO.General;
using HMI.CO.Recipe;
using HMI.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.CO.Protocol
{
    public class NewLoad
    {
        public NewLoad()
        {
        }

        public NewLoad(string V)
        {
            IVariableService VS = ApplicationService.GetService<IVariableService>();
            Event = VS.GetVariable(V);
            Event.Change += Event_NewLoad;
        }

        #region - - - Properties - - - 
        IVariable Event;
        public IVariable Data_1 { set; get; }
        public IVariable Data_2 { set; get; }
        public IVariable Data_3 { set; get; }
        public string MR { set; get; }
        public IVariable MR_Id { set; get; }
        int Article_Id { set; get; }
        public IVariable Order_Id { set; get; }
        public IVariable Box_Id { set; get; }
        private int Protocol_MR_Id { set; get; }
        #endregion

        #region - - - Event Handlers - - - 
        private void Event_NewLoad(object sender, VariableEventArgs e)
        {
            if (e.Quality.Data == DataQuality.Good && e.Value != e.PreviousValue && (bool)e.Value)
            {
                Event.Value = false;
                Task.Run(() =>
                {
                    DoWork();
                });
            }
        }

        #endregion

        #region - - - Methods - - - 

        public void DoWork()
        {
            Order_Id.Value = NewOrder();
            Box_Id.Value = NewBox();
            MR_Id.Value = NewMR();
            NewArticle();
        }

        public void SetMRIdToPLC()
        {
         
            MR_Id.Value = GetMRId();
        }
        private int NewOrder()
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                             "FROM Orders " +
                                             "WHERE Data_1 ='" + Data_1.Value + "'; ").DB_Output();
            if (DT.Rows.Count == 0)
            {
                new MSSQLEAdapter("Orders", "INSERT " +
                                      "INTO Orders " +
                                      "(Data_1, Data_2, Data_3, [User]) " +
                                      "VALUES ('" +
                                      Data_1.Value + "','" +
                                      Data_2.Value + "','" +
                                      Data_3.Value + "','" +
                                      ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();

                DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                       "FROM Orders " +
                                       "WHERE Data_1 ='" + Data_1.Value + "'; ").DB_Output();
            }

            return (int)DT.Rows[0]["Id"];

        }
        private int NewBox()
        {
            DataTable DT = new MSSQLEAdapter("Orders", "SELECT MAX(Box) as Box " +
                                             "FROM Boxes " +
                                             "WHERE Order_Id ='" + Order_Id.Value + "'; ").DB_Output();

            int Box = 1;
            if (DT.Rows[0][0] != DBNull.Value)
            {
                Box = (int)DT.Rows[0]["Box"] + 1;
            }
            new MSSQLEAdapter("Orders", "INSERT " +
                                 "INTO Boxes " +
                                 "(Order_Id, Box, [User]) " +
                                 "VALUES (" +
                                 Order_Id.Value + "," +
                                 Box + ",'" +
                                 ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString() + "')").DB_Input();

            DT = new MSSQLEAdapter("Orders", "SELECT * " +
                                   "FROM Boxes " +
                                   "WHERE Order_Id = " + Order_Id.Value + " AND " +
                                   "Box = " + Box + "; ").DB_Output();

            return (int)DT.Rows[0]["Id"];
        }
        private int NewMR()
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                        "FROM Recipes_MR " +
                                                        "WHERE Id = '" + MR_Id.Value + "'").DB_Output();
            Article_Id = (int)DT.Rows[0]["Article_Id"];

            List<Recipe.Coating> cl = new List<Recipe.Coating>();
            for (int i = 1; i <= 5; i++)
            {
                if ((int)DT.Rows[0]["C" + i.ToString() + "_Id"] != -1)
                {
                    DataTable temp = new MSSQLEAdapter("Recipes", "SELECT * " +
                                                            "FROM Recipes_Coating " +
                                                            "WHERE Id = '" + DT.Rows[0]["C" + i.ToString() + "_Id"].ToString() + "'").DB_Output();
                    cl.Add(new Recipe.Coating()
                    {
                        Header = new RecipeInfo()
                        {
                            Id = (int)DT.Rows[0]["C" + i.ToString() + "_Id"],
                            Name = (string)temp.Rows[0]["Name"],
                            Description = (string)temp.Rows[0]["Description"],
                        }

                    });
                }
                else { cl.Add(new Recipe.Coating()); }
            
            }

            new MSSQLEAdapter("Orders", "INSERT " +
                    "INTO Recipes_MR " +
                    "(Order_Id, Box_Id, " +
                    "[Name], [Description], " +
                    "C1_Id, C1_N, C1_D, " +
                    "C2_Id, C2_N, C2_D, " +
                    "C3_Id, C3_N, C3_D, " +
                    "C4_Id, C4_N, C4_D, " +
                    "C5_Id, C5_N, C5_D, " +
                    "LastChanged, [User]) " +
                    "VALUES (" +
                    Order_Id.Value.ToString() + "," + Box_Id.Value.ToString() + ",'" +
                    (string)DT.Rows[0]["Name"] + "','" + (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "'," +
                    cl[0].Header.Id + ",'" + cl[0].Header.Name + "','" + cl[0].Header.Description + "'," +
                    cl[1].Header.Id + ",'" + cl[1].Header.Name + "','" + cl[1].Header.Description + "'," +
                    cl[2].Header.Id + ",'" + cl[2].Header.Name + "','" + cl[2].Header.Description + "'," +
                    cl[3].Header.Id + ",'" + cl[3].Header.Name + "','" + cl[3].Header.Description + "'," +
                    cl[4].Header.Id + ",'" + cl[4].Header.Name + "','" + cl[4].Header.Description + "','" +
                    GetDataTimeFormated((DateTime)DT.Rows[0]["LastChanged"]) + "','" +
                    (string)DT.Rows[0]["User"] + "'); ").DB_Input();

            DataTable pmid = new MSSQLEAdapter("Orders", "SELECT * " +
                                  "FROM Recipes_MR " +
                                  "WHERE Order_Id = " + Order_Id.Value + " AND " +
                                  "Box_Id = " + Box_Id.Value + "; ").DB_Output();
            Protocol_MR_Id =(int)pmid.Rows[0]["Id"];

            return (int)DT.Rows[0]["Id"];
        }

        private int GetMRId()
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                        "FROM Recipes_MR " +
                                                        "WHERE Name = '" + MR + "'").DB_Output();
            if (DT.Rows.Count > 0)
            {
                return (int)DT.Rows[0]["Id"];
            }
            else 
            {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text2", MessageBoxIcon.Error);
                return 0; 
            }

            
        }
        private void NewArticle()
        {
            DataTable DT = new MSSQLEAdapter("Recipes", "SELECT *" +
                                                        "FROM Recipes_Article " +
                                                        "WHERE Id = '" + Article_Id + "'").DB_Output();

            new MSSQLEAdapter("Orders", "INSERT " +
                    "INTO Recipes_Article " +
                    "(Order_Id, Box_Id, MR_Id, " +
                    "[Name], [Description], " +
                    "Art_Id, Type_Id, Size_Id, VWRecipe," +
                    "LastChanged, [User]) " +
                    "VALUES (" +
                    Order_Id.Value.ToString() + "," +
                    Box_Id.Value.ToString() + "," +
                    Protocol_MR_Id + ",'" +
                    (string)DT.Rows[0]["Name"] + "','" +
                    (DT.Rows[0]["Description"] == DBNull.Value ? "" : (string)DT.Rows[0]["Description"]) + "'," +
                    (int)DT.Rows[0]["Art_Id"] + "," +
                    (int)DT.Rows[0]["Type_Id"] + "," +
                    (int)DT.Rows[0]["Size_Id"] + ",'" +
                    (string)DT.Rows[0]["VWRecipe"] + "','" +
                    GetDataTimeFormated((DateTime)DT.Rows[0]["LastChanged"]) + "','" +
                    (string)DT.Rows[0]["User"] + "'); ").DB_Input();

        }

        private string GetDataTimeFormated(DateTime t)
        {
            return t.ToString("yyyyMMdd HH:mm:ss");
        }

        #endregion

    }
}
