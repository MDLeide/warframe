namespace Warframe.Data
{
    class WeaponDataProvider : DataProvider<Weapon, WeaponExport>
    {
        public WeaponDataProvider(Client client, int refreshMinutes)
            : base(
                client, 
                refreshMinutes, 
                (c) => c.GetWeaponsData()) { }
    }
}
