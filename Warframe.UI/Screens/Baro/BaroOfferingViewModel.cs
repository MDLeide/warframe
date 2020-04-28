using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.UI.Screens.Baro
{
    class BaroOfferingViewModel : ViewModel
    {
        BaroOffering _offering;

        public BaroOfferingViewModel(BaroOffering offering)
        {
            Items = new ObservableCollection<BaroOfferingItemViewModel>(
                offering.ItemsToDucatCostOnOffer.Select(p => new BaroOfferingItemViewModel(p.Key, p.Value)));
        }

        public BaroOffering Offering => _offering;

        public DateTimeOffset StartTime
        {
            get { return _offering.StartTime; }
            set { _offering.StartTime = value; }
        }

        public DateTimeOffset EndTime
        {
            get { return _offering.EndTime; }
            set { _offering.EndTime = value; }
        }

        public ObservableCollection<BaroOfferingItemViewModel> Items
        {
            get => _items;
            set
            {
                if (Equals(value, _items)) return;
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        ObservableCollection<BaroOfferingItemViewModel> _items;

    }
}
