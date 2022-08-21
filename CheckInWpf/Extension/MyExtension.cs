using CheckInWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWpf.Extensions
{
    internal static class MyExtension
    {
        public static Status ToStatus(this string status)
        {
            return Enum.Parse<Status>(status);
        }
    }
}
