using System;
using System.Collections.Generic;

namespace Assignment3
{
    public static class TowerOfHanoi
    {

        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs < 0)
            {
                return -1;
            }

            return (int)Math.Pow(2, numDiscs) - 1;
        }

        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            List<List<int>[]> sequences = new List<List<int>[]>();

            if (numDiscs < 1)
            {
                return sequences;
            }

            List<int>[] scene = new List<int>[3];
            for (int i = 0; i < scene.Length; i++)
            {
                scene[i] = new List<int>();
            }

            sequences.Add(scene);

            return sequences;
        }

        public static bool MoveDiscs(List<int> start, List<int> end, int disc)
        {
            if (disc == 1)
            {
                end.Add(disc);
                start.Remove(disc);
                return true;
            }

            MoveDiscs(start, end, disc - 1);
            return false;
        }
    }
}