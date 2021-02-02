using IPodStorage.ENums;
using IPodStorage.Interfaces;
using IPodStorage.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.CommonHelpers
{
    public class CalculatePrice
    {
        private ICountryPriceService _countryPriceService;

        public CalculatePrice()
        {
            _countryPriceService = new CountryPriceService();
        }

        public float CalculatePriceByCountry(int numberOfUnits,float pricePerUnit, bool isExtraShippingChargeRequired)
        {            
            return _countryPriceService.CalculateBestPrice(numberOfUnits, pricePerUnit, isExtraShippingChargeRequired);
        }
    }
}
