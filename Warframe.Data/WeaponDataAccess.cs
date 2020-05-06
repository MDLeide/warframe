using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warframe.Data
{
    //public class WeaponDataProvider
    //{
    //    public IEnumerable<Weapon> GetAllWeapons()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


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