using Kouzi.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kouzi.Scripts.ViewModel
{
    public class BuyersResultPageVM: INotifyPropertyChanged
    {

        #region Properties

        #region BuyersList

        public void SetBuyersList()
        {
            BuyersList = new BuyerCollection();
            for(int i = 0; i < App.MainPageVM.Buyers.Count; i++)
            {
                BuyersList.Add((Buyer)App.MainPageVM.Buyers[i].Clone());
            }
            BuyersList.ConcatSame();
        }

        public BuyerCollection BuyersList { get; set; } = new BuyerCollection();

        #endregion

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
