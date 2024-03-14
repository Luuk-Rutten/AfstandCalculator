namespace AfstandCalculator
{
    public static class Constanten
    {
        public static string SQLiteDatabase = GetDatabaseFilePath();
        //https://learn.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key
        public static readonly string BingMapsKey = "AplFKy-mxHDlV47OfGD6Dj9Bm86tktgxvXCEvBL0bYgAx6qMogG8J6I_XSl1ozB4";


        public static string GetDatabaseFilePath()
        {
            var folderPath = FileSystem.AppDataDirectory;
            return Path.Combine(folderPath, "reizen.db");
        }
    }
}
