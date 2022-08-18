using CheckInWpf.Model;
using CheckInWpf.ViewModel;
using System.Collections.Generic;

namespace CheckInWpf.Service
{
    public interface IDbService
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