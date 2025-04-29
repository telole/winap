using MySql.Data.MySqlClient;

namespace winap
{
    public static class db
    {
        private static readonly string connStr = "server=localhost;user=root;database=db_test;port=3306;password=";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
    }
}
