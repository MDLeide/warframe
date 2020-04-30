using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Warframe.Data
{
    class DataProvider<TObjectType, TExportType>
        where TExportType: Export<TObjectType>
    {
        readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        Client _client;
        int _refreshMinutes;
        Func<Client, Task<string>> _getData;

        IEnumerable<TObjectType> _objects;
        DateTimeOffset _refresh;

        protected DataProvider(Client client, int refreshMinutes, Func<Client, Task<string>> getData)
        {
            _client = client;
            _refreshMinutes = refreshMinutes;
            _getData = getData;
        }
        
        public async Task<IEnumerable<TObjectType>> GetAll()
        {
            if (_refresh <= DateTimeOffset.Now)
            {
                _refresh = _refresh.AddMinutes(_refreshMinutes);
                _objects = await Fetch();
            }
            else if (_objects == null)
            {
                _objects = await Fetch();
            }

            return _objects;
        }

        async Task<IEnumerable<TObjectType>> Fetch()
        {
            var data = await _getData.Invoke(_client);
            var export = JsonConvert.DeserializeObject<TExportType>(data, _serializationSettings);
            return export.Contents;
        }
    }
}