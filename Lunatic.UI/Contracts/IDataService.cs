namespace Lunatic.UI.Contracts
{
    public interface IDataService
    {
        Task SetItemAsync(string key, string value);
        Task <T> GetItemAsync<T>(string key);

    }
}
