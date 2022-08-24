using BackgroundDataExtraction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundDataExtraction
{
    public class BhavData : IBhavData
    {
        private readonly FirstMarketContext _context;
        public BhavData()
        {
            _context = new FirstMarketContext();
        }

        public void SaveBcCorporateActionSecurities(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                BcCorporateActionSecurity bcCorporateActionSecurity = new BcCorporateActionSecurity();
                bcCorporateActionSecurity.CorporateActionSecurityDate = DateTime.Now;
                bcCorporateActionSecurity.Series = row["Series"].ToString();
                bcCorporateActionSecurity.Symbol = row["Symbol"].ToString();
                bcCorporateActionSecurity.Security = row["Security"].ToString();
                bcCorporateActionSecurity.RecordDt = row["RECORD_DT"].ToString();
                bcCorporateActionSecurity.BcStrtDt = row["BC_STRT_DT"].ToString();
                bcCorporateActionSecurity.BcEndDt = row["BC_END_DT"].ToString();
                bcCorporateActionSecurity.ExDt = row["EX_DT"].ToString();
                bcCorporateActionSecurity.NdStrtDt = row["ND_STRT_DT"].ToString();
                bcCorporateActionSecurity.NdEndDt = row["ND_END_DT"].ToString();
                bcCorporateActionSecurity.Purpose = row["PURPOSE"].ToString();
                _context.BcCorporateActionSecurities.Add(bcCorporateActionSecurity);
            }
            _context.SaveChanges();
        }

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

        public void SaveBhavExcelData(DataTable dataTable, DateTime selectedDate)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                DailyBhav dailybhav  = new DailyBhav();
                dailybhav.GeneratedDate = selectedDate;
                dailybhav.Symbol = row["SYMBOL"].ToString();
                dailybhav.Series = row["SERIES"].ToString();
                dailybhav.Open = Convert.ToDecimal(row["OPEN"], CultureInfo.InvariantCulture);
                dailybhav.Open = Convert.ToDecimal(row["OPEN"], CultureInfo.InvariantCulture);
                dailybhav.High = Convert.ToDecimal(row["HIGH"], CultureInfo.InvariantCulture);
                dailybhav.Low = Convert.ToDecimal(row["LOW"], CultureInfo.InvariantCulture);
                dailybhav.Close = Convert.ToDecimal(row["CLOSE"], CultureInfo.InvariantCulture);
                dailybhav.Last = Convert.ToDecimal(row["LAST"], CultureInfo.InvariantCulture);
                dailybhav.Prevclose = Convert.ToDecimal(row["PREVCLOSE"], CultureInfo.InvariantCulture);
                dailybhav.Tottrdqty = Convert.ToInt32(row["TOTTRDQTY"]);
                dailybhav.Tottrdval = Convert.ToDecimal(row["TOTTRDVAL"], CultureInfo.InvariantCulture);
                dailybhav.Timestamp = Convert.ToString(row["TIMESTAMP"]);
                dailybhav.Totaltrades = Convert.ToInt32(row["TOTALTRADES"]);
                dailybhav.Isin = row["ISIN"].ToString();

                _context.DailyBhavs.Add(dailybhav);
            }
            _context.SaveChanges();
        }
    }
}
