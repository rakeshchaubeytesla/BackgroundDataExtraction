using BackgroundDataExtraction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public static class IdentifyTableName
    {
        public static string TableName(string fileName)
        {
            string tableName = "";
            switch (fileName)
            {
                case "Bc":
                    tableName= TableNameEnum.BcCorporateActionSecurities.ToString();
                    break;

                case "An":
                    tableName = TableNameEnum.AnAnnouncement.ToString();
                    break;

                default:
                    break;
            }
            return tableName;
        }
    }
}
