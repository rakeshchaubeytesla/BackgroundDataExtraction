using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace BackgroundDataExtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DownloadAndExtract.DownloadZipFile();
            DownloadAndExtract.ExtractZipFile();
            var files = GetAllFiles();
            foreach (var file in files)
            {
                var fileReader = CSVReader.ConvertCSVtoDataTable(file);
                var tableName = IdentifyTableName.TableName(Path.GetFileName(file).Substring(0, 2));

            }

        }

        private static IEnumerable<string> GetAllFiles()
        {
            return Directory.GetFiles(CommonConfiguration.UnZipFileStorageLocation, "*.csv")
                   .Select(Path.GetFullPath);
        }
    }
}
