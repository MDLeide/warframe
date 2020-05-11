using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Warframe.Util;

namespace Warframe.Data.DataAccess
{
    class CallHelper<T>
        where T : IUniqueName
    {
        CoreClient _client;
        IEnumerable<T> _collection;
        Func<CoreClient, Task<IEnumerable<T>>> _get;

        public CallHelper(Func<CoreClient, Task<IEnumerable<T>>> get)
        {
            _get = get;
        }

        public async Task<IEnumerable<T>> GetCollection()
        {
            if (_collection == null)
                _collection = await _get(await GetClient());
            return _collection;
        }

        public async Task<CoreClient> GetClient()
        {
            if (_client == null)
                _client = await Configure.GetClient();
            return _client;
        }
    }

    public class DataAccessBase<T>
        where T : IUniqueName
    {
        readonly CallHelper<T> _callHelper;

        protected DataAccessBase(Func<CoreClient, Task<IEnumerable<T>>> get)
        {
            _callHelper = new CallHelper<T>(get);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _callHelper.GetCollection();
        }

        public async Task<T> GetByUniqueName(string uniqueName)
        {
            return UniqueNameMatcher.Find<T>(await _callHelper.GetCollection(), uniqueName);
        }
    }

    public class WarframeDataAccess : DataAccessBase<Frame>
    {
        public WarframeDataAccess() : base(GetFrames) { }

        static async Task<IEnumerable<Frame>> GetFrames(CoreClient client)
        {
            return JsonConvert.DeserializeObject<FrameExport>(
                await client.GetData(CoreDataType.Warframes)).ExportFrames;
        }
    }

    class FrameExport
    {
        public Frame[] ExportFrames { get; set; }
    }
}
