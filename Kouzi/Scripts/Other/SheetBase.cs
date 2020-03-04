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

        public SheetBase()
        {
            SetDataSize();
        }

        public abstract Worksheet Sheet { get; set; }

        protected int rows { get; set; }

        protected int columns { get; set; }

        #region SetBorder

        public void SetTitleLine()
        {
            Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[1, columns]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetButtomLine(int row)
        {
            Range range = Sheet.Range[Sheet.Cells[row, 1], Sheet.Cells[row, columns]];
            range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            range.Borders[XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;
        }

        public void SetVerticalLines(int row)
        {
            Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[row, 12]];
            range.Borders[XlBordersIndex.xlInsideVertical].Color = ConsoleColor.Black;
        }

        #endregion

        #region SetAlignment

        public void SetAlignment(int cellI)
        {
            Range range = Sheet.Range[Sheet.Cells[1, 1], Sheet.Cells[cellI - 1, 12]];
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }

        #endregion

        public abstract void SetSheet();

        public abstract object[,] GetData();

        public abstract void SetDataSize();

        public abstract void SetData(ref object[,] data);

        public abstract void SetTitle(ref object[,] data);

        protected string[] title = {"1.Номер", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

    }
}
