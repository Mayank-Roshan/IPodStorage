using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Interfaces
{
    public interface ICountryPriceService
    {
        PricePerCountry CalculatePricePerCountry(string primaryCountry);

        float CalculateBestPrice(int numberOfUnits, float pricePerUnit, bool isExtraShippingChargeRequired);

        bool IsExtraShippingCostRequired(int unitsToBeDeliveredBySecondaryCountry);
    }
}
