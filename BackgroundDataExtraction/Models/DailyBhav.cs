using System;
using System.Collections.Generic;

#nullable disable

namespace BackgroundDataExtraction.Models
{
    public partial class DailyBhav
    {
        public int Id { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public string Symbol { get; set; }
        public string Series { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public decimal? Last { get; set; }
        public decimal? Prevclose { get; set; }
        public int? Tottrdqty { get; set; }
        public decimal? Tottrdval { get; set; }
        public string Timestamp { get; set; }
        public int? Totaltrades { get; set; }
        public string Isin { get; set; }
    }
}
