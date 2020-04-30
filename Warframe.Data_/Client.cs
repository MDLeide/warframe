using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Data
{
    class Client : IDisposable
    {
        Index _index;
        HttpClient _client;

        Client(Index index, HttpClient client)
        {
            _index = index;
            _client = client;
        }

        public static async Task<Client> Create(string baseAddress, string indexLocation)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            var response = await client.GetAsync(indexLocation);
            var indexData = await response.Content.ReadAsStringAsync();
            var index = Index.CreateFromString(baseAddress, indexData);
            return new Client(index, client);
        }

        public async Task<string> GetWeaponsData()
        {
            var response = await _client.GetAsync(_index.Weapons);
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
