using System;
using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            string costInput;

            Console.Write("Type a 1st food cost : ");
            costInput = input.ReadLine();
            double cost1stFood = double.Parse(costInput);

            Console.Write("Type a 2nd food cost : ");
            costInput = input.ReadLine();
            double cost2ndFood = double.Parse(costInput);

            Console.Write("Type a 3rd food cost : ");
            costInput = input.ReadLine();
            double cost3rdFood = double.Parse(costInput);

            Console.Write("Type a 4th food cost : ");
            costInput = input.ReadLine();
            double cost4thFood = double.Parse(costInput);

            Console.Write("Type a 5th food cost : ");
            costInput = input.ReadLine();
            double cost5thFood = double.Parse(costInput);

            Console.Write("Type a tip percentage : ");
            string tipInput = input.ReadLine();
            int tipRate = int.Parse(tipInput);

            double costAllFood = cost1stFood + cost2ndFood + cost3rdFood +
                cost4thFood + cost5thFood;
            double tax = costAllFood * 0.05;
            double tip = (costAllFood + tax) * tipRate / 100;
            double totalCost = costAllFood + tax + tip;

            return Math.Round(totalCost, 2);
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            Console.Write("How many people will pay? : ");
            string people = input.ReadLine();
            int payers = int.Parse(people);

            return Math.Round(totalCost / payers, 2);
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            Console.Write("How much each person will pay? : ");
            string pay = input.ReadLine();
            double individualCost = double.Parse(pay);

            return (uint)Math.Ceiling(totalCost / individualCost);
        }
    }
}
