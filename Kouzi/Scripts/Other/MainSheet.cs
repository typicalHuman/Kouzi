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
        public override void SetSheet()
        {
            Sheet.Name = "Общий лист";
            base.SetSheet();
        }

        public override object[,] GetData()
        {
            return base.GetData();
        }

        public override void SetData()
        {
            data = new object[rows, columns];
            int cellI, i, k;
            for (cellI = 1, i = 0; i < App.MainPageVM.Buyers.Count; cellI++, i++)
            {
                int equipmentsCount = App.MainPageVM.Buyers[i].EquipmentList.Count;
                data[cellI, 0] = App.MainPageVM.Buyers[i].Index;
                data[cellI, 1] = App.MainPageVM.Buyers[i].Date;
                data[cellI, 2] = App.MainPageVM.Buyers[i].Name;
                data[cellI, 11] = App.MainPageVM.Buyers[i].Benefit;
                bool isCreditFilled = false;
                SetButtomLine(cellI);
                for (k = 0; k < equipmentsCount; k++)
                {
                    Equipment equip = App.MainPageVM.Buyers[i].EquipmentList[k];
                    data[cellI + k, 3] = equip.Name;
                    data[cellI + k, 4] = equip.Count;
                    data[cellI + k, 5] = equip.Cost;
                    data[cellI + k, 6] = equip.Sum;
                    data[cellI + k, 7] = equip.MyCost;
                    data[cellI + k, 8] = equip.MySum;
                    data[cellI + k, 9] = equip.Diff;
                    if (k >= equipmentsCount - 2 && !isCreditFilled)
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
            columns = 12;
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

        public override void SetTitle(int buyerIndex)
        {
            for (int i = 0; i < columns - 1; i++)
                data[0, i] = title[i];
            SetTitleLine();
        }

        #region ReadData

        public object[,] ReadData()
        {
            object[,] data;
            Range range = Sheet.UsedRange;
            data = (object[,])range.Value2;
            SetBuyersData(ref data);
            return data;
        }

        private void SetBuyersData(ref object[,] data)
        {
            App.MainPageVM.Buyers = new BuyerCollection();
            int k = 0;
            var a = data.GetLength(0);
            Buyer last = new Buyer();
            for (int i = 2; i < data.GetLength(0); i++)
            {
                if (data[i, 1] != null)
                {
                    Buyer b = new Buyer()
                    {
                        Date = (string)data[i, 2],
                        Name = (string)data[i, 3],
                    };
                    Equipment equip = GetEquipment(data, i);
                    b.EquipmentList.AddExcelEquipment(equip, b);
                    App.MainPageVM.Buyers.Add(b);
                    last = b;
                }
                for (k = i + 1; k < data.GetLength(0) + 1
                    && data[k, 1] == null 
                    && data[k, 4] != null; k++)
                {
                    Equipment equip = GetEquipment(data, k);
                    last = App.MainPageVM.Buyers[App.MainPageVM.Buyers.Count - 1];
                    last.EquipmentList.AddExcelEquipment(equip, last);
                }
                i += k - 1 - i;
                last.Credit = ((string)data[i - 1, 11])?.Replace("Кредит: ", "");
                last.Debit = ((string)data[i, 11])?.Replace("Дебет: ", "");
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
            catch (DivideByZeroException)
            { }
            return new Equipment();
        }

        #endregion
    }
}
