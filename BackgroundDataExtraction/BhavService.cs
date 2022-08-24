using BackgroundDataExtraction.Enum;
using BackgroundDataExtraction.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public class BhavService
    {
        public IBhavData bhavData;
        public BhavService()
        {
            bhavData = new BhavData();
        }
        public void ReadCSVFiles(string strFilePath)
        {
            var datafromCSV = CSVReader.ConvertCSVtoDataTable(strFilePath);
        }

        public void SaveDataTableToDataBase(TableNameEnum tableName,DataTable dataTable)
        {
            switch (tableName)
            {
                case TableNameEnum.AnAnnouncement:

                    break;
                case TableNameEnum.BcCorporateActionSecurities:
                    bhavData.SaveBcCorporateActionSecurities(dataTable);
                    break;
                default:
                    break;
            }
        }

        public void SaveBhavExcelData(DataTable dataTable,DateTime selectedDate)
        {
            bhavData.SaveBhavExcelData(dataTable,selectedDate);
        }
    }
}
