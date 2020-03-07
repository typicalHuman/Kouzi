using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class SaveNotificationWindowVM: INotifyPropertyChanged
    {

        #region Properties

        private bool isSaved = false;
        public bool IsSaved
        {
            get => isSaved;
            set
            {
                isSaved = value;
                OnPropertyChanged("IsSaved");
            }
        }

        #endregion

        #region Commands
        #region CloseCommand
        public Action CloseAction { get; set; }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get => closeCommand ?? (closeCommand = new RelayCommand(obj =>
            {
                CloseAction();
            }));

        }
        #endregion
        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        #endregion

    }
}
