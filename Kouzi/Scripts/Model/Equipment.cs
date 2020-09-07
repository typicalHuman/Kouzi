using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kouzi.Scripts.Model
{
    [Serializable]
    public class Equipment : INotifyPropertyChanged, ICloneable, IEquatable<Equipment>
    {
     

        #region Properties

        #region ComboBoxIndex

        private int index = -1;
        public int Index
        {
            get => index;
            set
            {
                if (index != value)
                {
                    index = value;
                    OnPropertyChanged("Index");
                }
            }
        }

        #endregion

        #region Date

        private string date;
        [XmlElement]
        public string Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        #endregion

        #region BuyerIndex

        private string buyerIndex;
        [XmlElement]
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
        [XmlElement]
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
        [XmlElement]
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
        [XmlElement]
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
        [XmlElement]
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
        [XmlElement]
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
                if (App.MainPageVM != null && BuyerIndex != null)
                {
                    int _buyerIndex = int.Parse(BuyerIndex.Replace(".", "")) - 1;
                    if(_buyerIndex != -1)
                       App.MainPageVM.Buyers[_buyerIndex].UpdateBenefit();//just to upd
                }
            }
        }

        private string count = "0";
        [XmlElement]
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
        private string name = "";
        [XmlElement]
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

        #region Equals

        public bool Equals(Equipment equip)
        {
            return equip.Name == Name && equip.Cost == Cost && equip.MyCost == MyCost;
        }

        #endregion
    }
}
