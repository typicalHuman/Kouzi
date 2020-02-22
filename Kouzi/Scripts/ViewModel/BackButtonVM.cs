using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class BackButtonVM: INotifyPropertyChanged
    {
        #region Commands

        #region BackToMainPageCommand

        private RelayCommand backToMainPageCommand;
        public RelayCommand BackToMainPageCommand
        {
            get
            {
                return backToMainPageCommand ?? (backToMainPageCommand = new RelayCommand(obj =>
                {
                    new NavigateVM().Navigate("Scripts/View/MainPage.xaml");
                }));
            }
        }

        #endregion

        #endregion

        #region Properties

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #endregion

    }
}
