using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Warframe.Data
{
    class DataProvider<TObjectType>
    {
        readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        readonly Client _client;
        readonly int _refreshMinutes;
        readonly Func<Client, Task<string>> _getData;

        TObjectType _object;
        DateTimeOffset _refresh;


        protected DataProvider(Client client, int refreshMinutes, Func<Client, Task<string>> getData)
        {
            _client = client;
            _refreshMinutes = refreshMinutes;
            _getData = getData;
        }
        
        public virtual async Task<TObjectType> Get()
        {
            if (_refresh <= DateTimeOffset.Now)
            {
                _refresh = _refresh.AddMinutes(_refreshMinutes);
                _object = await Fetch();
            }
            else if (_object == null)
            {
                _object = await Fetch();
            }

            return _object;
        }

        protected virtual async Task<TObjectType> Fetch()
        {
            var data = await _getData.Invoke(_client);
            return JsonConvert.DeserializeObject<TObjectType>(data, _serializationSettings);
        }
    }
}