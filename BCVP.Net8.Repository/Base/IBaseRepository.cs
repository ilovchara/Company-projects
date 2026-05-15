using BCVP.Net8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 基础的 实体仓储层
// 之后只需要创建 对应的实体 还有 实体视图模型 就可以构造完成

namespace BCVP.Net8.Repository.Base
{
    // 基础的服务类接口
    // BYD - ai把接口名称改了
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Query();
    }



}
