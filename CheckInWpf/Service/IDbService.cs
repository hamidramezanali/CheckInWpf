using CheckInWpf.Model;
using System.Collections.Generic;

namespace CheckInWpf.Service
{
    internal interface IDbService
    {
        bool checkIfExist(string tableName);
        bool checkIfTableContainsData(string tableName);
        string CreateDbConnection();
        void CreateDbFile();
        void CreateTables();
        void executeQuery(string sqlCommand);
        void InitializeDb();
        IEnumerable<CheckIn> GetAllOrders();
        void UpdateOrder(CheckIn order);
        void AddOrder(CheckIn order);
    }
}