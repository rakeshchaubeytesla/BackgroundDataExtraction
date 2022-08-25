using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace BackgroundDataExtraction
{
    public static class DownloadAndExtract
    {
        //private static readonly string dateFormat = DateTime.Now.Date.ToString("dd/MM/yy");
        //private static readonly string zipFileName = ("PR" + dateFormat + ".zip").Replace("/", "");
        //private static string zipFileUrl = CommonConfiguration.ZipFileUrl + zipFileName;
        public static void DownloadZipFile(DateTime selectedDate)
        {
            DeleteExistingFiles(CommonConfiguration.ZipFileStorageLocation);
            string dateFormat = selectedDate.Date.ToString("dd/MM/yy");
            string zipFileName = ("PR" + dateFormat + ".zip").Replace("/", "");
            string zipFileUrl = CommonConfiguration.ZipFileUrl + zipFileName;
            using (WebClient wc = new WebClient())
            {
                //zipFileUrl = "https://archives.nseindia.com/archives/equities/bhavcopy/pr/PR190822.zip";
                wc.DownloadFile(zipFileUrl, CommonConfiguration.ZipFileStorageLocation + zipFileName);
            }
        }

        public static void ExtractZipFile(DateTime selectedDate)
        {
            DeleteExistingFiles(CommonConfiguration.UnZipFileStorageLocation);
            string dateFormat = selectedDate.Date.ToString("dd/MM/yy");
            string zipFileName = ("PR" + dateFormat + ".zip").Replace("/", "");
            ZipFile.ExtractToDirectory(CommonConfiguration.ZipFileStorageLocation + zipFileName,
                                       CommonConfiguration.UnZipFileStorageLocation);
            
        }

        public static void DeleteExistingFiles(string folderPath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
        }

        public static void DownloadBhavZipFile(string destinationPath, string url, string zipFileName)
        {
            DeleteExistingFiles(destinationPath);
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(url, destinationPath + zipFileName);
            }
        }
        public static void ExtractBhavZipFile(string sourcePath, string destinationPath, string zipFileName)
        {
            DeleteExistingFiles(destinationPath);

            ZipFile.ExtractToDirectory(sourcePath + zipFileName,
                                       destinationPath);
            DeleteExistingFiles(sourcePath);
        }

        public static DateTime[] GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);
            return allDates.ToArray();
        }


    }
}
