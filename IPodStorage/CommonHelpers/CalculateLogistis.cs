using IPodStorage.Constants;
using IPodStorage.ENums;
using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.CommonHelpers
{
    public static class CalculateLogistis
    {
        public static LogisticsForIPods CalculateIPodsLogistics(string primaryCountry, int totalRequiredNumberOfUnits)
        {
            if((totalRequiredNumberOfUnits > (Convert.ToInt32(CountryStorageCapacity.ArgentinaStorage) + Convert.ToInt32(CountryStorageCapacity.BrazilStorage))) || totalRequiredNumberOfUnits % 10 != 0)
                return null;
            var ipodLogistics = new LogisticsForIPods()
            {
                CountryNames = new DeliverableCountryName()
                                    {
                                        CountryPrimary = primaryCountry,
                                        CountrySecondary = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ? Convert.ToString(Countries.Argentina) : Convert.ToString(Countries.Brazil),
                                    },
                UnitsDeliverable = GetUnitsDeliverablePerCountry(primaryCountry.ToLower(), totalRequiredNumberOfUnits),
                PricePerUnit = new PricePerCountry()
                {
                    PrimaryCountry = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ?
                                     LogisticsConstant.PricePerUnitBrazil : LogisticsConstant.PricePerUnitArgentina,
                    SecondaryCountry = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ?
                                        LogisticsConstant.PricePerUnitArgentina : LogisticsConstant.PricePerUnitBrazil,
                },
                PricePayableFor = new CountryBestPrice()
            };
            ipodLogistics.IsExtraShippingPriceRequired = (ipodLogistics.UnitsDeliverable.BySecondaryCounry > 0) ? true : false;
            
            return ipodLogistics;
        }

        public static UnitsDeliverable GetUnitsDeliverablePerCountry(string primaryCountry,int totalRequiredNumberOfUnits)
        {
            var unitsDeliverable = new UnitsDeliverable();
            var primaryCountryMaximumStorage = string.Equals((Convert.ToString(Countries.Brazil)), primaryCountry, StringComparison.OrdinalIgnoreCase) ? LogisticsConstant.ForBrazilStorage : LogisticsConstant.ForArgentinaStorage;
            //var secondaryCountryMaximumStorage = string.Equals((Convert.ToString(Countries.Brazil)), primaryCountry, StringComparison.OrdinalIgnoreCase) ? StorageConstants.ForArgentina : StorageConstants.ForBrazil;

            var difference = totalRequiredNumberOfUnits - primaryCountryMaximumStorage;
            unitsDeliverable.BySecondaryCounry = (difference >= 0) ? difference : 0;
            unitsDeliverable.ByPrimaryCounry = (difference >= 0) ? primaryCountryMaximumStorage : totalRequiredNumberOfUnits;

            return unitsDeliverable;
        }



    }
}
