using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Kouzi.Scripts.Other
{
    public class Excel
    {
        private Application ExcelApp { get; set; } = new Application();

        private Workbook Book { get; set; } = new Workbook();

        private Worksheet Sheet { get; set; } = new Worksheet();

        private string directoryPath { get; set; }

        #region Constructor

        public Excel(string directoryPath)
        {
            Book = ExcelApp.Workbooks.Add();
            Sheet = (Worksheet)Book.Worksheets.get_Item(1);
            this.directoryPath = directoryPath;
            SetTitle();
            Save();
        }

        #endregion

        #region File Manipulation
        public void Save()
        {
            ExcelApp.Application.ActiveWorkbook.SaveAs(@"C:\Users\typical\Desktop\doc.xlsx", Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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
            Save();
            Book.Close();
        }

        #endregion

        #region SetTitle

        string[] title = {"1.Название", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

        public void SetTitle()
        {
            for(int i = 0; i < title.Length; i++)
            {
                Sheet.Cells[1, i + 1] = title[i];
            }
        }

        #endregion

        #endregion

    }
}
