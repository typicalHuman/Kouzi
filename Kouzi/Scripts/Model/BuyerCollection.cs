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
    }
}
