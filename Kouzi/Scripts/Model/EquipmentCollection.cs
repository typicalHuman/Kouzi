using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Model
{
    public class EquipmentCollection: ObservableCollection<Equipment>
    {
        public void AddEquipment(Equipment equipment, string index)
        {
            equipment.BuyerIndex = index;
            int buyerIndex = int.Parse(equipment.BuyerIndex.Replace(".", "")) - 1;
            equipment.EquipmentIndex = App.MainPageVM.Buyers[buyerIndex].EquipmentList.Count - 1;
            Add(equipment);
        }

        public new void Remove(Equipment equipment)
        {
            int buyerIndex = int.Parse(equipment.BuyerIndex.Replace(".", "")) - 1;
            base.Remove(equipment);
            for (int i = 0; i < App.MainPageVM.Buyers[buyerIndex].EquipmentList.Count; i++)
                App.MainPageVM.Buyers[buyerIndex].EquipmentList[i].EquipmentIndex = i;
        }
    }
}
