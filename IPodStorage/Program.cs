using IPodStorage.CommonHelpers;
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
            var bestPrice = priceCalculator.CalculateBestPrice(iPodLogisticsDistribution);
           
            Console.WriteLine("Vest Price = " + bestPrice);
        }
    }
}
