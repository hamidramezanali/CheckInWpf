using CheckInWpf.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CheckInWpf.Service
{
    internal class FileService
    {
        public static string LatestFileName = "Latest.json";
        public static string OrdersFileName = "Orders.txt";
        public static string AppDataDirectory = "Checkin";
        internal static T Read<T>()
        {
            string path = GetLatestFilePath();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        internal static void Write(Latest latest)
        {
            string path = GetLatestFilePath();
            var json = JsonConvert.SerializeObject(latest);
            System.IO.File.WriteAllText(path, json);

        }

        internal static List<string> ReadOrders()
        {
            string path = GetOrdersFilePath();
            if (!File.Exists(path))
            {
                using (StreamWriter w = File.AppendText(path)) ;
            }
            var result = File.ReadAllLines(path);
            return result.ToList();

        }

        internal static void WriteOrders(List<string> orders)
        {

            string path = GetOrdersFilePath();
            File.WriteAllLines(path, orders);

        }
        private static string GetOrdersFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataDirectory, OrdersFileName);
        }
        private static string GetLatestFilePath()
        {
            string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataDirectory);
            string LatestFullPathWithName = Path.Combine(@AppDataPath, LatestFileName);
            if (!Directory.Exists(AppDataPath))
                Directory.CreateDirectory(AppDataPath);
            if (!File.Exists(LatestFullPathWithName))
                WriteInitializer(LatestFullPathWithName);
            return LatestFullPathWithName;
        }

        private static void WriteInitializer(string latestFullPathWithName)
        {
            Latest t =  new Latest()
            {
                Id = 0,
                DateTime = DateTime.Now.ToShortDateString()
            };
            using (StreamWriter w = File.AppendText(latestFullPathWithName))
            {
                string s = JsonConvert.SerializeObject(t);

                w.Write(s);
            };
        }
    }
}