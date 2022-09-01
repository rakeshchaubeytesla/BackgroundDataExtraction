using EnumBackGround = BackgroundDataExtraction.Enum;
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

        private int? _positiveDays = 0;
        private int? _negativeDays = 0;
        public BhavData()
        {
            _context = new FirstMarketContext();
        }

        public void SaveBcCorporateActionSecurities(DataTable dataTable, DateTime selectedDate)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                BcCorporateActionSecurity bcCorporateActionSecurity = new BcCorporateActionSecurity();
                bcCorporateActionSecurity.CorporateActionSecurityDate = selectedDate;
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
                DailyBhav dailybhav = new DailyBhav();
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

        public decimal? getValueForDay(string _dayName, int day,IEnumerable<DailyBhav> dailyBhavs)
        {
            var get1StDay = dailyBhavs.Where(a => a.GeneratedDate.GetValueOrDefault().Date.Day == day).FirstOrDefault();
            if(get1StDay != null)
            {
                if((get1StDay.Close.Value - get1StDay.Open.Value) < 0)
                {
                    _positiveDays = _positiveDays + 1;
                }
                if((get1StDay.Close.Value - get1StDay.Open.Value) > 0)
                {
                    _negativeDays = _negativeDays + 1;
                }
            }
            return (get1StDay == null) ? 0 : (get1StDay.Open - get1StDay.Close);
        }

        public void ExtractBhavToDerivedTable()
        {
            var getDistinctStockName = _context.DailyBhavs.Where(a => a.Series == "EQ").Select(stockName => stockName.Symbol).Distinct().ToList();
            foreach (var selectedStock in getDistinctStockName)
            {
                var getSelectedStockList = _context.DailyBhavs.Where(stockName => stockName.Symbol == selectedStock).ToList();
                if (getSelectedStockList.Count > 0)
                {
                    string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
                    foreach (var item in monthNames)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            int month = DateTime.ParseExact(item, "MMMM", CultureInfo.CurrentCulture).Month;
                            var monthWiseSelectedStockList = getSelectedStockList.Where(a => a.GeneratedDate.GetValueOrDefault().Date.Month == month);
                            //foreach (var selectedMonthStock in monthWiseSelectedStockList)
                            //{
                            if (monthWiseSelectedStockList.Count() > 0)
                            {
                                DailyCalculationBhavTable dailyCalculationBhavTable = new DailyCalculationBhavTable();
                                dailyCalculationBhavTable.Month = month;
                                dailyCalculationBhavTable.Year = 2021;
                                dailyCalculationBhavTable.Symbol = selectedStock;
                                dailyCalculationBhavTable._1 = getValueForDay("_1", 1, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._2 = getValueForDay("_2", 2, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._3 = getValueForDay("_3", 3, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._4 = getValueForDay("_4", 4, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._5 = getValueForDay("_5", 5, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._6 = getValueForDay("_6", 6, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._7 = getValueForDay("_7", 7, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._8 = getValueForDay("_8", 8, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._9 = getValueForDay("_9", 9, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._10 = getValueForDay("_10", 10, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._11 = getValueForDay("_11", 11, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._12 = getValueForDay("_12", 12, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._13 = getValueForDay("_13", 13, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._14 = getValueForDay("_14", 14, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._15 = getValueForDay("_15", 15, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._16 = getValueForDay("_16", 16, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._17 = getValueForDay("_17", 17, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._18 = getValueForDay("_18", 18, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._19 = getValueForDay("_19", 19, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._20 = getValueForDay("_20", 20, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._21 = getValueForDay("_21", 21, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._22= getValueForDay("_22", 22, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._23 = getValueForDay("_23", 23, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._24 = getValueForDay("_24", 24, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._25= getValueForDay("_25", 25, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._26 = getValueForDay("_26", 26, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._27 = getValueForDay("_27", 27, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._28 = getValueForDay("_28", 28, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._29= getValueForDay("_29", 29, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._30= getValueForDay("_30", 30, monthWiseSelectedStockList);
                                dailyCalculationBhavTable._31= getValueForDay("_31", 31, monthWiseSelectedStockList);
                                dailyCalculationBhavTable.PositiveDays = _positiveDays;
                                dailyCalculationBhavTable.NegativeDays = _negativeDays;
                                _context.DailyCalculationBhavTables.Add(dailyCalculationBhavTable);
                                _negativeDays = 0;
                                _positiveDays = 0;
                                _context.SaveChanges();
                                //}
                                //_context.SaveChanges();
                            }
                                
                        }

                    }

                    //_context.SaveChanges();
                }
            }

        }


    }
}
