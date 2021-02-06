using System.Collections.Generic;
using System;

namespace DG2D.Utils
{
    public static class Utils
    {
        public static Random DG2DRand = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = DG2DRand.Next(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

