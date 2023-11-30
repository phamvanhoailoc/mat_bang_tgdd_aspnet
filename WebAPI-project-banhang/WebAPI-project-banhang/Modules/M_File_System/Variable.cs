namespace WebAPI_project_banhang.Modules.M_File_System
{
    public class Variable
    {
        public static class IMAGE
        {
            public const int MinWidth = 90;
            public const int MinHeight = 120;
            public const string FILEPATH = "/";
        }

        // FileType.cs
        public static class FILE_TYPE
        {
            public const string IMAGE = "image";
            public const string FILE = "file";
        }

        public static readonly string URL_PUB_MAIN_API = "https://localhost:44389";
    }
}
