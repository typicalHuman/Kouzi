using Kouzi.Scripts.Other;
using Microsoft.Win32;

namespace Kouzi.Scripts.ViewModel
{
    public class FileVM
    {

        #region Commands

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
