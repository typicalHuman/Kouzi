using Kouzi.Scripts.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    public class MainSheet : SheetBase
    {
        public override Worksheet Sheet { get; set; }

        public override void SetSheet()
        {
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
            SetAlignment(rows);
            SetButtomLine(rows - 1);
            SetVerticalLines(rows - 1);
            Sheet.Columns.AutoFit();
        }

        public override object[,] GetData()
        {
            object[,] data = new object[rows, columns];
            SetData(ref data);
            SetTitle(ref data);
            return data;
        }

        public override void SetData(ref object[,] data)
        {
            data = new object[rows, columns];
            int cellI, i, k;
            for (cellI = 1, i = 0; i < App.MainPageVM.Buyers.Count; cellI++, i++)
            {
                data[cellI, 0] = App.MainPageVM.Buyers[i].Index;
                data[cellI, 1] = App.MainPageVM.Buyers[i].Date;
                data[cellI, 2] = App.MainPageVM.Buyers[i].Name;
                bool isCreditFilled = false;
                SetButtomLine(cellI);
                for (k = 0; k < App.MainPageVM.Buyers[i].EquipmentList.Count; k++)
                {
                    Equipment equip = App.MainPageVM.Buyers[i].EquipmentList[k];
                    data[cellI + k, 3] = equip.Name;
                    data[cellI + k, 4] = equip.Count;
                    data[cellI + k, 5] = equip.Cost;
                    data[cellI + k, 6] = equip.Sum;
                    data[cellI + k, 7] = equip.MyCost;
                    data[cellI + k, 8] = equip.MySum;
                    data[cellI + k, 9] = equip.Diff;
                    if (k >= App.MainPageVM.Buyers[i].EquipmentList.Count - 2 && !isCreditFilled)
                    {
                        data[cellI + k, 10] = $"Кредит: {App.MainPageVM.Buyers[i].Credit}";
                        data[cellI + k + 1, 10] = $"Дебет: {App.MainPageVM.Buyers[i].Debit}";
                        isCreditFilled = true;
                    }
                }
                if (App.MainPageVM.Buyers[i].EquipmentList.Count == 1)
                    cellI += k;
                else
                    cellI += k - 1;
            }
        }

        public override void SetDataSize()
        {
            columns = 11;
            int cellI, i, k;
            for (cellI = 1, i = 0; i < App.MainPageVM.Buyers.Count; cellI++, i++)
            {
                bool isCreditFilled = false;
                for (k = 0; k < App.MainPageVM.Buyers[i].EquipmentList.Count; k++)
                {
                    if (k >= App.MainPageVM.Buyers[i].EquipmentList.Count - 2 && !isCreditFilled)
                    {
                        isCreditFilled = true;
                    }
                }
                if (App.MainPageVM.Buyers[i].EquipmentList.Count == 1)
                    cellI += k;
                else
                    cellI += k - 1;
            }
            rows = cellI + 1;
        }

        public override void SetTitle(ref object[,] data)
        {
            for (int i = 0; i < columns; i++)
                data[0, i] = title[i];
            SetTitleLine();
        }

        #region ReadData

        public object[,] ReadData()
        {
            object[,] data = null;
            Range range = Sheet.UsedRange;
            data = (object[,])range.Value2;
            SetBuyersData(ref data);
            return data;
        }

        private void SetBuyersData(ref object[,] data)
        {
            App.MainPageVM.Buyers = new BuyerCollection();
            for (int i = 2; i < data.GetLength(0); i++)
            {
                if (data[i, 1] != null)
                {
                    Buyer b = new Buyer()
                    {
                        Date = (string)data[i, 2],
                        Name = (string)data[i, 3],
                        Credit = ((string)data[i, 11]).Replace("Кредит: ", ""),
                        Debit = ((string)data[i + 1, 11]).Replace("Дебет: ", "")
                    };
                    Equipment equip = GetEquipment(data, i);
                    b.EquipmentList.AddExcelEquipment(equip, b.Index);
                    App.MainPageVM.Buyers.Add(b);
                }
                for (int k = i; data[k, 1] == null && data[k, 4] != null; k++)
                {
                    Equipment equip = GetEquipment(data, k);
                    Buyer last = App.MainPageVM.Buyers[App.MainPageVM.Buyers.Count - 1];
                    last.EquipmentList.AddExcelEquipment(equip, last.Index);
                }
            }
        }

        private Equipment GetEquipment(object[,] data, int row)
        {
            try
            {
                Equipment equip = new Equipment()
                {
                    Name = data[row, 4].ToString(),
                    Count = data[row, 5].ToString(),
                    Cost = Convert.ToInt32(data[row, 6]),
                    Sum = Convert.ToInt32(data[row, 7]),
                    MyCost = Convert.ToInt32(data[row, 8]),
                    MySum = Convert.ToInt32(data[row, 9]),
                    Diff = Convert.ToInt32(data[row, 10])
                };
                return equip;
            }
            catch (Exception)
            { }
            return new Equipment();
        }

        #endregion
    }
}
