using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kouzi.Scripts.Controls;
using Kouzi.Scripts.Model;
using Kouzi.Scripts.ViewModel;
using Microsoft.Office.Interop.Excel;

namespace Kouzi.Scripts.Other
{
    public class Excel
    {
        private Application ExcelApp { get; set; } = new Application();

        private static Workbook Book { get; set; }

        public MainSheet mainSheet { get; set; } = new MainSheet();

        #region Constructor

        public Excel()
        {
            Book = ExcelApp.Workbooks.Add();
            mainSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(1);
        }

        #endregion

        #region File Manipulation
        public void SaveAs(string directoryPath)
        {
            try
            {
                FileVM.filePath = directoryPath;
                Book.SaveAs(directoryPath);
                Book.Close();
                Marshal.ReleaseComObject(mainSheet.Sheet);
                SaveNotificationWindow wind = new SaveNotificationWindow();
                wind.ShowDialog();
            }
            catch(Exception)
            {  }
        }

        public void Open(string filePath)
        {
            Book = ExcelApp.Workbooks.Open(filePath);
            mainSheet.Sheet = Book.Sheets[1];
            mainSheet.ReadData();
            FileVM.filePath = filePath;
            Book.Close();
            Marshal.ReleaseComObject(mainSheet.Sheet);
        }

        public void Save()
        {
            if(FileVM.filePath != "")
            {
                File.Delete(FileVM.filePath);
                Book.SaveAs(FileVM.filePath, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Book.Close();
                Marshal.ReleaseComObject(mainSheet.Sheet);
            }
        }
        #endregion

        #region WriteData

        #region Write

        public void Write()
        {
            mainSheet.SetSheet();
        }


        #region SetmainSheet

        private void SetmainSheet()
        {
            
        }

        #endregion

        #endregion

        #region SetData


        #region SetEquipmentResultData

        private void SetEquipmentResultData(ref object[,] data)
        {
            //data = new object[App.EquipmentsResultPageVM.EquipmentsList.Count + 1, equipmentColumns];
            for (int i = 1; i < data.GetLength(1); i++)
            {
                Equipment equip = App.EquipmentsResultPageVM.EquipmentsList[i - 1];
                data[i, 0] = equip.Name;
                data[i, 1] = equip.Count;
                data[i, 2] = equip.Cost;
                data[i, 3] = equip.Sum;
                data[i, 4] = equip.MyCost;
                data[i, 5] = equip.MySum;
                data[i, 6] = equip.Diff;
            }
        }

        #endregion

        #endregion




        #region SetTitle

        string[] title = {"1.Номер", "2.Дата", "3. Покупатель", "4.Оборудование", "5.Количество", "6.Стоимость", "7.Сумма", "8.Стоимость(м)", "9.Сумма(м)",
        "10.Разность", "11.Итог"};

        public void SetTitle(ref object [,] data)
        {
            
        }

        #endregion

        #region GetData



        private object[,] GetEquipmentData()
        {
            object[,] data = null;
            SetEquipmentResultData(ref data);
            return data;
        }

        #endregion

        #endregion

        
    }
}
