namespace Week6_TODO_APP.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=kachi\\sqlexpress;Initial Catalog=Week6_TODOAPP;Integrated Security=True";
        public static string CName { get => cName; }
    }
}
