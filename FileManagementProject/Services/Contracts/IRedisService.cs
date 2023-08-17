namespace FileManagementProject.Services.Contracts
{
    public interface IRedisService
    {
        Task<T> GetCachedDataAsync<T>(string key);
        Task SetCachedDataAsync<T>(string key, T value, TimeSpan timeToLive);
    }
}
