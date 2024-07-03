using HMI.CO.General;
using HMI.CO.Recipe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.Language;

namespace HMI.CO.Protocol
{
    public class Box : AdapterBase
    {
        public Box() { }
        public Box(int MR_Id)
        {
            MR = new MR() { Header = new RecipeInfo() { Id = MR_Id } };
        }

        public int Id { set; get; } = -1;
        public int Order_Id { set; get; } = -1;
        public int BoxNr { set; get; } = 0;
        public MR MR { set; get; } = new MR();
        public bool IsError { set; get; } = false;
        public int Charges { set; get; } = 0;
        public float Weight { set; get; } = 0;
        public string Start { set; get; } = "";
        public string End { set; get; } = "";
        public string User { set; get; } = "";
        public List<Charge> ChargesList { set; get; } = new List<Charge>();
        public void FillChargesList()
        {
            List<Charge> temp = new List<Charge>();

            DataTable DT = new MSSQLEAdapter("Orders", "Select * From Charges WHERE Box_Id = " + Id).DB_Output();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Thread.Sleep(20);
                    temp.Add(new Charge()
                    {
                        Id = (int)r["Id"],
                        Order_Id = (int)r["Order_Id"],
                        Box_Id = Id,
                        Start = ((DateTime)r["Start"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        End = r["End"] == DBNull.Value ? "" : ((DateTime)r["End"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        ChargeNr = (int)r["Charge"],
                        Runs = (int)r["Runs"],
                        Weight = (float)r["Weight"],
                        IsError = (bool)r["IsError"],
                        IsOptimized = (bool)r["IsOptimized"],
                        User = (string)r["User"]
                    });

                }

            }
            ChargesList = temp;
        }
        public void SetMR(int MR_Id)
        {
            ILanguageService textService = ApplicationService.GetService<ILanguageService>();
            DataTable temp_MR = new MSSQLEAdapter("Orders", "Select * From Recipes_MR WHERE Id = " + MR_Id).DB_Output();
            Thread.Sleep(20);
            if (temp_MR.Rows.Count > 0)
            {
                DataTable temp_A = new MSSQLEAdapter("Orders", "Select * From Recipes_Article WHERE Id = " + temp_MR.Rows[0]["Article_Id"]).DB_Output();

                MR = new MR()
                {
                    Header = new RecipeInfo()
                    {
                        Id = (int)temp_MR.Rows[0]["Id"],
                        Name = (string)temp_MR.Rows[0]["Name"],
                        Description = temp_MR.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["Description"],
                        LastChanged = ((DateTime)temp_MR.Rows[0]["LastChanged"]).ToString("dd.MM.yyyy HH:mm:ss"),
                        User = temp_MR.Rows[0]["User"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["User"],
                    },
                    Article = new Article()
                    {
                        Header = new RecipeInfo()
                        {
                            Name = (string)temp_A.Rows[0]["Name"],
                            Description = temp_A.Rows[0]["Description"] == DBNull.Value ? "" : (string)temp_A.Rows[0]["Description"]
                        },
                        Info = new ArticleInfo()
                        {
                            Art = new Art()
                            {
                                Name = (string)temp_A.Rows[0]["Art"],
                                Image = (string)temp_A.Rows[0]["Image"]
                            },
                            Size = new Dictionary()
                            {
                                Name = (string)temp_A.Rows[0]["Size"]
                            },
                            Type = new Dictionary()
                            {
                                Name = (string)temp_A.Rows[0]["Type"]
                            }
                        }

                    },

                    Layers = new List<Recipe.Coating>()
                    {
                        new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Name = (string)temp_MR.Rows[0]["C1_N"],
                                Description = temp_MR.Rows[0]["C1_D"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["C1_D"]
                            }

                        },
                        new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Name = temp_MR.Rows[0]["C2_N"]== DBNull.Value ? "" : (string)temp_MR.Rows[0]["C2_N"],
                                Description = temp_MR.Rows[0]["C2_D"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["C2_D"]
                            }

                        },
                        new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Name = temp_MR.Rows[0]["C3_N"]== DBNull.Value ? "" : (string)temp_MR.Rows[0]["C3_N"],
                                Description = temp_MR.Rows[0]["C3_D"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["C3_D"]
                            }

                        },
                        new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Name = temp_MR.Rows[0]["C4_N"]== DBNull.Value ? "" : (string)temp_MR.Rows[0]["C4_N"],
                                Description = temp_MR.Rows[0]["C4_D"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["C4_D"]
                            }

                        },
                        new Recipe.Coating()
                        {
                            Header = new RecipeInfo()
                            {
                                Name = temp_MR.Rows[0]["C5_N"]== DBNull.Value ? "" : (string)temp_MR.Rows[0]["C5_N"],
                                Description = temp_MR.Rows[0]["C5_D"] == DBNull.Value ? "" : (string)temp_MR.Rows[0]["C5_D"]
                            }

                        }
                    }

                };


            }

        }
    }
}
