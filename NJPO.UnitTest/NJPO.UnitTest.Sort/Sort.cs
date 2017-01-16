using System;
using System.Collections.Generic;
using System.Linq;

namespace NJPO.UnitTest.Sort
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class Sort
    {
        public List<int> Numbers { get; set; }

        public Sort()
        {
            Numbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 10000000; i++)
            {
                Numbers.Add(rand.Next());
            }
        }

        public List<int> GetSortedList(SortDirection direction = SortDirection.Ascending)
        {
            return direction == SortDirection.Ascending ? Numbers.OrderBy(x => x).ToList() : Numbers.OrderByDescending(x => x).ToList();
        }
    }
}
