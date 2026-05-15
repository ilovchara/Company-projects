using BCVP.Net8.Model;
using Newtonsoft.Json;

namespace BCVP.Net8.Repository
{
    public class UserRepository : IUserRepository
    {
        // 模拟业务逻辑
        // 异步查询数据库或API获取用户列表的业务逻辑 - 使用了假数据

        // 仓储层中的数据不可以暴露在外部 - 所以说增加一个层级来封装
        // 此外 模型一般也不暴露在外部 - 需要添加一个视图模型来封装
        public async Task<List<User>> Query()
        {
            await Task.CompletedTask;
            var data = "[{ \"Id\": 18 ,\"Name\" : \"Chara\"}]";
            return JsonConvert.DeserializeObject<List<User>>(data) ?? new List<User>();

        }

    }
}
