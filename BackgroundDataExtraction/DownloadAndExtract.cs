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
        private static readonly string dateFormat = DateTime.Now.Date.ToString("dd/MM/yy");
        private static readonly string zipFileName = ("PR" + dateFormat + ".zip").Replace("/", "");
        private static string zipFileUrl = CommonConfiguration.ZipFileUrl + zipFileName;
        public static void DownloadZipFile()
        {
            DeleteExistingFiles(CommonConfiguration.ZipFileStorageLocation);

            using (WebClient wc = new WebClient())
            {
                zipFileUrl = "https://archives.nseindia.com/archives/equities/bhavcopy/pr/PR190822.zip";
                wc.DownloadFile(zipFileUrl, CommonConfiguration.ZipFileStorageLocation + zipFileName);
            }
        }

        public static void ExtractZipFile()
        {
            DeleteExistingFiles(CommonConfiguration.UnZipFileStorageLocation);

            ZipFile.ExtractToDirectory(CommonConfiguration.ZipFileStorageLocation+ zipFileName, 
                                       CommonConfiguration.UnZipFileStorageLocation);
        }

        private static void DeleteExistingFiles(string folderPath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
        }

    }
}
