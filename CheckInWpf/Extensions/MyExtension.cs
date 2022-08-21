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
            var Success= Enum.TryParse<Status>(status,out Status result);
            return result;
        }
    }
}
