using BCVP.Net8.Model;
using BCVP.Net8.Repository;
using BCVP.NET8.IService;

namespace BCVP.Net8.Service
{
    // 作用是 服务层 Viewmodel
    public class UserService : IUserService
    {
        // 显示在前端的具体信息
        // service 使用的是  视图模型
        public async Task<List<UserVo>> Query()
        {
            // 仓储层的 对象
            var userRepo = new UserRepository();

            var users = await userRepo.Query();

            // 将模型转为视图模型
            return users.Select(d => new UserVo() { UserName = d.Name }).ToList();
        }
    }

}
