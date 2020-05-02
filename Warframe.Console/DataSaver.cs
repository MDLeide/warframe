using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe;
using Warframe.Data;

namespace Warframe.Console
{
    class DataSaver
    {
        readonly CoreClient _client;
        readonly string _rootDirectory;

        public DataSaver(string rootDirectory, string baseAddress, string indexLocation)
        {
            _client = CoreClient.Create(baseAddress, indexLocation).Result;
            _rootDirectory = rootDirectory;
        }

        public void SaveData(CoreDataType dataType)
        {
            _client.SaveData(dataType, Path.Combine(_rootDirectory, dataType.ToString() + ".json"));
        }
    }
}
