using System.Collections.Generic;

namespace Warframe
{
    public class Relic : Item
    {
        public HashSet<Item> CommonRewards { get; } = new HashSet<Item>();
        public HashSet<Item> UnCommonRewards { get; } = new HashSet<Item>();
        public HashSet<Item> RareRewards { get; } = new HashSet<Item>();
        public HashSet<Node> FoundIn { get; } = new HashSet<Node>();
    }
}