using IPodStorage.ENums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.CommonHelpers
{
    public static class CalculatePrice
    {
        public static float CalculatePriceByCountry(string countryName,int numberOfUnits,float pricePerUnit, bool isExtraShippingChargeRequired)
        {
            float price = 0.0f;
            int isExtraShippingNeeded = isExtraShippingChargeRequired ? 1 : 0;
            int countryIndicator = string.Equals(Convert.ToString(Countries.Brazil),countryName.Trim(),StringComparison.OrdinalIgnoreCase)? 1:2;
            price = numberOfUnits * pricePerUnit + isExtraShippingNeeded * (numberOfUnits / 10.0f) * 400f;

            return price;
        }
    }
}
