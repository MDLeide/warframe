namespace Warframe.Data
{
    class WeaponDataProvider : DataProvider<WeaponExport>
    {
        public WeaponDataProvider(CoreClient client, int refreshMinutes)
            : base(
                client,
                refreshMinutes,
                (c) => c.GetWeaponsData())
        { }
    }
}
