using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Warframe.Market.WFMAPIMarketDataProvider
{
    public class WebScrapingMarketDataProvider : IMarketDataProvider
    {
        public WebScrapingMarketDataProvider(string baseUrl)
        {
            BaseUrl = baseUrl;
        }


        public string BaseUrl { get; set; }


        public async ItemMarketData GetMarketData(Item item)
        {
            var name = item.Name.Replace("-", "_").Replace(" ", "_").ToLower();
            var uri = $"{BaseUrl}/items/{name}/statistics";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Content = new StringContent();
            await client.SendAsync(request);
        }

        public ItemMarketData GetMarketData(Item item, DateTimeOffset inclusiveStart)
        {
            throw new NotImplementedException();
        }

        public ItemMarketData GetMarketData(Item item, DateTimeOffset inclusiveStart, DateTimeOffset inclusiveEnd)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items, DateTimeOffset inclusiveStart)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTimeOffset, ItemMarketData> GetMarketData(IEnumerable<Item> items, DateTimeOffset inclusiveStart, DateTimeOffset inclusiveEnd)
        {
            throw new NotImplementedException();
        }
    }
}
