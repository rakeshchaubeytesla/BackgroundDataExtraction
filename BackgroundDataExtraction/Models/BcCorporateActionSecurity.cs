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
        public string RecordDt { get; set; }
        public string BcStrtDt { get; set; }
        public string BcEndDt { get; set; }
        public string ExDt { get; set; }
        public string NdStrtDt { get; set; }
        public string NdEndDt { get; set; }
        public string Purpose { get; set; }
    }
}
