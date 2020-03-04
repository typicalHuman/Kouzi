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


        public void AddExcelEquipment(Equipment equipment, string index)
        {
            for (int i = 0; i < App.MainPageVM.EquipmentsInfo.Count; i++)
            {
                if (App.MainPageVM.EquipmentsInfo[i].Equals(equipment))
                    equipment.Index = i;
                if (App.MainPageVM.EquipmentsInfo[i].Name == "")
                    App.MainPageVM.EquipmentsInfo.RemoveAt(i);
            }
            if (equipment.Index == -1)
            {
                Equipment info = (Equipment)equipment.Clone();
                info.Count = "";
                App.MainPageVM.EquipmentsInfo.Add(info);
                equipment.Index = App.MainPageVM.EquipmentsInfo.Count - 1;
            }
            AddEquipment(equipment, index);
        }

        public new bool Contains(Equipment equip)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].Name == equip.Name)
                    return true;
            return false;
        }

        public void ConcatSame()
        {
            for(int i = 0; i < Count; i++)
            {
                for(int k = 0; k < Count; k++)
                {
                    if(i != k && this[i].Equals(this[k]))
                    {
                        this[i].Count = (int.Parse(this[i].Count) + int.Parse(this[k].Count)).ToString();
                        this.RemoveAt(k);
                        k--;
                    }
                }
            }
        }

        public void AddRange(EquipmentCollection coll)
        {
            for (int i = 0; i < coll.Count; i++)
                Add((Equipment)coll[i].Clone());
            ConcatSame();
        }
    }
}
