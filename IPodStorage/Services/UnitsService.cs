using IPodStorage.Constants;
using IPodStorage.ENums;
using IPodStorage.Interfaces;
using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Services
{
    class UnitsService : IUnitsService
    {
        public UnitsDeliverable GetUnitsDeliverablePerCountry(string primaryCountry, int totalRequiredNumberOfUnits)
        {
            var unitsDeliverable = new UnitsDeliverable();
            var primaryCountryMaximumStorage = string.Equals((Convert.ToString(Countries.Brazil)), primaryCountry, StringComparison.OrdinalIgnoreCase) ? LogisticsConstant.ForBrazilStorage : LogisticsConstant.ForArgentinaStorage;

            var difference = totalRequiredNumberOfUnits - primaryCountryMaximumStorage;
            unitsDeliverable.BySecondaryCounry = (difference >= 0) ? difference : 0;
            unitsDeliverable.ByPrimaryCounry = (difference >= 0) ? primaryCountryMaximumStorage : totalRequiredNumberOfUnits;

            return unitsDeliverable;
        }
    }
}
