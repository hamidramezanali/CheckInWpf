using CheckInWpf.Model;
using CheckInWpf.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace CheckInWpf.ViewModel
{
    public class CheckInWrapper : ViewModelBase

    {
        private readonly CheckIn _checkIn;

        public string ID => _checkIn.ID;
        public string Name => _checkIn.Name;

        public string Comments => _checkIn.Comments;

        public int OrderNo => _checkIn.OrderNo;

        public string Day => _checkIn.Day;

        public string Month => _checkIn.Month;

        public string Year => _checkIn.Year;

        public Status Status => _checkIn.Status;

        public CheckInWrapper(CheckIn checkin)
        {
            _checkIn = checkin; ;
        }
        public CheckIn ToCheckIn()
        {
            return new CheckIn() { ID=ID, Name=Name, Comments=Comments, OrderNo=OrderNo, Day=Day, Month=Month, Year=Year,Status=Status};
        }
        public string ToCSVString()
        {
            return  @$" {ID},{ Name},{Comments }, {OrderNo }, {Day}, {Month }, {Year }, {Status}";
        }

        public bool IsInRange(string FromYear,string FromMonth, string FromDay, string ToYear, string ToMonth, string ToDay)
        {
            DateTime thisDate = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            var FiltereFromDate = pc.ToDateTime(Convert.ToInt32(FromYear), Convert.ToInt32(FromMonth), Convert.ToInt32(FromDay), 0, 0, 0, 0);
            var FiltereToDate = pc.ToDateTime(Convert.ToInt32(ToYear), Convert.ToInt32(ToMonth), Convert.ToInt32(ToDay), 23, 59, 0, 0);
            var OrderDate = pc.ToDateTime(Convert.ToInt32(this.Year), Convert.ToInt32(this.Month), Convert.ToInt32(this.Day), 0, 0, 0, 0);
            if (DateTime.Compare(OrderDate, FiltereFromDate) >= 0)
            {
                if (DateTime.Compare(OrderDate, FiltereToDate) <= 0)
                    return true;
            }
            return false;
        }
    }
}
