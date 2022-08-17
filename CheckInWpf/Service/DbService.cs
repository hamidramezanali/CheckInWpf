using CheckInWpf.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
namespace CheckInWpf.Service
{
    internal class DbService : IDbService
    {
        public static string OrdersFileName = "Orders.db";
        public static string AppDataDirectory = "Checkin";


        SqliteConnection dbConnection;
        SqliteCommand command;
        string sqlCommand;
        string dbFilePath;

        public void InitializeDb()
        {
            CreateDbFile();
            CreateDbConnection();
            CreateTables();

        }
        public void CreateDbFile()
        {
            if (!System.IO.File.Exists(dbPath))
            {
                File.Create(dbPath);
            }
        }
        private string appPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataDirectory);
        private string dbPath => Path.Combine(appPath, OrdersFileName);



        public string CreateDbConnection()
        {
            string strCon = string.Format("Data Source={0};", dbPath);
            dbConnection = new SqliteConnection(strCon);
            dbConnection.Open();
            command = dbConnection.CreateCommand();
            return strCon;
        }

        public void CreateTables()
        {
            if (!checkIfExist("CHECK_IN"))
            {
                sqlCommand = "CREATE TABLE CHECK_IN(ID INTEGER PRIMARY KEY AUTOINCREMENT,Name TEXT,Comments TEXT,OrderNo INTEGER,Day TEXT, Month TEXT, Year TEXT,Status TEXT)";
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




        public IEnumerable<CheckIn> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(CheckIn order)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(CheckIn order)
        {
            if (!checkIfTableContainsData("CHECK_IN"))
            {
                sqlCommand = @$"insert into CHECK_IN (Name ,Comments ,OrderNo ,Day , Month , Year ,Status) values (
                             {order.Name},{order.Comments},{order.OrderNo},{order.Day},{order.Month},{order.Year},{order.Status})";
                executeQuery(sqlCommand);
            }
        }
    }

}

