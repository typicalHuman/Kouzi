using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Other
{
    public abstract class SheetBase
    {
        public Worksheet Sheet { get; set; }

        protected int rows { get; set; }

        protected int columns { get; set; }

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
            catch (Exception)
            {

            }
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

        public void SetAlignment(int cellI)
        {
            try
            {
                if (cellI == 1)
                    cellI++;
                Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI - 1, 12]];
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
            catch (Exception)
            {

            }
        }

        #endregion

        public virtual void SetSheet()
        {
            if (rows != 0 && columns != 0)
            {
                try
                {

                    Range start = (Range)Sheet.Cells[1, 1];
                    Range end = (Range)Sheet.Cells[rows, columns];
                    Sheet.Range[start, end].Value2 = GetData();
                    SetAlignment(rows);
                    SetButtomLine(rows - 1);
                    SetVerticalLines(rows - 1);
                    Sheet.Columns.AutoFit();
                }
                catch (Exception) { }
            }
        }

        public virtual object[,] GetData()
        {
            object[,] data = new object[rows, columns];
            SetData(ref data);
            SetTitle(ref data);
            return data;
        }

        public abstract void SetDataSize();

        public abstract void SetData(ref object[,] data);

        public abstract void SetTitle(ref object[,] data, int rowIndex = 0);

        protected string[] title = {"1.Номер", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

    }
}
