using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            if (width <= 9)
            {
                width = 10;
            }

            string num1 = input.ReadLine().Trim();
            long int1 = long.Parse(num1);
            string num2 = input.ReadLine().Trim();
            long int2 = long.Parse(num2);
            string num3 = input.ReadLine().Trim();
            long int3 = long.Parse(num3);
            string num4 = input.ReadLine().Trim();
            long int4 = long.Parse(num4);
            string num5 = input.ReadLine().Trim();
            long int5 = long.Parse(num5);

            output.WriteLine($"{"oct".PadLeft(width)} {"dec".PadLeft(width)} {"hex".PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int1, 8).PadLeft(width)} {num1.PadLeft(width)} {Convert.ToString(int1, 16).ToUpper().PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int2, 8).PadLeft(width)} {num2.PadLeft(width)} {Convert.ToString(int2, 16).ToUpper().PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int3, 8).PadLeft(width)} {num3.PadLeft(width)} {Convert.ToString(int3, 16).ToUpper().PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int4, 8).PadLeft(width)} {num4.PadLeft(width)} {Convert.ToString(int4, 16).ToUpper().PadLeft(width)}");
            output.WriteLine($"{Convert.ToString(int5, 8).PadLeft(width)} {num5.PadLeft(width)} {Convert.ToString(int5, 16).ToUpper().PadLeft(width)}");
        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            string num1 = input.ReadLine().Trim();
            double double1 = double.Parse(num1);

            string num2 = input.ReadLine().Trim();
            double double2 = double.Parse(num2);
            double max = Math.Max(double1, double2);
            double min = Math.Min(double1, double2);

            string num3 = input.ReadLine().Trim();
            double double3 = double.Parse(num3);
            max = Math.Max(double3, max);
            min = Math.Min(double3, min);

            string num4 = input.ReadLine().Trim();
            double double4 = double.Parse(num4);
            max = Math.Max(double4, max);
            min = Math.Min(double4, min);

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
