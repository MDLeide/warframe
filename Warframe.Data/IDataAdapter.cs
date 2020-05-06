namespace Warframe.Data
{
    public interface IDataAdapter<T>
        where T : IUniqueName
    {
        T GetData();
        T GetDataByUniqueName(string uniqueName);
        bool SupportsUniqueName { get; }
    }
}