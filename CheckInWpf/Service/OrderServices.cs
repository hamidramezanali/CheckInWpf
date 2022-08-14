using CheckInWpf.Model;
using CheckInWpf.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CheckInWpf.ViewModel
{
    internal class OrderServices
    {
        internal ObservableCollection<CheckIn> GetAllOrders()
        {
            ObservableCollection<CheckIn> checkIns = new ObservableCollection<CheckIn>();
            var ordersAsString = FileService.ReadOrders();
            foreach (var order in ordersAsString)
            {
                checkIns.Add(new CheckIn(order));
            }
            return checkIns;
        }
        internal void SaveAllOrders(ObservableCollection<CheckIn> orders)
        {
            List<string> newOrders = new List<string>();
            foreach (var order in orders)
            {
                newOrders.Add(
                  order.Name+"\t"+
                  order.OrderNo + "\t" +
                   order.Day + "\t" +
                    order.Month + "\t" +
                    order.Year + "\t" +
                    order.Comments + "\t" +
                    order.Status + "\t" );
            }
            FileService.WriteOrders(newOrders);
        }
    }
}