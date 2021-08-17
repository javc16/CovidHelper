using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelper.Models
{
    public class RegionDetail
    {
        public decimal Confirmed { get; set; }
        public decimal Deaths { get; set; }
        public decimal Recovered { get; set; }
        public decimal Confirmed_diff { get; set; }
        public decimal Deaths_diff { get; set; }
        public decimal Recovered_diff { get; set; }
        public Region Region { get; set; }
        public DateTime Date { get; set; }
        public DateTime Last_update { get; set; }
        public decimal Active { get; set; }
        public decimal Active_diff { get; set; }
        public decimal Fatality_rate { get; set; }

    }
}
