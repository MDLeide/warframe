﻿namespace Warframe
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ItemType TypedType { get; set; }
        public string Description { get; set; }
    }

    public enum ItemType
    {
        Weapon,
        WeaponPart,
        Frame,
        FramePart,
        Relic,
        WeaponBlueprint,
        FrameBlueprint,
        WeaponPartBlueprint,
        FramePartBlueprint,
        Other
    }
}