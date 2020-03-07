using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    class DateWorkHelper
    {
        private delegate int Comparer (string date);

        public static int Compare(string date1, string date2)
        {
            Comparer comparer = GetYear;
            int result = ComparerPattern(comparer, date1, date2);
            if (result != 0) 
                return result;
            comparer = GetMonth;
            result = ComparerPattern(comparer, date1, date2);
            if (result != 0)
                return result;
            comparer = GetDay;
            result = ComparerPattern(comparer, date1, date2);
            if (result != 0)
                return result;
            return 0;
        }

        private static int ComparerPattern(Comparer comparer, string date1, string date2)
        {
                return comparer(date1).CompareTo(comparer(date2));
        }

        private static int GetDay(string date)
        {
            return int.Parse(date.Split('.')[0]);
        }

        private static int GetMonth(string date)
        {
            return int.Parse(date.Split('.')[1]);
        }

        private static int GetYear(string date)
        {
            return int.Parse(date.Split('.')[2]);
        }
    }
}
