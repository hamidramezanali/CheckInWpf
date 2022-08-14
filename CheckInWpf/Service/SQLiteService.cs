using Microsoft.Data.Sqlite;
using System;
using System.IO;
namespace CheckInWpf.Service
{
    internal class SQLiteService
    {
        public static string OrdersFileName = "Orders.db";
        public static string AppDataDirectory = "Checkin";


        SqliteConnection dbConnection;
        SqliteCommand command;
        string sqlCommand;
        string dbPath = System.Environment.CurrentDirectory + "\\DB";
        string dbFilePath;
        public void createDbFile()
        {
            dbFilePath = GetLatestFilePath();
            if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);
            if (!System.IO.File.Exists(dbFilePath))
            {
                File.Create(dbFilePath);
            }
        }

        private string GetLatestFilePath()
        {
            string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataDirectory);
            string LatestFullPathWithName = Path.Combine(@AppDataPath, OrdersFileName);
            if (!Directory.Exists(AppDataPath))
                Directory.CreateDirectory(AppDataPath);
            return LatestFullPathWithName;
        }


        public string createDbConnection()
        {
            string strCon = string.Format("Data Source={0};", dbFilePath);
            dbConnection = new SqliteConnection(strCon);
            dbConnection.Open();
            command = dbConnection.CreateCommand();
            return strCon;
        }

        public void createTables()
        {
            if (!checkIfExist("MY_TABLE"))
            {
                sqlCommand = "CREATE TABLE MY_TBALE(idnt_test INTEGER PRIMARY KEY AUTOINCREMENT,code_test_type INTEGER";
                executeQuery(sqlCommand);
            }

        }

        public bool checkIfExist(string tableName)
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE name='" + tableName + "'";
            var result = command.ExecuteScalar();

            return result != null && result.ToString() == tableName ? true : false;
        }

        public void executeQuery(string sqlCommand)
        {
            SqliteCommand triggerCommand = dbConnection.CreateCommand();
            triggerCommand.CommandText = sqlCommand;
            triggerCommand.ExecuteNonQuery();
        }

        public bool checkIfTableContainsData(string tableName)
        {
            command.CommandText = "SELECT count(*) FROM " + tableName;
            var result = command.ExecuteScalar();

            return Convert.ToInt32(result) > 0 ? true : false;
        }


        public void fillTable()
        {
            if (!checkIfTableContainsData("MY_TABLE"))
            {
                sqlCommand = "insert into MY_TABLE (code_test_type) values (999)";
                executeQuery(sqlCommand);
            }
        }
    }

}

