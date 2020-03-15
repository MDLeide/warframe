using System.Collections.Generic;

namespace Warframe
{
    public class WeaponBlueprint : Item
    {
        public Weapon Weapon { get; set; }
        public Dictionary<WeaponPart, int> Parts { get; } = new Dictionary<WeaponPart, int>();
        public Dictionary<Item, int> Materials { get; } = new Dictionary<Item, int>();
    }
}