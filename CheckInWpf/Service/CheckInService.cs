using CheckInWpf.Model;
using CheckInWpf.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckInWpf.ViewModel
{
    public class CheckInService : ICheckInService
    {
        private readonly IDbService _dbService;
        private readonly IFileService _fileService;
        public CheckInService(IDbService dbService,IFileService fileService)
        {
            _dbService = dbService;
            _fileService = fileService;
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
           _dbService.AddOrder(checkIn);
        }
        public void UpdateOrder(CheckIn checkIn)
        {
           _dbService.UpdateOrder(checkIn);
        }
        public void SaveAll(List<CheckInWrapper> checkInWrappers)
        {
            _fileService.SaveProjectAsEXCEL(checkInWrappers);
        }
    }
}