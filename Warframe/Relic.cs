using System.Collections.Generic;

namespace Warframe
{
    public class Relic : Item
    {
        public override string Name
        {
            get => RelicName;
            set => RelicName = value;
        }
        public string RelicName { get; set; }
        public RelicTier Tier { get; set; }
        public RelicState State { get; set; }

        public Reward[] Rewards { get; set; }
    }

    public enum RelicTier
    {
        Lith,
        Meso,
        Neo,
        Axi
    }

    public enum RelicState
    {
        Intact,
        Exceptional,
        Radiant
    }
}