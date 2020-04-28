using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.UI.Screens.Baro
{
    class BaroOfferingItemViewModel : ViewModel
    {
        public BaroOfferingItemViewModel(Item item, int ducats)
        {
            Item = item;
            Cost = ducats;
        }

        public Item Item
        {
            get => _item;
            set
            {
                if (Equals(value, _item)) return;
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        Item _item;

        public int Cost
        {
            get => _cost;
            set
            {
                if (Equals(value, _cost)) return;
                _cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        int _cost;
    }
}
