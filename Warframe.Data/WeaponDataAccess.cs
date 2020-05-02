using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public abstract class DataAccess
    {
        protected DataAccess()
        {
            if (!Configure.Initialized)
                throw new InvalidOperationException("Call Configure.Init before constructing a data access class.");
            CoreClient = Configure.GetClient().Result;
        }

        protected CoreClient CoreClient { get; }
    }

    public class WeaponDataAccess : DataAccess
    {
        WeaponDataProvider _dataProvider;

        public void Load()
        {
            _dataProvider = new WeaponDataProvider(
                CoreClient,
                Configure.RefreshMinutes);
        }

        public IEnumerable<Weapon> GetAllWeapons()
        {
            return _dataProvider.Get().ExportWeapons;
            //return (await _dataProvider.Get()).ExportWeapons;
        }
    }
}