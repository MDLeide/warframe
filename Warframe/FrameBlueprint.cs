using System.Collections.Generic;

namespace Warframe
{
    public class FrameBlueprint : Item
    {
        public Frame Frame { get; set; }
        public Dictionary<FramePart, int> Parts { get; } = new Dictionary<FramePart, int>();
        public Dictionary<Item, int> Materials { get; } = new Dictionary<Item, int>();
    }
}