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
                    EquipmentList.Add(new Equipment());
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

        private string date;
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

        #region Equipments

        public EquipmentCollection EquipmentList { get; set; } = new EquipmentCollection();

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


    }
}
