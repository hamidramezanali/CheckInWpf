using CheckInWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Service
{
    internal class OrderNumberService
    {
        public int GetOrderNumber()
        {
           var latest= FileService.Read<Latest>();
            var date = DateTime.Today.ToShortDateString();
            if (latest.DateTime == date)
                return latest.Id+1;
            else return 1;
        }
        public void SetOrderNumber(int orderNo)
        {
            FileService.Write(new Latest() { Id = orderNo, DateTime = DateTime.Today.ToShortDateString() });
        }

    }
}
