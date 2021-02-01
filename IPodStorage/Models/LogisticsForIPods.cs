using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Models
{
    public class LogisticsForIPods
    {
        public string PrimaryCountry { get; set; }
        public string SecondaryCountry { get; set; }
        public int UnitsDeliveredByPrimaryCounry { get; set; }
        public int UnitsDeliveredBySecondaryCounry { get; set; }
        public float PricePrimaryCountry { get; set; }
        public float PriceSecondaryCountry { get; set; }

    }
}
