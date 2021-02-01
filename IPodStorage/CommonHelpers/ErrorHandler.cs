using IPodStorage.ENums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPodStorage.CommonHelpers
{
    public static class ErrorHandler
    {
        public static void DiplayError(int totalRequiredNumberOfUnits)
        {
            if (totalRequiredNumberOfUnits > (Convert.ToInt32(CountryStorageCapacity.ArgentinaStorage) + Convert.ToInt32(CountryStorageCapacity.BrazilStorage)))
            {
                Console.WriteLine("Out Of Stock!!");
            }
            else if (totalRequiredNumberOfUnits % 10 != 0)
            {
                Console.WriteLine("The units ordered must be multiples of 10");
            }
        }
    }
}
