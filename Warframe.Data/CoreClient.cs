using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public class CoreClient : IDisposable
    {
        class Progress : ICodeProgress
        {
            public void SetProgress(long inSize, long outSize)
            {
                
            }
        }

        readonly Index _index;
        readonly HttpClient _client;

        CoreClient(Index index, HttpClient client)
        {
            _index = index;
            _client = client;
        }

        public static async Task<CoreClient> Create(string baseAddress, string indexLocation)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            string indexData;
            var responseTask = client.GetAsync(indexLocation);
            responseTask.Wait();
            var response = responseTask.Result;
            using (response)
            {
                var contentStreamTask = response.Content.ReadAsStreamAsync();
                contentStreamTask.Wait();
                var contentStream = contentStreamTask.Result;

                indexData = Decompress(contentStream);
            }

            var index = Index.CreateFromString(baseAddress, indexData);
            return new CoreClient(index, client);
        }

        public string GetData(CoreDataType dataType)
        {
            var responseTask = _client.GetAsync(_index.GetByDataType(dataType));
            responseTask.Wait();
            var response = responseTask.Result;
            using (response)
            {
                var stringTask = response.Content.ReadAsStringAsync();
                stringTask.Wait();
                return stringTask.Result;
            }
        }

        public void SaveData(CoreDataType dataType, string targetFileLocation)
        {
            var data = GetData(dataType);
            var dir = Path.GetDirectoryName(targetFileLocation);
            var dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
                dirInfo.Create();

            using (var fs = new FileStream(targetFileLocation, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(data);
                }
            }
        }

        public string GetWeaponsData()
        {
            return GetData(CoreDataType.Weapons);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        static string Decompress(Stream stream)
        {
            var output = new MemoryStream();

            var properties = new byte[5];
            stream.Read(properties, 0, 5);

            var outputLengthBytes = new byte[8];
            stream.Read(outputLengthBytes, 0, 8);
            var outputLength = BitConverter.ToInt64(outputLengthBytes, 0);

            var decoder = new SevenZip.Compression.LZMA.Decoder();
            decoder.SetDecoderProperties(properties);
            decoder.Code(stream, output, stream.Length, outputLength, new Progress());
            return Encoding.ASCII.GetString(output.ToArray());
        }
    }
}
