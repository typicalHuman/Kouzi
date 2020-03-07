using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
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

        private MainSheet mainSheet { get; set; } = new MainSheet();

        private EquipmentSheet equipmentSheet { get; set; } = new EquipmentSheet();

        private BuyerSheet buyerSheet { get; set; } = new BuyerSheet();

        #region Constructor

        public Excel()
        {
            Book = ExcelApp.Workbooks.Add();
            Book.Worksheets.Add(Count: 2);
            mainSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(1);
            equipmentSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(2);
            buyerSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(3);
        }

        #endregion

        #region File Manipulation

        #region SaveAs
        public void SaveAs(string directoryPath)
        {
            try
            {
                if(!directoryPath.Contains(".xlsx"))
                {
                    FileVM.filePath = directoryPath;
                    Book.SaveAs(directoryPath);
                    Book.Close();
                    Clear(mainSheet.Sheet, equipmentSheet.Sheet, buyerSheet.Sheet);
                    App.SaveNotificationWindowVM.IsSaved = true;
                }
                else
                {
                    FileVM.filePath = directoryPath;
                    Save();
                }
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Open
        public void Open(string filePath)
        {
            Book = ExcelApp.Workbooks.Open(filePath);
            mainSheet.Sheet = Book.Sheets[1];
            mainSheet.ReadData();
            FileVM.filePath = filePath;
            Book.Close();
            Clear(mainSheet.Sheet, equipmentSheet.Sheet, buyerSheet.Sheet);
        }
        #endregion

        #region Save
        public void Save()
        {
            if (FileVM.filePath != "")
            {
                File.Delete(FileVM.filePath);
                Book.SaveAs(FileVM.filePath, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
            false, false, XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Book.Close();
                Clear(mainSheet.Sheet, equipmentSheet.Sheet, buyerSheet.Sheet);
                App.SaveNotificationWindowVM.IsSaved = true;
            }
        }
        #endregion

        #endregion

        #region Write

        public void Write()
        {
            Set();
            ShowNotificationDialog();
        }

        private async void Set()
        {
            await Task.Run(() =>
            {
                mainSheet.SetSheet();
                equipmentSheet.SetSheet();
                buyerSheet.SetSheet();
                App.SaveNotificationWindowVM.IsSaved = true;
            });
        }

        #endregion

        #region Clear

        private void Clear(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
                Marshal.ReleaseComObject(values[i]);
        }

        #endregion

        #region SaveNotification



        public void ShowNotificationDialog()
        {
            SaveNotificationWindow wind = new SaveNotificationWindow();
            wind.ShowDialog();
        }
        #endregion


    }
}

