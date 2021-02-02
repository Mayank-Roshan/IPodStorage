using IPodStorage.Constants;
using IPodStorage.ENums;
using IPodStorage.Interfaces;
using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Services
{
    public class CountryPriceService : ICountryPriceService
    {
        public PricePerCountry CalculatePricePerCountry(string primaryCountry)
        {
            return new PricePerCountry()
            {
                PrimaryCountry = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ?
                                     LogisticsConstant.PricePerUnitBrazil : LogisticsConstant.PricePerUnitArgentina,
                SecondaryCountry = string.Equals(Convert.ToString(Countries.Brazil), primaryCountry.Trim(), StringComparison.OrdinalIgnoreCase) ?
                                        LogisticsConstant.PricePerUnitArgentina : LogisticsConstant.PricePerUnitBrazil,
            };
        }

        public float CalculateBestPrice(int numberOfUnits, float pricePerUnit, bool isExtraShippingChargeRequired)
        {
            float price = 0.0f;
            int isExtraShippingNeeded = isExtraShippingChargeRequired ? 1 : 0;
            price = numberOfUnits * pricePerUnit + isExtraShippingNeeded * (numberOfUnits / 10.0f) * 400f;

            return price;
        }

        public bool IsExtraShippingCostRequired(int unitsToBeDeliveredBySecondaryCountry)
        {
            return (unitsToBeDeliveredBySecondaryCountry > 0) ? true : false;
        }
    }
}
