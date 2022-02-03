using System;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            bool bFixed = false;

            if (usersPerDay.Length == revenuePerDay.Length)
            {
                double revenue;

                for (int i = 0; i < usersPerDay.Length; i++)
                {
                    if (usersPerDay[i] <= 10)
                    {
                        revenue = usersPerDay[i] / 2.0;
                    }
                    else if (usersPerDay[i] <= 100)
                    {
                        revenue = 16 * usersPerDay[i] / 5.0 - 27;
                    }
                    else if (usersPerDay[i] <= 1000)
                    {
                        revenue = Math.Pow(usersPerDay[i], 2) / 4.0 - 2 * usersPerDay[i] - 2007;
                    }
                    else
                    {
                        revenue = 245743 + usersPerDay[i] / 4.0;
                    }

                    revenue = Math.Round(revenue, 2);

                    if (revenue != revenuePerDay[i])
                    {
                        revenuePerDay[i] = revenue;
                        bFixed = true;
                    }
                }
            }

            return bFixed;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            if (usersPerDay.Length == revenuePerDay.Length)
            {
                int fixCount = 0;

                for (int i = 0; i < usersPerDay.Length; i++)
                {
                    double revenue;

                    if (usersPerDay[i] <= 10)
                    {
                        revenue = usersPerDay[i] / 2.0;
                    }
                    else if (usersPerDay[i] <= 100)
                    {
                        revenue = 16 * usersPerDay[i] / 5.0 - 27;
                    }
                    else if (usersPerDay[i] <= 1000)
                    {
                        revenue = Math.Pow(usersPerDay[i], 2) / 4.0 - 2 * usersPerDay[i] - 2007;
                    }
                    else
                    {
                        revenue = 245743 + usersPerDay[i] / 4.0;
                    }

                    revenue = Math.Round(revenue, 2);

                    if (revenue != revenuePerDay[i])
                    {
                        fixCount++;
                    }
                }

                return fixCount;
            }

            else
            {
                return -1;
            }
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            if (revenuePerDay.Length != 0 && start <= end &&
                start < revenuePerDay.Length && end < revenuePerDay.Length)
            {
                double totalRevenue = 0.0;

                for (uint i = start; i <= end; i++)
                {
                    totalRevenue += revenuePerDay[i];
                }

                return totalRevenue;
            }

            return -1;
        }
    }
}
