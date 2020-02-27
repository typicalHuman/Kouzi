using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.Model
{
    public class BuyerCollection: ObservableCollection<Buyer>
    {
        public new void Add(Buyer buyer)
        {
            if (!App.MainPageVM.BuyersNames.Contains(buyer?.Name))
                App.MainPageVM.BuyersNames.Add(buyer.Name);
            base.Add(buyer);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            for (int i = index; i < Count; i++)
                this[i].Index = $"{i + 1}.";
        }

        public void ConcatSame()
        {
            for(int i = 0; i < Count; i++)
            {
                for(int k = 0; k < Count; k++)
                {
                    if(i != k && this[i].Name == this[k].Name)
                    {
                        this[i].EquipmentList.AddRange(this[k].EquipmentList);
                        this.RemoveAt(k);
                        k--;
                    }
                }
            }
        }
    }
}
