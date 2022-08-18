using CheckInWpf.Model;
using CheckInWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Commands
{
    public class DeleteOrderCommand : CommandBase
    {
        private readonly ICheckInService _checkInService;
        private readonly CheckedInListViewModel _checkedInListViewModel;

        public DeleteOrderCommand(ICheckInService checkInService, CheckedInListViewModel checkedInListViewModel)
        {
            _checkInService = checkInService;
            _checkedInListViewModel = checkedInListViewModel;
        }
        public override void Execute(object? parameter)
        {
            CheckIn order = ((CheckInWrapper)parameter).ToCheckIn();
            order.Status = Status.Deleted;

            _checkInService.UpdateOrder(order);
            _checkedInListViewModel.InitializeTheViewModel();

        }
    }
}
