using IPodStorage.CommonHelpers;
using IPodStorage.ENums;
using System;

namespace IPodStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Country : iPods Required");
                string userInput = Console.ReadLine();
                string[] countryiPodsRequiredArray = userInput.Split(':');
                var iPodLogisticsDistribution = CalculateLogistis.CalculateIPodsLogistics(countryiPodsRequiredArray[0].Trim(), Convert.ToInt32(countryiPodsRequiredArray[1].Trim()));

                if(iPodLogisticsDistribution == null)
                {
                    ErrorHandler.DiplayError(Convert.ToInt32(countryiPodsRequiredArray[1].Trim()));
                    Console.WriteLine("\nEnter N to stop\n");
                    continue;
                }
                iPodLogisticsDistribution.PricePayableFor.PrimaryCountry = CalculatePrice.CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.ByPrimaryCounry, iPodLogisticsDistribution.PricePerUnit.PrimaryCountry, false);
                if (iPodLogisticsDistribution.IsExtraShippingPriceRequired)
                {
                    iPodLogisticsDistribution.PricePayableFor.SecondaryCountry = CalculatePrice.CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.BySecondaryCounry, iPodLogisticsDistribution.PricePerUnit.SecondaryCountry, true);
                }
                Console.WriteLine("Vest Price = " + (iPodLogisticsDistribution.PricePayableFor.PrimaryCountry + iPodLogisticsDistribution.PricePayableFor.SecondaryCountry));

                Console.WriteLine("\nEnter N to stop\n");

            } while (!string.Equals("N", Console.ReadLine(),StringComparison.OrdinalIgnoreCase));
        }
    }
}
