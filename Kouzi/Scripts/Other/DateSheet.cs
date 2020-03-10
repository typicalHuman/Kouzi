using Kouzi.Scripts.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    class DateSheet : SheetBase
    {

        private List<DateTime>[] dates { get; set; }

        private string[] months = {"Январь", "Февраль", "Март", 
                                   "Апрель", "Май", "Июнь", 
                                   "Июль", "Август", "Сентябрь",
                                   "Октябрь", "Ноябрь", "Декабрь"};

        public override void SetData(ref object[,] data)
        {
            data = new object[rows, DateWorkHelper.GetMaxDaysInMonths(dates) + 1];
            int currentRow = 0;
            for (int i = 0; i < 12; i++)
            {
                if (dates[i] != null)
                {
                    columns = dates[i].Count + 1;
                    SetMonthData(ref data, ref currentRow, i);
                }
            }
        }

        private void SetMonthData(ref object[,] data, ref int row, int monthIndex)
        {
            int startRow = row + 1;
            data[row, 0] = months[monthIndex];
            SetButtomLine(row + 1);
            SetTopLine(row + 1);
            SetDays(ref data, ref row, monthIndex);
            SetEquipment(ref data, ref row, startRow);
            SetCount(ref data, row, startRow, monthIndex);
        }

        private void SetCount(ref object[,] data, int row, int startRow, int monthIndex)
        {
            for(int i = 0; i < row - startRow - 1; i++)
            {
                for(int k = 1; k < columns; k++)
                {
                    data[i + startRow, k] = GetCount(data[i + startRow , 0], (int)data[startRow - 1, k], monthIndex);
                    SetButtomLine(i + startRow);
                }
            }
        }

        private int GetCount(object data, int day, int monthIndex)
        {
            string name = (string)data;
            int count = 0;
            for (int i = 0; i < App.MainPageVM.Buyers.Count; i++)
            {
                for (int k = 0; k < App.MainPageVM.Buyers[i].EquipmentList.Count; k++)
                {
                    Equipment equip = App.MainPageVM.Buyers[i].EquipmentList[k];
                    if (equip.Name == name)
                    {
                        DateTime date = GetDateFromString(equip.Date);
                        if(date != default && date.Day == day && date.Month == monthIndex + 1)
                        {
                            count += int.Parse(equip.Count);
                        }
                    }
                }
            }
            return count;
        }

        private DateTime GetDateFromString(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
                return result;
            return default;
        }

        private void SetDays(ref object[,] data, ref int row, int monthIndex)
        {
            for (int i = 1; i < dates[monthIndex].Count + 1; i++)
            {
                data[row, i] = dates[monthIndex][i - 1].Day;
            }
            row++;
        }

        private void SetEquipment(ref object[,] data, ref int row, int startRow)
        {
            for (int k = 0; k < App.MainPageVM.EquipmentsInfo.Count; k++)
            {
                data[row, 0] = App.MainPageVM.EquipmentsInfo[k].Name;
                row++;
            }
            SetVerticalLines(row, columns + 1, startRow);
            SetButtomLine(row);
            row++;
        }

        public override void SetDataSize()
        {
            dates = DateWorkHelper.GetDatesByMonths();
            bool isFirstFilled = false;
            for(int i = 0; i < dates.Length; i++)
            {
                if (dates[i] != null)
                {
                    rows += App.MainPageVM.EquipmentsInfo.Count + 2;
                    if (!isFirstFilled)
                    {
                        columns = dates[i].Count + 1;
                        isFirstFilled = true;
                    }
                }
            }
        }

        public override void SetSheet()
        {
            Sheet.Name = "По датам";
            if(rows != 0 && columns != 0)
            {
                try
                {
                    Range start = (Range)Sheet.Cells[1, 1];
                    Range end = (Range)Sheet.Cells[rows, DateWorkHelper.GetMaxDaysInMonths(dates) + 1];
                    Sheet.Range[start, end].Value2 = GetData();
                    SetAlignment(rows + 1);
                    Sheet.Columns.AutoFit();
                    start = (Range)Sheet.Cells[1, 2];
                    end = (Range)Sheet.Cells[rows, DateWorkHelper.GetMaxDaysInMonths(dates) + 1];
                    Sheet.Range[start, end].UseStandardWidth = 45;
                }
                catch (Exception) { }
            }
        }

        public override void SetTitle(ref object[,] data, int rowIndex = 0)
        {
        }
    }
}
