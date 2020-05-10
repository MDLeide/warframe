using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Warframe.Data
{
    //todo: better to make this internal, add an external facing interface
    public abstract class DataAccess<T, TWrapper>
        where T : IUniqueName
        where TWrapper : ExportWrapper<T>
    {
        IEnumerable<T> _data;
        CoreDataType _type;

        protected DataAccess(CoreDataType type)
        {
            if (!Configure.Initialized)
                throw new InvalidOperationException("Call Configure.Init before constructing a data access class.");
            CoreClient = Configure.GetClient().Result;
            _type = type;
        }

        public IEnumerable<T> GetAll()
        {
            CheckData();
            return _data;
        }

        public T GetByUniqueName(string uniqueName)
        {
            CheckData();
            return _data.FirstOrDefault(p => p.UniqueName == uniqueName);
        }

        void CheckData()
        {
            if (_data == null)
                _data = GetData();
        }

        protected virtual IEnumerable<T> GetData()
        {
            return JsonConvert.DeserializeObject<TWrapper>(CoreClient.GetData(_type)).Export;
        }

        protected CoreClient CoreClient { get; }
    }
}