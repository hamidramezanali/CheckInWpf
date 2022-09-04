using CheckInWpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Model
{
    public class CheckIn
    {


        public string ID { get; set; }
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
