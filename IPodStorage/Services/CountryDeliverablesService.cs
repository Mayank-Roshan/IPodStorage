using IPodStorage.ENums;
using IPodStorage.Interfaces;
using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Services
{
    public class CountryDeliverablesService : ICountryDeliverablesService
    {
        public DeliverableCountryName GetCountryDeliverableOrder(string primaryCountryName)
        {
            return new DeliverableCountryName()
                       {
                           CountryPrimary = primaryCountryName,
                           CountrySecondary = string.Equals(Convert.ToString(Countries.Brazil), primaryCountryName.Trim(), StringComparison.OrdinalIgnoreCase) ? Convert.ToString(Countries.Argentina) : Convert.ToString(Countries.Brazil),
                       };
        }
    }
}
