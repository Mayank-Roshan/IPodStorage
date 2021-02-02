using IPodStorage.Interfaces;
using IPodStorage.Models;
using IPodStorage.Services;

namespace IPodStorage.CommonHelpers
{
    public class CalculatePrice
    {
        private ICountryPriceService _countryPriceService;

        public CalculatePrice()
        {
            _countryPriceService = new CountryPriceService();
        }

        public float CalculateBestPrice(LogisticsForIPods iPodLogisticsDistribution)
        {
            iPodLogisticsDistribution.PricePayableFor.PrimaryCountry = CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.ByPrimaryCounry, iPodLogisticsDistribution.PricePerUnit.PrimaryCountry, false);

            if (iPodLogisticsDistribution.IsExtraShippingPriceRequired)
            {
                iPodLogisticsDistribution.PricePayableFor.SecondaryCountry = CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.BySecondaryCounry, iPodLogisticsDistribution.PricePerUnit.SecondaryCountry, true);
            }

            return (iPodLogisticsDistribution.PricePayableFor.PrimaryCountry + iPodLogisticsDistribution.PricePayableFor.SecondaryCountry);
        }

        public float CalculatePriceByCountry(int numberOfUnits,float pricePerUnit, bool isExtraShippingChargeRequired)
        {            
            return _countryPriceService.CalculateBestPrice(numberOfUnits, pricePerUnit, isExtraShippingChargeRequired);
        }
    }
}
