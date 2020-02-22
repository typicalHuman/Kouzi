using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Model
{
    public class Equipment : INotifyPropertyChanged
    {

        #region Properties

        #region EquipmentIndex

        private int equipmentIndex;
        public  int EquipmentIndex
        {
            get => App.MainPageVM.Buyers[int.Parse(BuyerIndex.Replace(".", "")) - 1].EquipmentList.IndexOf(this);
            set
            {
                equipmentIndex = value;
                OnPropertyChanged("EquipmentIndex");
            }
        }

        #endregion

        #region BuyerIndex

        private string buyerIndex;
        public string BuyerIndex
        {
            get => buyerIndex;
            set
            {
                buyerIndex = value;
                OnPropertyChanged("BuyerIndex");
            }
        }

        #endregion

        #region Difference

        public int Diff
        {
            get => Sum - MySum;
        }

        #endregion

        #region MySum

        public int MySum
        {
            get => Count * MyCost;
            set
            {
                OnPropertyChanged("MySum");
            }
        }

        #endregion

        #region MyCost

        private int myCost;
        public int MyCost
        {
            get => myCost;
            set
            {
                myCost = value;
                OnPropertyChanged("MyCost");
            }
        }

        #endregion

        #region Sum

        public int Sum
        {
            get => Cost * Count;
            set
            {
                OnPropertyChanged("Sum");
            }
        }

        #endregion

        #region Cost

        private int cost;
        public int Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }

        #endregion

        #region Count

        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        #endregion

        #region Name
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
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
