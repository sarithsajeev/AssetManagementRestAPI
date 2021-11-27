using System;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public partial class AssetMaster
    {
        public int AmId { get; set; }
        public int? AmAtypeId { get; set; }
        public int? AmMakeId { get; set; }
        public int? AmAdId { get; set; }
        public string AmModel { get; set; }
        public string AmSNumber { get; set; }
        public string AmMyYear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWarranty { get; set; }
        public DateTime? AmFrom { get; set; }
        public DateTime? AmTo { get; set; }
    }
}
