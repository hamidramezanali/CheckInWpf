using CheckInWpf.Model;
using CheckInWpf.Service;
using System.Collections.ObjectModel;

namespace CheckInWpf.ViewModel
{
    internal interface ICheckInService
    {
        void AddOrder(CheckIn checkIn);
        ObservableCollection<CheckInWrapper> GetAllOrders();
        void UpdateOrder(CheckIn checkIn);
    }
}