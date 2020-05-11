using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Warframe.Data.DataAccess;
using Warframe.Util;

namespace Warframe.Data
{
    public class WeaponDataAccess : DataAccessBase<Weapon>
    {
        public WeaponDataAccess()
            : base(GetWeapons) { }

        static async Task<IEnumerable<Weapon>> GetWeapons(CoreClient client)
        {
            return JsonConvert.DeserializeObject<WeaponExport>(
                await client.GetData(CoreDataType.Weapons)).ExportWeapons;
        }
    }
}