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
        }
    }
}
