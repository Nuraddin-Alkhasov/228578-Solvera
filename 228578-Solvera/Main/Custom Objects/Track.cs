using System.Data;

namespace HMI.CO.General
{
    public class Track
    {
        public string Data_1 { set; get; }
        public string Data_2 { set; get; }
        public string MR { set; get; }
        public string Article { set; get; }
        public int Charges { set; get; }
       
        public Track(uint Box_Id)
        {
            DataTable Box = new MSSQLEAdapter("Orders", "SELECT * " +
                                            "FROM Boxes " +
                                            "WHERE Id =" + Box_Id + ";").DB_Output();
            if (Box.Rows.Count > 0) 
            {
                Charges = (int)Box.Rows[0]["Charges"];

                DataTable Order = new MSSQLEAdapter("Orders", "SELECT * " +
                                              "FROM Orders " +
                                              "WHERE Id =" + (int)Box.Rows[0]["Order_Id"] + ";").DB_Output();
                Data_1 = (string)Order.Rows[0]["Data_1"];
                Data_2 = (string)Order.Rows[0]["Data_2"];


                DataTable MRecipe = new MSSQLEAdapter("Orders", "SELECT *" +
                                                       "FROM Recipes_MR " +
                                                       "WHERE Id = " + (int)Box.Rows[0]["MR_Id"] + ";").DB_Output();
                MR = (string)MRecipe.Rows[0]["Name"];

                DataTable Art = new MSSQLEAdapter("Orders", "SELECT *" +
                                                      "FROM Recipes_Article " +
                                                      "WHERE Id = " + (int)MRecipe.Rows[0]["Article_Id"] + ";").DB_Output();

                Article = (string)Art.Rows[0]["Image"];
            }
          
        }
    }
}
