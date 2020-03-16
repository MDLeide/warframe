using System;
using System.Collections.Generic;

namespace Warframe.Market
{
    public class ItemMarketData
    {
        public Item Item { get; set; }

        public Dictionary<DateTimeOffset, Item> Data { get; set; } =
            new Dictionary<DateTimeOffset, Item>();
    }
}
