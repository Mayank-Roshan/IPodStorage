using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Interfaces
{
    public interface ICountryDeliverablesService
    {
        DeliverableCountryName GetCountryDeliverableOrder(string primaryCountryName);
    }
}
