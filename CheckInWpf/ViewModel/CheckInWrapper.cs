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
    internal class CheckInWrapper : ViewModelBase

    {
        private readonly CheckIn _checkIn;


        public string Name => _checkIn.Name;

        public string Comments => _checkIn.Comments;

        public int OrderNo => _checkIn.OrderNo;

        public string Day => _checkIn.Day;

        public string Month => _checkIn.Month;

        public string Year => _checkIn.Year;


        public CheckInWrapper(CheckIn checkin)
        {
            _checkIn = checkin; ;
        }


    }
}
