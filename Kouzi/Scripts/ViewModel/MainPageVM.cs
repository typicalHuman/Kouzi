using Kouzi.Scripts.Model;
using Kouzi.Scripts.Other;
using Kouzi.Scripts.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kouzi.Scripts.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged, ISave
    {


        #region Save
        public void Save()
        {
            new XML<string>().Serialize(BuyersNames, "BuyersNamesData.xml");
        }
        #endregion

        #region Constructor
        public MainPageVM()
        {
            BuyersNames = (ObservableCollection<string>)new XML<string>().Deserialize("BuyersNamesData.xml");
            BuyersNames = BuyersNames ?? new ObservableCollection<string>();
        }

        public void TestBuyers()
        {
            Buyer b1 = new Buyer();
            b1.Name = "first";
            b1.EquipmentList = new EquipmentCollection();
            Equipment e1 = new Equipment();
            Buyers.Add(b1);
            b1.EquipmentList.AddEquipment(e1, b1.Index);
            Buyer b2 = new Buyer() { Name = "second" };
            b2.EquipmentList = new EquipmentCollection();
            Buyers.Add(b2);
            b2.EquipmentList.AddEquipment(new Equipment(), b2.Index);
        }
        #endregion

        #region Commands

        #region SizeChangedCommand

        private const double factor = 0.14;// 1 column part(from 7)

        private RelayCommand sizeChangedCommand;
        public RelayCommand SizeChangedCommand
        {
            get
            {
                return sizeChangedCommand ?? (sizeChangedCommand = new RelayCommand(obj =>
                {
                    ColumnWidth = ((double)obj - SystemParameters.VerticalScrollBarWidth) * factor;
                }));
            }
        }

        #endregion

        #region RemoveBuyerNameCommand

        private RelayCommand removeBuyerNameCommand;
        public RelayCommand RemoveBuyerNameCommand
        {
            get
            {
                return removeBuyerNameCommand ?? (removeBuyerNameCommand = new RelayCommand(obj =>
                {
                    BuyersNames.Remove(obj.ToString());
                }));
            }
        }

        #endregion

        #region NavigateAddingBuyerCommand

        private RelayCommand addingBuyerPageCommand;
        public RelayCommand AddingBuyerPageCommand
        {
            get
            {
                return addingBuyerPageCommand ?? (addingBuyerPageCommand = new RelayCommand(obj =>
                {
                    new NavigateVM().Navigate(obj.ToString());
                }));
            }
        }

        #endregion

        #region RemoveBuyerCommand

        private RelayCommand removeBuyerCommand;
        public RelayCommand RemoveBuyerCommand
        {
            get
            {
                return removeBuyerCommand ?? (removeBuyerCommand = new RelayCommand(obj =>
                {
                    Buyers.RemoveAt(int.Parse(((string)obj).Replace(".", "")) - 1);
                }));
            }
        }


        #endregion

        #region AddBuyerCommand

        private RelayCommand addBuyerCommand;
        public RelayCommand AddBuyerCommand
        {
            get
            {
                return addBuyerCommand ?? (addBuyerCommand = new RelayCommand(obj =>
                {
                    Buyers.Add(new Buyer() { EquipmentList = new EquipmentCollection() { new Equipment() } });
                }));
            }
        }

        #endregion

        #region AddEquipmentInfoCommand

        private RelayCommand addEquipmentInfoCommand;
        public RelayCommand AddEquipmentInfoCommand
        {
            get
            {
                return addEquipmentInfoCommand ?? (addEquipmentInfoCommand = new RelayCommand(obj =>
                {
                    new NavigateVM().Navigate(obj.ToString());
                }));
            }
        }

        #endregion

        #region RemoveEquipmentInfoCommand

        private RelayCommand removeEquipmentInfoCommand;
        public RelayCommand RemoveEquipmentInfoCommand
        {
            get
            {
                return removeBuyerCommand ?? (removeBuyerCommand = new RelayCommand(obj =>
                {
                    EquipmentsInfo.Remove((Equipment)obj);
                }));
            }
        }

        #endregion

        #region SelectEquipmentInfoCommand

        private RelayCommand selectEquipmentInfoCommand;
        public RelayCommand SelectEquipmentInfoCommand
        {
            get
            {
                return selectEquipmentInfoCommand ?? (selectEquipmentInfoCommand = new RelayCommand(obj => 
                {
                    var a = obj;
                    Equipment equip = (Equipment)obj;
                    int index = int.Parse(equip.BuyerIndex.Replace(".", "")) - 1;
                    
                }));
            }
        }

        #endregion

        #endregion

        #region Properties

        #region EquipmentsInfo
        public ObservableCollection<Equipment> EquipmentsInfo { get; set; } = new ObservableCollection<Equipment>();
        #endregion

        #region EquipmentsInfoNames

        public ObservableCollection<string> EquipmentsInfoNames { get; set; } = new ObservableCollection<string>();

        #endregion

        #region Buyers
        public BuyerCollection Buyers { get; set; } = new BuyerCollection();
        #endregion

        #region ColumnWidth

        private double columnWidth = 135;
        public double ColumnWidth
        {
            get => columnWidth;
            set
            {
                columnWidth = value;
                OnPropertyChanged("ColumnWidth");
            }
        }

        #endregion

        #region BuyersNames
        public ObservableCollection<string> BuyersNames { get; set; } = new ObservableCollection<string>();
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
