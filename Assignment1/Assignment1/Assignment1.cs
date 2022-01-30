using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            if(width <= 9)
            {
                width = 10;
            }

            output.Write("Type 1st integer : ");
            string num1 = input.ReadLine().Trim();
            int int1 = int.Parse(num1);
            output.Write("Type 2nd integer : ");
            string num2 = input.ReadLine().Trim();
            int int2 = int.Parse(num2);
            output.Write("Type 3rd integer : ");
            string num3 = input.ReadLine().Trim();
            int int3 = int.Parse(num3);
            output.Write("Type 4th integer : ");
            string num4 = input.ReadLine().Trim();
            int int4 = int.Parse(num4);
            output.Write("Type 5th integer : ");
            string num5 = input.ReadLine().Trim();
            int int5 = int.Parse(num5);

            output.WriteLine($"{"oct".PadLeft(width)} {"dec".PadLeft(width)} {"hex".PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int1, 8).PadLeft(width)} {num1.PadLeft(width)} {Convert.ToString(int1, 16).PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int2, 8).PadLeft(width)} {num2.PadLeft(width)} {Convert.ToString(int2, 16).PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int3, 8).PadLeft(width)} {num3.PadLeft(width)} {Convert.ToString(int3, 16).PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int4, 8).PadLeft(width)} {num4.PadLeft(width)} {Convert.ToString(int4, 16).PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int5, 8).PadLeft(width)} {num5.PadLeft(width)} {Convert.ToString(int5, 16).PadLeft(width)}");
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            output.Write("Type 1st number : ");
            string num1 = input.ReadLine().Trim();
            double double1 = double.Parse(num1);

            output.Write("Type 2nd number : ");
            string num2 = input.ReadLine().Trim();
            double double2 = double.Parse(num2);
            double max = Math.Max(double1, double2);
            double min = Math.Min(double1, double2);

            output.Write("Type 3rd number : ");
            string num3 = input.ReadLine().Trim();
            double double3 = double.Parse(num3);
            max = Math.Max(double3, max);
            min = Math.Min(double3, min);

            output.Write("Type 4th number : ");
            string num4 = input.ReadLine().Trim();
            double double4 = double.Parse(num4);
            max = Math.Max(double4, max);
            min = Math.Min(double4, min);

            output.Write("Type 5th number : ");
            string num5 = input.ReadLine().Trim();
            double double5 = double.Parse(num5);
            max = Math.Max(double5, max);
            min = Math.Min(double5, min);

            double sum = double1 + double2 + double3 + double4 + double5;
            double average = sum / 5;

            output.WriteLine($"{double1,25:F3}\n{double2,25:F3}\n{double3,25:F3}\n{double4,25:F3}\n{double5,25:F3}");
            output.WriteLine($"Min{min,22:F3}\nMax{max,22:F3}\nSum{sum,22:F3}\nAverage{average,18:F3}");
        }
    }
}
