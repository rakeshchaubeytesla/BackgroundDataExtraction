using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public static class CommonConfiguration
    {
        public static readonly string ZipFileUrl = "https://archives.nseindia.com/archives/equities/bhavcopy/pr/";
        public static readonly string ZipFileStorageLocation = @"D:\DailyBhavCopy\ZipPath\";
        public static readonly string UnZipFileStorageLocation = @"D:\DailyBhavCopy\UnZipPath\";
    }
}
