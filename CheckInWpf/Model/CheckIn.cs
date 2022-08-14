using CheckInWpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Model
{
    internal class CheckIn
    {
        public CheckIn()
        {
        }

        public CheckIn(string order)
        {
            var newCheckin = order.Split("\t");
            Name = newCheckin[0];
            OrderNo =Convert.ToInt32( newCheckin[1]);
            Day = newCheckin[2];
            Month = newCheckin[3];
            Year = newCheckin[4];
            Comments = newCheckin[5];
            Status = newCheckin[6].ToStatus();
        }

        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public DateTime Date => DateTime.Parse($"{Year}/{Month}/{Day}");
        public string Year { get; set; }
   
        public string Comments { get; set; }
        public Status Status { get; set; }
    }
}
