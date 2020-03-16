using System;
using System.Collections.Generic;

namespace Warframe.Market
{
    public class WebScrapingMarketDataProvider : IMarketDataProvider
    {
        public WebScrapingMarketDataProvider(string baseUrl)
        {
            BaseUrl = baseUrl;
        }


        public string BaseUrl { get; set; }


        public ItemMarketData GetMarketData(Item item)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }


    }
}