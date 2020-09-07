using Microsoft.Office.Interop.Excel;
using System;
namespace Kouzi.Scripts.Other
{
    /// <summary>
    /// Abstract class to help in work with excel sheets.
    /// </summary>
    public abstract class SheetBase
    {
        /// <summary>
        /// Excell sheet.
        /// </summary>
        public Worksheet Sheet { get; set; }

        /// <summary>
        /// Rows number.
        /// </summary>
        protected int rows { get; set; }

        /// <summary>
        /// Columns number.
        /// </summary>
        protected int columns { get; set; }

        /// <summary>
        /// Sheet data.
        /// </summary>
        protected object[,] data { get; set; }

        /// <summary>
        /// Initialize data size.
        /// </summary>
        public SheetBase()
        {
            SetDataSize();
        }

        #region SetBorder

        public void SetTitleLine()
        {
            try
            {
                Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[1, columns]];
                range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
            }
            catch (Exception) {  }
        }
        public void SetButtomLine(int row)
        {
            try
            {
                if (row == 0)
                    row++;
                Range range = Sheet.Range[Sheet.Cells[row, 1], Sheet.Cells[row, columns]];
                range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
            }
            catch (Exception)
            {

            }
        }
        public void SetTopLine(int row)
        {
            try
            {

                if (row == 0)
                    row++;
                Range range = Sheet.Range[Sheet.Cells[row, 1], Sheet.Cells[row, columns]];
                range.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium;
                range.Borders[XlBordersIndex.xlEdgeTop].Color = ConsoleColor.Black;
            }
            catch (Exception)
            {

            }
        }
        public void SetVerticalLines(int row)
        {
            try
            {
                if (row == 0)
                    row++;
                Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[row, 12]];
                range.Borders[XlBordersIndex.xlInsideVertical].Color = ConsoleColor.Black;
            }
            catch (Exception)
            {

            }
        }
        public void SetVerticalLines(int row, int column)
        {
            try
            {
                if (row == 0)
                    row++;
                Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[row, column]];
                range.Borders[XlBordersIndex.xlInsideVertical].Color = ConsoleColor.Black;
            }
            catch (Exception)
            {

            }
        }
        public void SetVerticalLines(int row, int column, int startRow)
        {
            try
            {
                if (row == 0)
                    row++;
                Range range = Sheet.Range[Sheet.Cells[startRow, 1], Sheet.Cells[row, column]];
                range.Borders[XlBordersIndex.xlInsideVertical].Color = ConsoleColor.Black;
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region SetAlignment

        /// <summary>
        /// Set center align for text.
        /// </summary>
        /// <param name="cellI"></param>
        public void SetAlignment(int cellI)
        {
            try
            {
                if (cellI == 1)
                    cellI++;
                Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI - 1, 12]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
            catch (Exception) {  }
        }

        #endregion

        /// <summary>
        /// Set sheet content with formatting.
        /// </summary>
        public virtual void SetSheet()
        {
            if (rows != 0 && columns != 0)
            {
                try
                {
                    SetSheetContent();
                    SetAlignment(rows);
                    SetButtomLine(rows - 1);
                    SetVerticalLines(rows - 1);
                    Sheet.Columns.AutoFit();
                }
                catch (Exception) { }
            }
        }

        private void SetSheetContent()
        {
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
        }

        /// <summary>
        /// Get data to save in .xlsx file.
        /// </summary>
        /// <returns></returns>
        public virtual object[,] GetData()
        {
            data = new object[rows, columns];
            SetData();
            SetTitle();
            return data;
        }

        public abstract void SetDataSize();

        public abstract void SetData();

        public abstract void SetTitle(int rowIndex = 0);

        /// <summary>
        /// Title words.
        /// </summary>
        protected string[] title = {
            "1.Номер",
            "2.Дата",
            "3. Покупатель",
            "4.Оборудование",
            "5.Количество",
            "6.Стоимость",
            "7.Сумма",
            "8.Стоимость(м)",
            "9.Сумма(м)",
            "10.Разность",
            "11.Итог" };

    }
}
