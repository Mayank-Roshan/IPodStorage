using IPodStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.Interfaces
{
    public interface IUnitsService
    {
        UnitsDeliverable GetUnitsDeliverablePerCountry(string primaryCountry, int totalRequiredNumberOfUnits);
    }
}
