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
            {
                return null;
            }
            var ipodLogistics = new LogisticsForIPods()
            {
                PrimaryCountry = primaryCountry,
                UnitsDeliveredByPrimaryCounry = totalRequiredNumberOfUnits - Convert.ToInt32(CountryStorageCapacity.ArgentinaStorage),
                SecondaryCountry = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ? Convert.ToString(Countries.Argentina) : Convert.ToString(Countries.Brazil),
                UnitsDeliveredBySecondaryCounry = totalRequiredNumberOfUnits - Convert.ToInt32(CountryStorageCapacity.ArgentinaStorage) - Convert.ToInt32(CountryStorageCapacity.BrazilStorage),
            };

            return ipodLogistics;
        }

      
    }
}
