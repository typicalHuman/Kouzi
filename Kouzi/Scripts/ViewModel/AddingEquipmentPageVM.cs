using Kouzi.Scripts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kouzi.Scripts.ViewModel
{
    public class AddingEquipmentPageVM : INotifyPropertyChanged
    {
        #region IsFilled

        private bool IsFilled()
        {
            int temp = 0;
            if(int.TryParse(MyCost, out temp) && int.TryParse(Cost, out temp))
               return int.Parse(MyCost) != 0 && int.Parse(Cost) != 0 && !string.IsNullOrEmpty(Name);
            return false;
        }

        #endregion

        #region Commands

        #region TextChanged

        private RelayCommand textChanged;
        public RelayCommand TextChanged
        {
            get
            {
                return textChanged ?? (textChanged = new RelayCommand(obj =>
                {
                    ErrorVisibility = ErrorVisibility;
                }));
            }
        }

        #endregion

        #region AddEquipmentCommand

        private RelayCommand addEquipmentCommand;
        public RelayCommand AddEquipmentCommand
        {
            get
            {
                return addEquipmentCommand ?? (addEquipmentCommand = new RelayCommand(obj =>
                {
                    MyCost.Replace(" ", "");
                    Cost.Replace(" ", "");
                    if (IsFilled())
                    {
                        Equipment resultEquip = new Equipment() { Cost = int.Parse(Cost), MyCost = int.Parse(MyCost), Name = this.Name };
                        App.MainPageVM.EquipmentsInfo.Add(resultEquip);
                        App.MainPageVM.EquipmentsInfoNames.Add(resultEquip.Name);
                        new NavigateVM().Navigate("Scripts/View/MainPage.xaml");
                    }
                }));
            }
        }

        #endregion

        #endregion

        #region Properties

        #region ErrorVisibility

        private Visibility errorVisibility;
        public Visibility ErrorVisibility
        {
            get
            {
                if (IsFilled())
                    return Visibility.Hidden;
                return Visibility.Visible;
            }
            set
            {
                errorVisibility = value;
                OnPropertyChanged("ErrorVisibility");
            }
        }

        #endregion

        #region MyCost

        private string myCost = "0";
        public string MyCost
        {
            get => myCost;
            set
            {
                myCost = value;
                OnPropertyChanged("MyCost");
            }
        }

        #endregion

        #region Cost

        private string cost = "0";
        public string Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
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
