using Kouzi.Scripts.Model;
using Microsoft.Office.Interop.Excel;
using System;

namespace Kouzi.Scripts.Other
{
    /// <summary>
    /// Class for buyers sheet.
    /// </summary>
    class BuyerSheet : SheetBase
    {
        #region Constants

        private const string CUSTOMER = "Заказчик";
        private const string BUYERS = "Покупатели";

        private const int CUSTOMER_TITLE_INDEX = 0; 

        private const int COLUMNS_NUMBER = 7;

        #endregion

        #region Methods

        public override void SetData()
        {
            data = new object[rows, columns];
            int k, i, cellI;
            for(i = 0, cellI = 0; i < App.BuyersResultPageVM.BuyersList.Count; i++, cellI++)
            {
                SetTitleContent(ref cellI, i);
                for(k = 0; k < App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count; k++)
                {
                    Equipment equip = App.BuyersResultPageVM.BuyersList[i].EquipmentList[k];
                    SetEquipmentContent(equip, cellI, k);
                }
                cellI += k ;
            }
        }

        private void SetTitleContent(ref int cellI, int i)
        {
            SetTopLine(cellI);
            data[cellI, CUSTOMER_TITLE_INDEX] = $"{CUSTOMER} - {App.BuyersResultPageVM.BuyersList[i].Name}";
            cellI++;
            SetButtomLine(cellI);
            if (App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count > 0)
            {
                SetTitle(cellI);
                cellI++;
            }
        }

        private void SetEquipmentContent(Equipment equip, int cellI, int k)
        {
            int index = cellI + k;
            data[index, Equipment.EQUIP_NAME_INDEX] = equip.Name;
            data[index, Equipment.EQUIP_COUNT_INDEX] = equip.Count;
            data[index, Equipment.EQUIP_COST_INDEX] = equip.Cost;
            data[index, Equipment.EQUIP_SUM_INDEX] = equip.Sum;
            data[index, Equipment.EQUIP_MYCOST_INDEX] = equip.MyCost;
            data[index, Equipment.EQUIP_MYSUM_INDEX] = equip.MySum;
            data[index, Equipment.EQUIP_DIFF_INDEX] = equip.Diff;
        }

        public override object[,] GetData()
        {
            SetData();
            return data;
        }

        public override void SetDataSize()
        {
            App.BuyersResultPageVM.SetBuyersList();
            columns = COLUMNS_NUMBER;
            int counter = 0;
            int i;
            for (i = 0; i < App.BuyersResultPageVM.BuyersList.Count; i++)
            {
                counter++;
                if (App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count > 0)
                {
                    counter++;
                }
                counter += App.BuyersResultPageVM.BuyersList[i].EquipmentList.Count - 1;
            }
            rows = counter;
        }

        public override void SetTitle(int buyerIndex)
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
            try
            {
                SetSheetContent();
                SetAlignment(rows + 1);
                SetButtomLine(rows);
                SetVerticalLines(rows, columns + 1);
                Sheet.Columns.AutoFit();
            }
            catch (Exception) { }
        }

        private void SetSheetContent()
        {
            Sheet.Name = BUYERS;
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
        }
        #endregion
    }
}
