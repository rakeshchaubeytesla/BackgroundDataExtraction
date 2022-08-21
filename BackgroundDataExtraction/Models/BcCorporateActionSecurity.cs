using System;
using System.Collections.Generic;

#nullable disable

namespace BackgroundDataExtraction.Models
{
    public partial class BcCorporateActionSecurity
    {
        public int Id { get; set; }
        public DateTime CorporateActionSecurityDate { get; set; }
        public string Series { get; set; }
        public string Symbol { get; set; }
        public string Security { get; set; }
        public DateTime? RecordDt { get; set; }
        public DateTime? BcStrtDt { get; set; }
        public DateTime? BcEndDt { get; set; }
        public DateTime? ExDt { get; set; }
        public DateTime? NdStrtDt { get; set; }
        public DateTime? NdEndDt { get; set; }
        public DateTime? Purpose { get; set; }
    }
}
