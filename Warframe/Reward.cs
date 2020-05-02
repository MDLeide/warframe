using System;
using System.Collections.Generic;
using System.Text;

namespace Warframe
{
    public class Reward
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public float Chance { get; set; }
        public Rarity Rarity { get; set; }
    }
}
