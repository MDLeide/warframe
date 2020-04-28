using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Warframe.Market.Data
{
    public class WebScrapingMarketDataProvider : IMarketDataProvider
    {
        public WebScrapingMarketDataProvider(string baseUrl)
        {
            BaseUrl = baseUrl;
        }


        public string BaseUrl { get; set; }


        public async Task<ItemMarketData> GetMarketData(Item item)
        {
            var name = item.Name.Replace("-", "_").Replace(" ", "_").ToLower();
            var uri = $"{BaseUrl}/items/{name}/statistics";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Content = new StringContent(string.Empty);
            await client.SendAsync(request);

            throw new NotImplementedException();
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

        ItemMarketData IMarketDataProvider.GetMarketData(Item item)
        {
            throw new NotImplementedException();
        }
    }
}