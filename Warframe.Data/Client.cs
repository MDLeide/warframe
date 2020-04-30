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

        readonly Index _index;
        readonly HttpClient _client;

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
                indexData = await Decompress(await response.Content.ReadAsStreamAsync());
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

        static async Task<string> Decompress(Stream stream)
        {
            var output = new MemoryStream();

            var properties = new byte[5];
            stream.Read(properties, 0, 5);

            var outputLengthBytes = new byte[8];
            stream.Read(outputLengthBytes, 0, 8);
            var outputLength = BitConverter.ToInt64(outputLengthBytes, 0);

            var decoder = new SevenZip.Compression.LZMA.Decoder();
            decoder.SetDecoderProperties(properties);

            return await Task<string>.Factory.StartNew(() =>
            {
                decoder.Code(stream, output, stream.Length, outputLength, new Progress());

                return Encoding.ASCII.GetString(output.ToArray());
            });
        }
    }
}
