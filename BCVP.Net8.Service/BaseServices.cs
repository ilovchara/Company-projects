using BCVP.Net8.Repository.Base;
using BCVP.NET8.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.Net8.Service
{
    public class BaseServices<TEntity,TVo> : IBaseServices<TEntity> where TEntity : class
    {
        public async Task<List<TEntity>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            return await baseRepo.Query();
        }
    }
}
