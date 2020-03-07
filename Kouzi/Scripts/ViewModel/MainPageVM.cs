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
using System.Xml.Serialization;

namespace Kouzi.Scripts.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged, ISave
    {

        #region Save
        public void Save()
        {
            new XML<string>().Serialize(BuyersNames, "BuyersNamesData.xml");
            new XML<Equipment>().Serialize(EquipmentsInfo, "EquipmentsInfoData.xml");
        }
        #endregion

        #region Constructor
        public MainPageVM()
        {
            //initalizing from xml documents
            BuyersNames = (ObservableCollection<string>)new XML<string>().Deserialize("BuyersNamesData.xml") ?? 
                new ObservableCollection<string>();
            EquipmentsInfo = (ObservableCollection<Equipment>)new XML<Equipment>().Deserialize("EquipmentsInfoData.xml") ??
                new ObservableCollection<Equipment>();
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
                return removeEquipmentInfoCommand ?? (removeEquipmentInfoCommand = new RelayCommand(obj =>
                {
                    Equipment equip = (Equipment)obj;
                    EquipmentsInfo.Remove(equip);
                    for(int i = 0; i < Buyers.Count; i++)
                    {
                        for(int k = 0; k < Buyers[i].EquipmentList.Count; k++)
                        {
                            Equipment e = Buyers[i].EquipmentList[k];
                            if (e != null)
                            {
                                if (equip.Equals(e))
                                {
                                    Buyers[i].EquipmentList.Remove(e);
                                    Buyers[i].EquipmentList.AddEquipment(new Equipment(), Buyers[i].Index);
                                }
                            }
                        }
                    }
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
                    SelectEquipmentInfo(((FindCommandParameters)obj).Parameter1, ((FindCommandParameters)obj).Parameter2,
                        ((FindCommandParameters)obj).Parameter3);
                }));
            }
        }

        public void SelectEquipmentInfo(object Parameter1, object Parameter2, object Parameter3)
        {
            Equipment equip = (Equipment)Parameter1;
            int equipmentIndex = (int)Parameter2;
            int buyerIndex = (int)Parameter3;
            if (equipmentIndex != -1 && equip != null)
            {
                Buyers[buyerIndex].EquipmentList.RemoveAt(equipmentIndex);
                Buyers[buyerIndex].EquipmentList.InsertEquipment(equipmentIndex,(Equipment)equip.Clone(), Buyers[buyerIndex].Index);
                Buyers[buyerIndex].EquipmentList[equipmentIndex].Index = EquipmentsInfo.IndexOf(equip);
                if (EquipmentsInfo.IndexOf(equip) != Buyers[buyerIndex].EquipmentList[equipmentIndex].Index)
                    Buyers[buyerIndex].EquipmentList[equipmentIndex].Index = EquipmentsInfo.IndexOf(equip);
            }
        }

        #endregion

        #endregion

        #region Properties

        #region EquipmentsInfo
        private ObservableCollection<Equipment> equipmentsInfo = new ObservableCollection<Equipment>();
        public ObservableCollection<Equipment> EquipmentsInfo
        {
            get => equipmentsInfo;
            set
            {
                equipmentsInfo = value;
                OnPropertyChanged("EquipmentsInfo");
            }
        }
        #endregion

        #region Buyers
        private BuyerCollection buyers=  new BuyerCollection();
        public BuyerCollection Buyers
        {
            get => buyers;
            set
            {
                buyers = value;
                OnPropertyChanged("Buyers");
            }
        }
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

        #region AddButtonVisibility

        private Visibility addButtonVisibility;
        public Visibility AddButtonVisibility
        {
            get => addButtonVisibility;
            set
            {
                addButtonVisibility = value;
                OnPropertyChanged("AddButtonVisibility");
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
