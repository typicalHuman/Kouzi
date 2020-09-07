using Kouzi.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Model
{
    public class Buyer : INotifyPropertyChanged, ICloneable
    {
        #region Methods

        private int GetBenefit()
        {
            int amount = 0;
            foreach (Equipment eq in EquipmentList)
                amount += eq.Diff;
            return amount;
        }

        public void UpdateBenefit()
        {
            Benefit = 0;
        }

        #endregion

        #region Command

        #region RemoveEquipmentCommand

        private RelayCommand removeEquipmentCommand;
        public RelayCommand RemoveEquipmentCommand
        {
            get
            {
                return removeEquipmentCommand ?? (removeEquipmentCommand = new RelayCommand(obj =>
                {
                    EquipmentList.Remove((Equipment)obj);
                    UpdateBenefit();
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
                    EquipmentList.AddEquipment(new Equipment(), this);
                    UpdateBenefit();
                }));
            }
        }

        #endregion


        #endregion

        #region Properties

        #region Index

        private string index;
        public string Index
        {
            get => $"{(App.MainPageVM.Buyers.IndexOf(this) + 1).ToString()}. ";
            set
            {
                index = value;
                OnPropertyChanged("Index");
            }
        }

        #endregion

        #region Date

        private void UpdateEquipmentsDate(string date)
        {
            for(int i = 0; i < EquipmentList.Count; i++)
            {
                EquipmentList[i].Date = date;
            }
        }

        private string date;
        public string Date
        {
            get => date;
            set
            {
                date = value;
                UpdateEquipmentsDate(date);
                OnPropertyChanged("Date");
            }
        }

        #endregion

        #region Name

        private string name = "";
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

        #region Equipments

        private EquipmentCollection equipmentList = new EquipmentCollection();
        public EquipmentCollection EquipmentList
        {
            get => equipmentList;
            set
            {
                equipmentList = value;
                OnPropertyChanged("EquipmentList");
            }
        }

        #endregion

        #region Credit

        private string credit;
        public string Credit
        {
            get => credit;
            set
            {
                credit = value;
                OnPropertyChanged("Credit");
            }
        }

        #endregion

        #region Debit

        private string debit;
        public string Debit
        {
            get => debit;
            set
            {
                debit = value;
                OnPropertyChanged("Debit");
            }
        }

        #endregion

        #region SelectedIndex

        private int selectedIndex;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        #endregion

        #region Benefit

        private int benefit;
        public int Benefit
        {
            get => GetBenefit();
            set
            {
                benefit = value;
                OnPropertyChanged("Benefit");
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
            Buyer cloned = new Buyer() { Name = Name, Index = Index, Debit = Debit, Credit = Credit, Date = Date, SelectedIndex = SelectedIndex };
            for (int i = 0; i < EquipmentList.Count; i++)
                cloned.EquipmentList.Add((Equipment)EquipmentList[i].Clone());
            return cloned;
        }

        #endregion


    }
}
