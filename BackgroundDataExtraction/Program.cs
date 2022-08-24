using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;

namespace BackgroundDataExtraction
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //  BhavCsvNSE();
            var selectedDate =DownloadAndExtract.GetDatesBetween(DateTime.Now.AddDays(-360), DateTime.Now);
            foreach (var date in selectedDate)
            {
                try
                {
                    if (!(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday))
                    {
                        BhavCsvNSE(date);
                    }
                    //BhavCsvNSE(date);
                }
                catch (Exception ex)
                {

                    continue;
                }
            }
        }

        private static void BhavCsvNSE(DateTime selectedDate)
        {
            string year = selectedDate.Year.ToString();
            string month = selectedDate.ToString("MMM").ToUpper();
            string date = selectedDate.Date.Day.ToString();
            //string date = "20";
            string fileName = "cm" + date + month.Substring(0, 3) + year + "bhav.csv.zip";
            string url = CommonConfiguration.UnZipBhavCSV +
                         year + "/" +
                         month.Substring(0, 3) + "/" +
                         "cm" + date + month.Substring(0, 3) + year + "bhav.csv.zip";

            DownloadAndExtract.DownloadBhavZipFile(CommonConfiguration.UnZipFileStorageLocation,
                                                   url, fileName);

            DownloadAndExtract.ExtractBhavZipFile(CommonConfiguration.UnZipFileStorageLocation, 
                                                  CommonConfiguration.ZipFileStorageLocation,
                                                  fileName);
            var files = GetAllFiles(CommonConfiguration.ZipFileStorageLocation);
            foreach (var file in files)
            {
                var fileReader = CSVReader.ConvertCSVtoDataTable(file);
                BhavService bhavService = new BhavService();
                bhavService.SaveBhavExcelData(fileReader,selectedDate);
            }
        }

        private static void ExtractArchiveZip()
        {
            DownloadAndExtract.DownloadZipFile();
            DownloadAndExtract.ExtractZipFile();
            var files = GetAllFiles(CommonConfiguration.UnZipFileStorageLocation);
            foreach (var file in files)
            {
                var fileReader = CSVReader.ConvertCSVtoDataTable(file);
                var tableName = IdentifyTableName.TableName(Path.GetFileName(file).Substring(0, 2));
                BhavService bhavService = new BhavService();
                bhavService.SaveDataTableToDataBase(tableName, fileReader);

            }
        }

        private static IEnumerable<string> GetAllFiles(string UnZipFileStorageLocation)
        {
            return Directory.GetFiles(UnZipFileStorageLocation, "*.csv")
                   .Select(Path.GetFullPath);
        }
    }
}
