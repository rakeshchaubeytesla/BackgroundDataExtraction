using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public class BhavService
    {
        public void ReadCSVFiles(string strFilePath)
        {
            var datafromCSV = CSVReader.ConvertCSVtoDataTable(strFilePath);
        }
    }
}
