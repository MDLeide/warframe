using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Data
{
    class Client : IDisposable
    {
        class Progress : ICodeProgress
        {
            public void SetProgress(long inSize, long outSize)
            {
                
            }
        }

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
            string indexData;
            using (var response = await client.GetAsync(indexLocation))
            {
                using (var decodeStream = new MemoryStream())
                {
                    var decoder = new SevenZip.Compression.LZMA.Decoder();
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        var train = decoder.Train(contentStream);
                        decoder.Code(contentStream, decodeStream, contentStream.Length, 100000, new Progress());
                        using (var sr = new StreamReader(decodeStream))
                        {
                            indexData = sr.ReadToEnd();
                        }
                    }
                }
            }

            var index = Index.CreateFromString(baseAddress, indexData);
            return new Client(index, client);
        }

        public async Task<string> GetWeaponsData()
        {
            using (var response = await _client.GetAsync(_index.Weapons))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
