using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe.UI.Components.Items.Weapons;

namespace Warframe.UI.Screens
{
    class WeaponsViewModel : ViewModel
    {
        public WeaponsViewModel(IEnumerable<Weapon> weapons)
        {
            Weapons = new ObservableCollection<WeaponViewModel>(weapons.Select(p => new WeaponViewModel(p)));
        }

        public ObservableCollection<WeaponViewModel> Weapons { get; }
    }
}

