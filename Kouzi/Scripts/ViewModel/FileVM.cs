using Kouzi.Scripts.Other;
using Microsoft.Win32;

namespace Kouzi.Scripts.ViewModel
{
    public class FileVM
    {

        #region Commands

        #region SaveAsCommand
        private RelayCommand saveAsCommand;
        public RelayCommand SaveAsCommand
        {
            get
            {
                return saveAsCommand ?? (saveAsCommand = new RelayCommand(obj =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        new Excel().Write();
                        Excel.SaveAs(saveFileDialog.FileName);
                    }
                }));
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
                    new Excel().Write();
                    Excel.Save();
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
                    }
                }));
            }
        }
        #endregion

        #endregion
    }
}
