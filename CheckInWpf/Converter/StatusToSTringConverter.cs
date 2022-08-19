using CheckInWpf.Extensions;
using CheckInWpf.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CheckInWpf.Converter
{
    public class StatusToSTringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value.ToString().ToStatus();
            switch (state)
            {
                case Status.Deleted : return "حذف شده";
                case Status.Present: return "حاضر";
                default: return "حاضر";
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
