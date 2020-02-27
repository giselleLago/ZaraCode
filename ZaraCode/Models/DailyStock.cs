using System;

namespace ZaraCode.Models
{
    public class DailyStock 
    {
        public DateTime DateTime { get; set; }
        public decimal OpenDay { get; set; }
        public decimal CloseDay { get; set; }

    }
}
