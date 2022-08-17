using CheckInWpf.Model;
using CheckInWpf.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckInWpf.ViewModel
{
    internal class CheckInService : ICheckInService
    {
        private readonly IDbService _dbService;
        public CheckInService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public ObservableCollection<CheckInWrapper> GetAllOrders()
        {
            ObservableCollection<CheckInWrapper> checkIns = new ObservableCollection<CheckInWrapper>();
            var ordersAsList = _dbService.GetAllOrders();
            foreach (var order in ordersAsList)
            {
                checkIns.Add(new CheckInWrapper(order));
            }
            return checkIns;
        }
        internal void SaveAllOrders(ObservableCollection<CheckIn> orders)
        {
            List<string> newOrders = new List<string>();
            foreach (var order in orders)
            {
                newOrders.Add(
                  order.Name + "\t" +
                  order.OrderNo + "\t" +
                   order.Day + "\t" +
                    order.Month + "\t" +
                    order.Year + "\t" +
                    order.Comments + "\t" +
                    order.Status + "\t");
            }
            //FileService.WriteOrders(newOrders);
        }

        public void AddOrder(CheckIn checkIn)
        {
            throw new NotImplementedException();
        }
        public void UpdateOrder(CheckIn checkIn)
        {
            throw new NotImplementedException();
        }
    }
}