using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public class Excel: IDisposable
    {
        private Application ExcelApp { get; set; } = new Application();

        private Workbook Book { get; set; }

        private MainSheet mainSheet { get; set; } = new MainSheet();

        private EquipmentSheet equipmentSheet { get; set; } = new EquipmentSheet();

        private BuyerSheet buyerSheet { get; set; } = new BuyerSheet();

        private DateSheet dateSheet { get; set; } = new DateSheet();

        #region Destructor


        ~Excel()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private GCHandle rcwHandle;

        protected virtual void Dispose(bool disposing)
        {
            if (this.rcwHandle.IsAllocated)
            {
                this.rcwHandle.Free();
            }
        }
        #endregion

        #region Constructor

        public Excel()
        {
            Book = ExcelApp.Workbooks.Add();
            Book.Worksheets.Add(Count: 3);
            mainSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(1);
            equipmentSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(2);
            buyerSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(3);
            dateSheet.Sheet = (Worksheet)Book.Worksheets.get_Item(4);
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
                    Book.Close(false, false, false);
                    ExcelApp.Quit();
                    Clear();
                    GC.Collect();
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
            Book.Close(true);
            ExcelApp.Quit();
            Clear();
            GC.Collect();
            //добавить окно, которое спрашивало бы "имеются несохраненные данные, сохранить?"
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
                Book.Close(true);
                ExcelApp.Quit();
                Clear();
                GC.Collect();
                App.SaveNotificationWindowVM.IsSaved = true;
            }
        }
        #endregion

        #endregion

        #region Write

        public void Write()
        {
            Set();
        }

        private void Set()
        {
            dateSheet.SetSheet();
            mainSheet.SetSheet();
            equipmentSheet.SetSheet();
            buyerSheet.SetSheet();
            App.SaveNotificationWindowVM.IsSaved = true;
        }

        #endregion

        #region Clear

        private void Clear()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (new Hashtable().ContainsKey(ExcelProcess.Id) == false)
                    ExcelProcess.Kill();
            }

            AllProcesses = null;
        }

        #endregion

        #region SaveNotification



        public void ShowNotificationDialog()
        {
            SaveNotificationWindow wind = new SaveNotificationWindow();
            wind.Show();
        }
        #endregion


    }
}

