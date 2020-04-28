using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.UI.Screens.Baro
{
    class BaroHistoryViewModel : ViewModel
    {
        public BaroHistoryViewModel(IEnumerable<BaroOffering> offerings)
        {
            Offerings = new ObservableCollection<BaroOfferingViewModel>(
                offerings.Select(p => new BaroOfferingViewModel(p)));
        }

        ObservableCollection<BaroOfferingViewModel> _offerings;

        public ObservableCollection<BaroOfferingViewModel> Offerings
        {
            get => _offerings;
            set
            {
                if (_offerings == value)
                    return;

                _offerings = value;
                OnPropertyChanged(nameof(Offerings));
            }
        }

        BaroOfferingViewModel _selectedOffering;

        public BaroOfferingViewModel SelectedOffering
        {
            get { return _selectedOffering; }
            set
            {
                if (Equals(value, _selectedOffering)) return;
                _selectedOffering = value;
                OnPropertyChanged(nameof(SelectedOffering));
            }
        }
    }
}
