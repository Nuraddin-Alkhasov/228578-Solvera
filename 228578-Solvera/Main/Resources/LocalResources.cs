namespace HMI.Resources
{
    public enum MessageBoxIcon
    {
        None,
        Error,
        Hand,
        Stop,
        Question,
        Exclamation,
        Warning,
        Information,
        Asterisk
    }

    public enum InternalDialogResult
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Left = 3,
        Middle = 4,
        Right = 5,
        Yes = 6,
        No = 7
    }

    internal enum InternalDialogButtons
    {
        OK = 0,
        OKCancel = 1,
        YesNoCancel = 3,
        YesNo = 4,
        Custom = 7
    }

    public class DialogParams
    {
        internal string HeaderText { get; set; }
        internal string Content { get; set; }
        internal InternalDialogButtons Type { get; set; }
        internal InternalDialogResult DefaultResult { get; set; }
        internal MessageBoxIcon Icon { get; set; }
        internal bool Modal { get; set; }
        internal string LeftButtonText { get; set; }
        internal string MiddleButtonText { get; set; }
        internal string RightButtonText { get; set; }
    }


    public class LocalResources
    {
        public LocalResources()
        {
            Paths = new ProjectResourcePaths()
            {
                Project = new ActualPath(),
                MSSQLE = new MSSQLE()
                {
                    DataSource = @"Data Source=192.168.10.10\SQLEXPRESS,1433;",
                    NetworkLibrary = "Network Library=DBMSSOCN;",
                    InitialCatalogProtocol = "Initial Catalog=VisiWin#Orders;",
                    InitialCatalogRecipes = "Initial Catalog=VisiWin#Recipes;",
                    InitialCatalogLogs = "Initial Catalog=VisiWin#Logs;",
                    InitialCatalogAlarms = "Initial Catalog=VisiWin#Alarms;",
                    User = "User ID=sa;",
                    Password = "Password=2555;"
                },
                Reports = new Reports() 
                {
                    Logging= "C:\\Reports\\Errors\\",
                    Errors = "C:\\Reports\\Logging\\",
                    Orders = "C:\\Reports\\Orders\\",
                    Order = "C:\\Reports\\Order\\",
                    Charge = "C:\\Reports\\Charge\\",
                }
            };
            Paths.MSSQLE.GenerateConnectionStrings();
            Paths.LoadingGif = Paths.Project.Path + "\\Resources\\Images\\General\\Loading.gif";
        }

        public ProjectResourcePaths Paths;

        public class ProjectResourcePaths
        {
            public string LoadingGif { get; set; }
            public MSSQLE MSSQLE { get; set; }
            public ActualPath Project { get; set; }

            public Reports Reports { get; set; }


        }
        public class ActualPath
        {
            public ActualPath()
            {
                Path = System.IO.Directory.GetCurrentDirectory().ToUpper() == @"C:\WINDOWS\SYSTEM32" ? @"C:\Users\Public\Documents\VisiWin 7\7.2\Projects\227799-EOT" : System.IO.Directory.GetCurrentDirectory();
                Alarms = Path + "\\Alarms";
                Archive = Path + "\\Archive";
                Logging = Path + "\\Logging";
                Recipes = Path + "\\Recipes";
                Orders = Path + "\\Orders";
            }
            public string Path { get; }
            public string Alarms { get; }
            public string Archive { get; }
            public string Logging { get; }
            public string Recipes { get; }
            public string Orders { get; }
        }

        public class MSSQLE
        {
            public string DataSource { get; set; }
            public string NetworkLibrary { get; set; }
            public string InitialCatalogProtocol { get; set; }
            public string InitialCatalogRecipes { get; set; }
            public string InitialCatalogLogs { get; set; }
            public string InitialCatalogAlarms { get; set; }
            public string User { get; set; }
            public string Password { get; set; }

            public string ProtocolConnectionString { get; set; }
            public string RecipesConnectionString { get; set; }
            public string LogsConnectionString { get; set; }
            public string AlarmsConnectionString { get; set; }

            public void GenerateConnectionStrings()
            {
                ProtocolConnectionString = DataSource + NetworkLibrary + InitialCatalogProtocol + User + Password;
                RecipesConnectionString = DataSource + NetworkLibrary + InitialCatalogRecipes + User + Password;
                LogsConnectionString = DataSource + NetworkLibrary + InitialCatalogLogs + User + Password;
                AlarmsConnectionString = DataSource + NetworkLibrary + InitialCatalogAlarms + User + Password;

            }
        }

        public class Reports
        {
            public string Logging { get; set; }
            public string Errors { get; set; }
            public string Orders { get; set; }
            public string Order { get; set; }
            public string Charge { get; set; }
          
        }
    }
}
