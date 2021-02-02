using IPodStorage.Models;

namespace IPodStorage.Interfaces
{
    public interface ICountryPriceService
    {
        PricePerCountry CalculatePricePerCountry(string primaryCountry);

        float CalculateBestPrice(int numberOfUnits, float pricePerUnit, bool isExtraShippingChargeRequired);

        bool IsExtraShippingCostRequired(int unitsToBeDeliveredBySecondaryCountry);
    }
}
