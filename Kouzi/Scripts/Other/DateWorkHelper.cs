using Kouzi.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    class DateWorkHelper
    {
        public static List<DateTime>[] GetDatesByMonths()
        {
            List<DateTime>[] dates = new List<DateTime>[12];
            App.EquipmentsResultPageVM.SetEquipmentsList();
            for (int j = 0; j < App.MainPageVM.Buyers.Count; j++)
            {
                for (int i = 0; i < App.MainPageVM.Buyers[j].EquipmentList.Count; i++)
                {
                    DateTime date;
                    Equipment equip = App.MainPageVM.Buyers[j].EquipmentList[i];
                    if (DateTime.TryParse(equip.Date, out date))
                    {
                        date = DateTime.Parse(equip.Date);
                        if (dates[date.Month - 1] == null)
                            dates[date.Month - 1] = new List<DateTime>();
                        dates[date.Month - 1].Add(date);
                    }
                }
            }
            RemoveSame(ref dates);
            Sort(ref dates);
            return dates;
        }

        public static int GetMaxDaysInMonths(List<DateTime>[] dates)
        {
            int max = 0;
            int k;
            for(int i = 0; i < dates.Length; i++)
            {
                for(k = 0; dates[i] != null && k < dates[i].Count; k++)
                {
                }
                if (k > max)
                    max = k;
            }
            return max;
        }

        private static void RemoveSame(ref List<DateTime>[] dates)
        {
            for(int i = 0; i < 12; i++)
            {
                for(int k = 0; dates[i] != null && k < dates[i].Count; k++)
                {
                    for(int j = 0; j < dates[i].Count; j++)
                    {
                        if (k != j && dates[i][k] == dates[i][j])
                            dates[i].RemoveAt(j);
                    }
                }
            }
        }

        private static void Sort(ref List<DateTime>[] dates)
        {
            for(int i = 0; i < 12; i++)
            {
                for (int k = 0; dates[i] != null && k < dates[i].Count; k++)
                {
                    for (int j = 0; j < dates[i].Count - 1 - k; j++)
                    {
                        if (dates[i][j].Day > dates[i][j + 1].Day)
                        {
                            DateTime temp = dates[i][j + 1];
                            dates[i][j + 1] = dates[i][j];
                            dates[i][j] = temp;
                        }
                    }
                }
            }
        }
    }
}
