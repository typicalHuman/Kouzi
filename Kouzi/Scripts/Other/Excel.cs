using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Kouzi.Scripts.Other
{
    public class Excel
    {
        private Application ExcelApp { get; set; } = new Application();

        private Workbook Book { get; set; }

        private Worksheet Sheet { get; set; } = new Worksheet();

        private string directoryPath { get; set; }

        #region Constructor

        public Excel(string directoryPath)
        {
            Book = ExcelApp.Workbooks.Add();
            Sheet = (Worksheet)Book.Worksheets.get_Item(1);
            this.directoryPath = directoryPath;
            Write();
        }

        #endregion

        #region File Manipulation
        public void Save()
        {
            try
            {
                Book.SaveAs(@"C:\Users\typical\Desktop\doc.xlsx");
                Book.Close();
                Marshal.ReleaseComObject(Sheet);
            }
            catch(Exception ex)
            {  }
        }

        public void Open()
        {

        }
        #endregion

        #region WriteData

        #region Write

        public void Write()
        {
            SetTitle();
            SetContent();
            Sheet.Columns.AutoFit();
            Save();
        }

        #endregion

        #region SetBorder

        public void SetTitleLine()
        {
            Range range = ExcelApp.Range[Sheet.Cells[1, 1], Sheet.Cells[1, 11]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetButtomLine(int cellI)
        {
            Range range = ExcelApp.Range[Sheet.Cells[cellI, 1], Sheet.Cells[cellI, 11]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetVerticalLines(int cellI)
        {
            Range range = ExcelApp.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI - 1, 12]];
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

        #region SetContent

        public void SetContent()
        {
            int cellI, i, k;
            for(cellI = 2, i = 0; i < App.MainPageVM.Buyers.Count; cellI++, i++)
            {
                Sheet.Cells[cellI, 1] = App.MainPageVM.Buyers[i].Index;
                Sheet.Cells[cellI, 2] = App.MainPageVM.Buyers[i].Date;
                Sheet.Cells[cellI, 3] = App.MainPageVM.Buyers[i].Name;
                bool isCreditFilled = false;
                for(k = 0 ; k < App.MainPageVM.Buyers[i].EquipmentList.Count; k++)
                {
                    Sheet.Cells[cellI + k, 4] = App.MainPageVM.Buyers[i].EquipmentList[k].Name;
                    Sheet.Cells[cellI + k, 5] = App.MainPageVM.Buyers[i].EquipmentList[k].Count;
                    Sheet.Cells[cellI + k, 6] = App.MainPageVM.Buyers[i].EquipmentList[k].Cost;
                    Sheet.Cells[cellI + k, 7] = App.MainPageVM.Buyers[i].EquipmentList[k].Sum;
                    Sheet.Cells[cellI + k, 8] = App.MainPageVM.Buyers[i].EquipmentList[k].MyCost;
                    Sheet.Cells[cellI + k, 9] = App.MainPageVM.Buyers[i].EquipmentList[k].MySum;
                    Sheet.Cells[cellI + k, 10] = App.MainPageVM.Buyers[i].EquipmentList[k].Diff;
                    if(k >= App.MainPageVM.Buyers[i].EquipmentList.Count - 2 && !isCreditFilled)
                    {
                        Sheet.Cells[cellI + k, 11] = $"Кредит: {App.MainPageVM.Buyers[i].Credit}";
                        Sheet.Cells[cellI + k + 1, 11] = $"Дебет: {App.MainPageVM.Buyers[i].Debit}";
                        isCreditFilled = true;
                    }
                }
                if (App.MainPageVM.Buyers[i].EquipmentList.Count == 1)
                    cellI += k;
                else
                    cellI += k - 1;
                SetButtomLine(cellI);
            }
            SetVerticalLines(cellI);
            SetAlignment(cellI);
        }

        #endregion

        #region SetTitle

        string[] title = {"1.Номер", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

        public void SetTitle()
        {
            for(int i = 0; i < title.Length; i++)
            {
                Sheet.Cells[1, i + 1] = title[i];
            }
            SetTitleLine();
        }

        #endregion

        #endregion

    }
}
