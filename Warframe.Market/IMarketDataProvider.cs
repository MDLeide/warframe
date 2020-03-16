using System;
using System.Collections.Generic;

namespace Warframe.Market
{
    public interface IMarketDataProvider
    {
        ItemMarketData GetMarketData(Item item);
        Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items);
    }
}