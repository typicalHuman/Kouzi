using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Model
{
    public class Equipment : INotifyPropertyChanged, ICloneable
    {

        #region Properties

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

        private int diff;
        public int Diff
        {
            get => diff;
            set
            {
                diff = value;
                OnPropertyChanged("Diff");
            }
        }

        #endregion

        #region MySum

        private int mySum;
        public int MySum
        {
            get => mySum;
            set
            {
                mySum = value;
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

        private int sum;
        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
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

        private void SetValues()
        {
            int temp;
            if (int.TryParse(Count, out temp))
            {
                int _count = int.Parse(Count);
                Sum = _count * Cost;
                MySum = _count * MyCost;
                Diff = Sum - MySum;
            }
        }

        private string count = "0";
        public string Count
        {
            get => count;
            set
            {
                count = value;
                SetValues();
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

        #region Clone

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
