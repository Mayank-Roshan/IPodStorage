using IPodStorage.CommonHelpers;
using IPodStorage.ENums;
using System;

namespace IPodStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Country : iPods Required");
            string userInput = Console.ReadLine();
            string[] countryiPodsRequiredArray = userInput.Split(':');
            var calculateLogistics = new CalculateLogistis();
            var iPodLogisticsDistribution = calculateLogistics.CalculateIPodsLogistics(countryiPodsRequiredArray[0].Trim(), Convert.ToInt32(countryiPodsRequiredArray[1].Trim()));

            if (iPodLogisticsDistribution == null)
            {
                ErrorHandler.DiplayError(Convert.ToInt32(countryiPodsRequiredArray[1].Trim()));
            }

            var priceCalculator = new CalculatePrice();
            iPodLogisticsDistribution.PricePayableFor.PrimaryCountry = priceCalculator.CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.ByPrimaryCounry, iPodLogisticsDistribution.PricePerUnit.PrimaryCountry, false);
            
            if (iPodLogisticsDistribution.IsExtraShippingPriceRequired)
            {
                iPodLogisticsDistribution.PricePayableFor.SecondaryCountry = priceCalculator.CalculatePriceByCountry(iPodLogisticsDistribution.UnitsDeliverable.BySecondaryCounry, iPodLogisticsDistribution.PricePerUnit.SecondaryCountry, true);
            }
            Console.WriteLine("Vest Price = " + (iPodLogisticsDistribution.PricePayableFor.PrimaryCountry + iPodLogisticsDistribution.PricePayableFor.SecondaryCountry));
        }
    }
}
