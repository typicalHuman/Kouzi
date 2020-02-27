using Kouzi.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class EquipmentsResultPageVM: INotifyPropertyChanged
    {

        #region Properties



        #region EquipmentsList

        public void SetEquipmentList()
        {

        }

        public ObservableCollection<Equipment> EquipmentsList { get; set; } = new ObservableCollection<Equipment>();

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
