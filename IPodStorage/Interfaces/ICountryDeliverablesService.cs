using IPodStorage.Models;

namespace IPodStorage.Interfaces
{
    public interface ICountryDeliverablesService
    {
        DeliverableCountryName GetCountryDeliverableOrder(string primaryCountryName);
    }
}
