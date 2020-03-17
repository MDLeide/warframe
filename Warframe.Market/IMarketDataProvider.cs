using System;
using System.Collections.Generic;

namespace Warframe.Market
{
    public interface IMarketDataProvider
    {
        ItemMarketData GetMarketData(Item item);
        ItemMarketData GetMarketData(Item item, DateTimeOffset inclusiveStart);
        ItemMarketData GetMarketData(Item item, DateTimeOffset inclusiveStart, DateTimeOffset inclusiveEnd);

        Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items);
        Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items, DateTimeOffset inclusiveStart);
        Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items, DateTimeOffset inclusiveStart, DateTimeOffset inclusiveEnd);
    }
}