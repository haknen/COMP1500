using System;
using System.Collections.Generic;

namespace Lab9
{
    public static class Lab9
    {
        public static List<int> MergeLists(List<int> sortedList1, List<int> sortedList2)
        {
            List<int> combinedList = new List<int>();

            if (sortedList1 == null && sortedList2 == null)
            {
                return combinedList;
            }

            if (sortedList1 == null)
            {
                return sortedList2;
            }

            if (sortedList2 == null)
            {
                return sortedList1;
            }

            int i = 0;
            int j = 0;
            while (i < sortedList1.Count && j < sortedList2.Count)
            {
                if (sortedList1[i] < sortedList2[j])
                {
                    combinedList.Add(sortedList1[i++]);
                }
                else if (sortedList1[i] == sortedList2[j])
                {
                    combinedList.Add(sortedList1[i++]);
                    combinedList.Add(sortedList2[j++]);
                }
                else
                {
                    combinedList.Add(sortedList2[j++]);
                }
            }

            if (sortedList1.Count >= sortedList2.Count)
            {
                for (; i < sortedList1.Count; i++)
                {
                    combinedList.Add(sortedList1[i]);
                }
            }
            else
            {
                for (; j < sortedList2.Count; j++)
                {
                    combinedList.Add(sortedList2[j]);
                }
            }

            return combinedList;
        }

        public static Dictionary<string, int> CombineListsToDictionary(List<string> keys, List<int> values)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (keys == null || values == null)
            {
                return result;
            }

            int maxCount = keys.Count <= values.Count ? keys.Count : values.Count;
            for (int i = 0; i < maxCount; i++)
            {
                result.TryAdd(keys[i], values[i]);
            }

            return result;
        }

        public static Dictionary<string, decimal> MergeDictionaries(Dictionary<string, int> numerators, Dictionary<string, int> denominators)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            if (numerators == null || denominators == null)
            {
                return result;
            }

            foreach (var item in denominators)
            {
                if (numerators.ContainsKey(item.Key))
                {
                    if (item.Value == 0)
                    {
                        continue;
                    }

                    decimal newValue = numerators[item.Key] / (decimal)item.Value;
                    newValue = newValue < 0 ? newValue * -1 : newValue;

                    result.TryAdd(item.Key, newValue);
                }
            }

            return result;
        }
    }
}