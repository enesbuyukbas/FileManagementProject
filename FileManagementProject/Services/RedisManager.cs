using FileManagementProject.Services.Contracts;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace FileManagementProject.Services
{
    public class RedisManager : IRedisService
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public RedisManager(IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetConnectionString("Redis");
            _redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
        }

        public async Task<T> GetCachedDataAsync<T>(string key)
        {
            var db = _redisConnection.GetDatabase();
            var cachedValue = await db.StringGetAsync(key);

            if (cachedValue.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(cachedValue);
            }

            return default; 
        }

        public async Task SetCachedDataAsync<T>(string key, T value, TimeSpan timeToLive)
        {
            var db = _redisConnection.GetDatabase();
            var serializedValue = JsonConvert.SerializeObject(value);

            await db.StringSetAsync(key, serializedValue, timeToLive);
        }
    }
}
