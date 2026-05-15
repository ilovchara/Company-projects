using BCVP.Net8.Model;
using Newtonsoft.Json;

namespace BCVP.Net8.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public async Task<List<TEntity>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\": 18,\"Name\": \"这里是base仓储层基类，如果使用了这个就会出现字符串\"}]";

            // 将 JSON 字符串反序列化为泛型实体列表
            return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();
        }
    }
}
