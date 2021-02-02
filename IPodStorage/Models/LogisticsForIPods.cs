
namespace IPodStorage.Models
{
    public class LogisticsForIPods
    {
        public DeliverableCountryName CountryNames { get; set; }
        public UnitsDeliverable UnitsDeliverable { get; set; }
        public PricePerCountry PricePerUnit { get; set; }
        public CountryBestPrice PricePayableFor { get; set; }
        public bool IsExtraShippingPriceRequired { get; set; }

    }
}
