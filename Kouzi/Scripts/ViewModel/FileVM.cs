using Kouzi.Scripts.Other;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Kouzi.Scripts.ViewModel
{
    public class FileVM
    {

        public static string filePath { get; set; } = "";

        public static bool isChanged { get; set; } = true;

        #region Commands

        #region SaveAsCommand
        private RelayCommand saveAsCommand;
        public RelayCommand SaveAsCommand
        {
            get
            {
                return saveAsCommand ?? (saveAsCommand = new RelayCommand(obj =>
                {
                    SaveAs();
                }));
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                Excel ex = new Excel();
                ex.ShowNotificationDialog();
                ex.Write();
                ex.SaveAs(saveFileDialog.FileName);
                isChanged = false;
            }
        }
        #endregion

        #region SaveCommand

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj =>
                {
                    if (filePath != "")
                    {
                        Excel ex = new Excel();
                        ex.Write();
                        ex.Save();
                        isChanged = false;
                    }
                }));
            }
        }

        #endregion

        #region OpenCommand

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ?? (openCommand = new RelayCommand(obj =>
                {
                    OpenFileDialog saveFileDialog = new OpenFileDialog();
                    saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        new Excel().Open(saveFileDialog.FileName);
                        isChanged = false;
                    }
                }));
            }
        }
        #endregion

        #region CreateNew

        private RelayCommand createNew;
        public RelayCommand CreateNew
        {
            get
            {
                return createNew ?? (createNew = new RelayCommand(obj =>
                {
                    if (!isChanged)
                    {
                        filePath = "";
                        App.MainPageVM.Buyers = new Model.BuyerCollection();
                    }
                    else
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Сохранить перед созданием?", "", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            SaveAs();
                            filePath = "";
                            App.MainPageVM.Buyers = new Model.BuyerCollection();
                        }
                    }
                }));
            }
        }

        #endregion

        #endregion
    }
}
