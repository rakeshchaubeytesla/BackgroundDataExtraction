using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public interface IBhavData
    {
        void SaveBcCorporateActionSecurities(DataTable dataTable);
        void SaveBhavExcelData(DataTable dataTable, DateTime selectedDate);
    }
}
