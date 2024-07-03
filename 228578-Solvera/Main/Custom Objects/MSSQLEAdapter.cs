using System;
using System.Data;
using System.Data.SqlClient;
using HMI.Resources;

namespace HMI.CO.General
{
    class MSSQLEAdapter
    {
        SqlConnection Con { get; set; }
        SqlCommand Cmd { get; set; }
        SqlDataAdapter DA { get; set; }

        string Sql { get; set; }

        public MSSQLEAdapter(string _db, string _sql)
        {
            switch (_db)
            {
                case "Orders": Con = new SqlConnection(new Resources.LocalResources().Paths.MSSQLE.ProtocolConnectionString); break;
                case "Recipes": Con = new SqlConnection(new Resources.LocalResources().Paths.MSSQLE.RecipesConnectionString); break;
            }
            Sql = _sql;
        }
        public bool DB_Input()
        {

            try
            {
                Con.Open();
                Cmd = Con.CreateCommand();
                Cmd.CommandText = Sql;
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception e)
            {
                Con.Close();
                new MessageBoxTask(DateTime.Now.ToString() + Environment.NewLine + "  -   -   -   -" + Environment.NewLine + Sql.Substring(0, 200) + Environment.NewLine + "  -   -   -   -" + Environment.NewLine + e.ToString(), "Error", MessageBoxIcon.Error);
                return false;
            }

        }

        public DataTable DB_Output()
        {
            DataTable DT = new DataTable();
            try
            {
                Con.Open();
                Cmd = Con.CreateCommand();

                DA = new SqlDataAdapter(Sql, Con);
                DA.Fill(DT);
                Con.Close();
            }
            catch (Exception e)
            {
                Con.Close();
                new MessageBoxTask(DateTime.Now.ToString() + Environment.NewLine + "  -   -   -   -" + Environment.NewLine + Sql + Environment.NewLine + "  -   -   -   -" + Environment.NewLine + e.ToString(), "Error", MessageBoxIcon.Error);
            }
            return DT;
        }
    }
}
