using System;
using System.IO;
using Newtonsoft.Json;

namespace Warframe.Data
{
    public class JsonFileDataAdapter<T> : IDataAdapter<T>
        where T : IUniqueName
    {
        readonly string _fileLocation;

        public JsonFileDataAdapter(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public T GetData()
        {
            return JsonConvert.DeserializeObject<T>(
                File.ReadAllText(_fileLocation));
        }

        public T GetDataByUniqueName(string uniqueName)
        {
            throw new NotImplementedException();
        }

        public bool SupportsUniqueName => false;
    }
}