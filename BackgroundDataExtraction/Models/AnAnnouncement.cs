using System;
using System.Collections.Generic;

#nullable disable

namespace BackgroundDataExtraction.Models
{
    public partial class AnAnnouncement
    {
        public int Id { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public string CompanyName { get; set; }
        public string Symbol { get; set; }
        public string Announcement { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsActive { get; set; }
    }
}
