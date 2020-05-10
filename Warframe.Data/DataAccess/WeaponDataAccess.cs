using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public class WeaponDataAccess : DataAccess<Weapon, ExportWrapper<Weapon>>
    {
        public WeaponDataAccess() 
            : base(CoreDataType.Weapons) { }
    }
}