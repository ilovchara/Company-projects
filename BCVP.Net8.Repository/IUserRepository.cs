using BCVP.Net8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.Net8.Repository
{
    internal interface IUserRepository
    {
        // 异步查询数据库，返回一堆用户数据。
        Task<List<User>> Query();
    }
}
