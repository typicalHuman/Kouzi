using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kouzi.Scripts.Model;
using Microsoft.Office.Interop.Excel;

namespace Kouzi.Scripts.Other
{
    public class Excel
    {
        private Application ExcelApp { get; set; } = new Application();

        private static Workbook Book { get; set; }

        private static Worksheet Sheet { get; set; } = new Worksheet();

        private const int columns = 11;

        private int rows { get; set; }

        #region Constructor

        public Excel()
        {
            Book = ExcelApp.Workbooks.Add();
            Sheet = (Worksheet)Book.Worksheets.get_Item(1);
            SetDataRows();
        }

        #endregion

        #region File Manipulation
        public static void SaveAs(string directoryPath)
        {
            try
            {
                Book.SaveAs(directoryPath);
                Book.Close();
                Marshal.ReleaseComObject(Sheet);
            }
            catch(Exception ex)
            {  }
        }

        public void Open(string filePath)
        {
            Book = ExcelApp.Workbooks.Open(filePath);
            Sheet = Book.Sheets[1];
            object[,] data = ReadData();
            SetBuyersData(ref data);
            Book.Close();
            Marshal.ReleaseComObject(Sheet);
        }
        #endregion

        #region WriteData

        #region Write

        public void Write()
        {
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
            SetAlignment(rows);
            SetButtomLine(rows - 1);
            SetVerticalLines(rows - 1);
            Sheet.Columns.AutoFit();
        }

        private void SetMainData(ref object[,] data)
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
                    data[cellI + k, 3] = App.MainPageVM.Buyers[i].EquipmentList[k].Name;
                    data[cellI + k, 4] = App.MainPageVM.Buyers[i].EquipmentList[k].Count;
                    data[cellI + k, 5] = App.MainPageVM.Buyers[i].EquipmentList[k].Cost;
                    data[cellI + k, 6] = App.MainPageVM.Buyers[i].EquipmentList[k].Sum;
                    data[cellI + k, 7] = App.MainPageVM.Buyers[i].EquipmentList[k].MyCost;
                    data[cellI + k, 8] = App.MainPageVM.Buyers[i].EquipmentList[k].MySum;
                    data[cellI + k, 9] = App.MainPageVM.Buyers[i].EquipmentList[k].Diff;
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

        #endregion

        #region SetBorder

        public void SetTitleLine()
        {
            Range range = ExcelApp.Range[Sheet.Cells[1, 1], Sheet.Cells[1, columns]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetButtomLine(int cellI)
        {
            Range range = ExcelApp.Range[Sheet.Cells[cellI, 1], Sheet.Cells[cellI, columns]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetVerticalLines(int cellI)
        {
            Range range = ExcelApp.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI, 12]];
            range.Borders[XlBordersIndex.xlInsideVertical].Color = ConsoleColor.Black;
        }

        #endregion

        #region SetAlignment

        public void SetAlignment(int cellI)
        {
            Range range = ExcelApp.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI - 1, 12]];
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }

        #endregion

        #region SetTitle

        string[] title = {"1.Номер", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

        public void SetTitle(ref object [,] data)
        {
            for (int i = 0; i < columns; i++)
                data[0, i] = title[i];
            SetTitleLine();
        }

        #endregion

        #region GetData

        private object[,] GetData()
        {
            object[,] data = null;
            SetMainData(ref data);
            SetTitle(ref data);
            return data;
        }

        #endregion

        #region SetDataRows
        private void SetDataRows()
        {
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

        #endregion

        #endregion

        #region ReadData

        private object[,] ReadData()
        {
            object[,] data = null;
            Range range = Sheet.UsedRange;
            data = (object[,])range.Value2;
            return data;
        }

        private void SetBuyersData(ref object[,] data)
        {
            App.MainPageVM.Buyers = new BuyerCollection();
            for(int i = 2; i < data.GetLength(0); i++)
            {
                if(data[i, 1] != null)
                {
                    Buyer b = new Buyer()
                    {
                        Date = (string)data[i, 2],
                        Name = (string)data[i, 3],
                        Credit = (string)data[i, 11],
                        Debit = (string)data[i + 1, 11]
                    };
                    Equipment equip = GetEquipment(data, i);
                    b.EquipmentList.AddEquipment(equip, b.Index);
                    App.MainPageVM.Buyers.Add(b);
                }
                for(int k = i; data[k, 1] == null && data[k, 4] != null ; k++)
                {
                    Equipment equip = GetEquipment(data, k);
                    Buyer last = App.MainPageVM.Buyers[App.MainPageVM.Buyers.Count - 1];
                    last.EquipmentList.AddEquipment(equip, last.Index);
                }
            }
        }

        private Equipment GetEquipment(object[,] data, int row)
        {
            try
            {
                Equipment equip = new Equipment()
                {
                    Name = (string)data[row, 4],
                    Count = (string)data[row, 5],
                    Cost = (int)data[row, 6],
                    MyCost = (int)data[row, 8]
                };
            }
            catch (Exception)
            { }
            return new Equipment();
        }

        #endregion
    }
}
