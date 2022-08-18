using CheckInWpf.Model;
using CheckInWpf.ViewModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CheckInWpf.Service
{
    internal class FileService : IFileService
    {
        private readonly string LatestFileName = "Latest.json";
        private readonly string AppDataDirectory = "Checkin";
        private string LatestFilePath => Path.Combine(ApplicationPath, LatestFileName);
        private string ApplicationPath =>
             Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDataDirectory);



        public T Read<T>()
        {
            using (StreamReader r = new StreamReader(LatestFilePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public void Write<T>(T toBeSerialized)
        {
            var json = JsonConvert.SerializeObject(toBeSerialized);
            System.IO.File.WriteAllText(LatestFilePath, json);

        }


        private void WriteInitializer(string latestFullPathWithName)
        {
            Latest t = new Latest()
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


        public void InitializeFiles()
        {
            if (!Directory.Exists(ApplicationPath))
                Directory.CreateDirectory(ApplicationPath);

            if (!File.Exists(LatestFilePath))
                WriteInitializer(LatestFilePath);
        }

        public bool SaveProjectAsEXCEL(IEnumerable<CheckInWrapper> checkInWrappers)
        {
            try
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = ".csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string fileToSave = saveFileDialog.FileName;

                    CSVExporter(checkInWrappers, fileToSave);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void CSVExporter(IEnumerable<CheckInWrapper> checkInWrappers,string filepath)
        {
            try
            {
                List<string> content = new List<string>();

                foreach (var line in checkInWrappers)
                {
                    content.Add(line.ToCSVString());
                  

                }
                File.WriteAllLines(filepath, content);

            }
            catch (Exception ex)
            {
            }
        }

   
    }
}