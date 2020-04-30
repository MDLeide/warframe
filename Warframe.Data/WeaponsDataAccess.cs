using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public class WeaponsDataAccess
    {
        readonly string _baseUrl;
        readonly string _index;
        readonly int _refresh;

        WeaponDataProvider _dataProvider;

        public WeaponsDataAccess(string baseUrl, string indexLocation, int refreshMinutes)
        {
            _baseUrl = baseUrl;
            _index = indexLocation;
            _refresh = refreshMinutes;
        }

        public async Task Load()
        {
            _dataProvider = new WeaponDataProvider(
                await Client.Create(_baseUrl, _index),
                _refresh);
        }

        public async Task<IEnumerable<Weapon>> GetAllWeapons()
        {
            return (await _dataProvider.Get()).ExportWeapons;
        }
    }
}