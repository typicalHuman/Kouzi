using Kouzi.Scripts.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    class BuyerSheet : SheetBase
    {
        public override void SetData(ref object[,] data)
        {
            data = new object[rows, columns];
            int k, i, cellI;
            for(i = 0, cellI = 0; i < App.BuyersResultPageVM.BuyersList.Count; i++, cellI++)
            {
                SetTopLine(cellI);
                data[cellI, 0] = $"Заказчик - {App.BuyersResultPageVM.BuyersList[i].Name}";
                cellI++;
                SetButtomLine(cellI);
                if (App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count > 0)
                {
                    SetTitle(ref data, cellI);
                    cellI++;
                }
                for(k = 0; k < App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count; k++)
                {
                    Equipment equip = App.BuyersResultPageVM.BuyersList[i].EquipmentList[k];
                    data[cellI + k, 0] = equip.Name;
                    data[cellI + k, 1] = equip.Count;
                    data[cellI + k, 2] = equip.Cost;
                    data[cellI + k, 3] = equip.Sum;
                    data[cellI + k, 4] = equip.MyCost;
                    data[cellI + k, 5] = equip.MySum;
                    data[cellI + k, 6] = equip.Diff;
                }
                cellI += k ;
            }
        }

        public override object[,] GetData()
        {
            object[,] data = new object[rows, columns];
            SetData(ref data);
            return data;
        }

        public override void SetDataSize()
        {
            App.BuyersResultPageVM.SetBuyersList();
            columns = 7;
            int counter = 0;
            int i, k;
            for (i = 0; i < App.BuyersResultPageVM.BuyersList.Count; i++)
            {
                counter++;
                if (App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count > 0)
                {
                    counter++;
                }
                for (k = 0; k < App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count; k++)
                {
                }
                counter += k + 1;
            }
            rows = counter;
        }

        public override void SetTitle(ref object[,] data, int buyerIndex)
        {
            for (int i = 3; i < title.Length - 1; i++)
            {
                data[buyerIndex, i - 3] = title[i];
                data[buyerIndex, i - 3] = data[buyerIndex, i - 3].ToString().Replace($"{i + 1}.", "");
            }
            SetTitleLine();
        }

        public override void SetSheet()
        {
            Sheet.Name = "Покупатели";
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
            SetAlignment(rows + 1);
            SetButtomLine(rows);
            SetVerticalLines(rows, columns + 1);
            Sheet.Columns.AutoFit();
        }
    }
}
