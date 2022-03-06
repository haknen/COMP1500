using System;

namespace Lab7
{
    internal class Lab7
    {
        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1 || array[0] >= array.Length || array[0] < 1)
            {
                return false;
            }

            uint[] callCount = new uint[array.Length];

            return RightThrough(array, array[0]) || Search(array, callCount, array[0]);
        }

        public static bool RightThrough(uint[] array, uint position)
        {
            uint right = position + array[position];

            if (position == array.Length - 1)
            {
                return true;
            }

            if (right > array.Length - 1)
            {
                return false;
            }

            return RightThrough(array, right);
        }

        public static bool Search(uint[] array, uint[] callCount, uint position)
        {
            callCount[position]++;
            uint left = position > array[position] ? position - array[position] : 0;
            uint right = position + array[position];

            if (position == array.Length - 1)
            {
                return true;
            }

            if (position < 1 || position >= array.Length ||
                callCount[position] >= array.Length)
            {
                return false;
            }

            if (left > 0 && right < array.Length)
            {
                return Search(array, callCount, left) ||
                Search(array, callCount, right);
            }

            if (left < 1 && right < array.Length)
            {
                return Search(array, callCount, right);
            }

            if (left > 0 && right >= array.Length)
            {
                return Search(array, callCount, left);
            }

            return false;
        }
    }
}
