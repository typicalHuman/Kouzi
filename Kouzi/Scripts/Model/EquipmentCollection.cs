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
            Add(equipment);
        }
    }
}
