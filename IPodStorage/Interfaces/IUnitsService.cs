using IPodStorage.Models;

namespace IPodStorage.Interfaces
{
    public interface IUnitsService
    {
        UnitsDeliverable GetUnitsDeliverablePerCountry(string primaryCountry, int totalRequiredNumberOfUnits);
    }
}
