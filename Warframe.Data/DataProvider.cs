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

        readonly CoreClient _client;
        readonly int _refreshMinutes;
        readonly Func<CoreClient, string> _getData;

        TObjectType _object;
        DateTimeOffset _refresh;


        protected DataProvider(CoreClient client, int refreshMinutes, Func<CoreClient, string> getData)
        {
            _client = client;
            _refreshMinutes = refreshMinutes;
            _getData = getData;
        }
        
        public virtual TObjectType Get()
        {
            if (_refresh <= DateTimeOffset.Now)
            {
                _refresh = _refresh.AddMinutes(_refreshMinutes);
                _object = Fetch();
            }
            else if (_object == null)
            {
                _object = Fetch();
            }

            return _object;
        }

        protected virtual TObjectType Fetch()
        {
            var data = _getData.Invoke(_client);
            return JsonConvert.DeserializeObject<TObjectType>(data, _serializationSettings);
        }
    }
}