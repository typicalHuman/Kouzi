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
    public class EquipmentsResultPageVM: INotifyPropertyChanged
    {
        public EquipmentsResultPageVM()
        {
            SetEquipmentsList();
        }

        #region Commands

        #region SizeChangedCommand

        private const double factor = 0.14;

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

        #endregion

        #region Properties

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

        #region EquipmentsList

        public void SetEquipmentsList()
        {
            EquipmentsList = new EquipmentCollection();
            for(int i = 0; i < App.MainPageVM.Buyers.Count; i++)
            {
                for(int k = 0; k < App.MainPageVM.Buyers[i].EquipmentList.Count; k++)
                {
                    EquipmentsList.Add((Equipment)App.MainPageVM.Buyers[i].EquipmentList[k].Clone());
                }
            }
            EquipmentsList.ConcatSame();
        }

        public EquipmentCollection EquipmentsList { get; set; } = new EquipmentCollection();

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
