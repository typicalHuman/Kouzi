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
