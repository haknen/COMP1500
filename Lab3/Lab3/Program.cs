using System;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader READER = new StreamReader(Console.OpenStandardInput()))
            {
                double totalCost = RestaurantBillCalculator.CalculateTotalCost(READER);

                double individualCost = RestaurantBillCalculator.CalculateIndividualCost(READER, totalCost);
                
                uint payerCount = RestaurantBillCalculator.CalculatePayerCount(READER, totalCost);
            }
        }
    }
}
