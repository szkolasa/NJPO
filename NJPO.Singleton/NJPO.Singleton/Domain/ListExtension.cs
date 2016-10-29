using System;
using System.Collections.Generic;

namespace NJPO.Singleton.Domain
{
    public static class ListExtension
    {
        private static Random rng = new Random();

        /// <summary>
        /// Adds Shuffle method to generic List class
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
