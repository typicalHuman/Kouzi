using Kouzi.Scripts.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class AddingBuyerPageVM : INotifyPropertyChanged
    {

        #region Properties

        #region Commands
        #region AddBuyerCommand

        private RelayCommand addBuyerCommand;
        public RelayCommand AddBuyerCommand
        {
            get
            {
                return addBuyerCommand ?? (addBuyerCommand = new RelayCommand(obj =>
                {
                    if (!string.IsNullOrWhiteSpace(BuyerName))
                        App.MainPageVM.BuyersNames.Insert(0, BuyerName);
                    BuyerName = "";
                    new NavigateVM().Navigate("Scripts/View/MainPage.xaml");
                }));
            }
        }

        #endregion

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


        #region BuyerName
        private string buyerName;
        public string BuyerName
        {
            get => buyerName;
            set
            {
                buyerName = value;
                OnPropertyChanged("BuyerName");
            }
        }

        #endregion



        #region OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion;

        #endregion

    }
}
