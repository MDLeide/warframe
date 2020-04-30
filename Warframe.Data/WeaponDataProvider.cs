namespace Warframe.Data
{
    class WeaponDataProvider : DataProvider<WeaponExport>
    {
        public WeaponDataProvider(Client client, int refreshMinutes)
            : base(
                client, 
                refreshMinutes, 
                (c) => c.GetWeaponsData()) { }
    }
}
