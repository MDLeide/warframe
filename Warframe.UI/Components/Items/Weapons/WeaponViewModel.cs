using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.UI.Components.Items.Weapons
{
    class WeaponViewModel : ViewModel
    {
        public WeaponViewModel(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; }
    }
}
