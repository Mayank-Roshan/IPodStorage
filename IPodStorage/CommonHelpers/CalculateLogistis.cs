using IPodStorage.ENums;
using IPodStorage.Interfaces;
using IPodStorage.Models;
using IPodStorage.Services;
using System;

namespace IPodStorage.CommonHelpers
{
    public class CalculateLogistis
    {
        private ICountryDeliverablesService _countryDeliverableSevice;
        private ICountryPriceService _countryPriceService;
        private IUnitsService _unitsService;

        public CalculateLogistis(ICountryDeliverablesService countryDeliverableSevice,
                                 ICountryPriceService countryPriceService,
                                 IUnitsService unitsService

                                )
        {
            _countryDeliverableSevice = countryDeliverableSevice;
            _countryPriceService = countryPriceService;
            _unitsService = unitsService;
        }

        public CalculateLogistis()
        {
            _countryDeliverableSevice = new CountryDeliverablesService();
            _countryPriceService = new CountryPriceService();
            _unitsService = new UnitsService();
        }

        public LogisticsForIPods CalculateIPodsLogistics(string primaryCountry, int totalRequiredNumberOfUnits)
        {
            if((totalRequiredNumberOfUnits > (Convert.ToInt32(CountryStorageCapacity.ArgentinaStorage) + Convert.ToInt32(CountryStorageCapacity.BrazilStorage))) || totalRequiredNumberOfUnits % 10 != 0)
                return null;
            var ipodLogistics = new LogisticsForIPods()
            {
                CountryNames = _countryDeliverableSevice.GetCountryDeliverableOrder(primaryCountry),
                UnitsDeliverable = _unitsService.GetUnitsDeliverablePerCountry(primaryCountry.ToLower(), totalRequiredNumberOfUnits),
                PricePerUnit = _countryPriceService.CalculatePricePerCountry(primaryCountry),
                PricePayableFor = new CountryBestPrice()
            };
            ipodLogistics.IsExtraShippingPriceRequired = _countryPriceService.IsExtraShippingCostRequired(ipodLogistics.UnitsDeliverable.BySecondaryCounry);
            
            return ipodLogistics;
        }
    }
}
