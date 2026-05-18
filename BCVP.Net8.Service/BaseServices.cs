using AutoMapper;
using BCVP.Net8.Repository.Base;
using BCVP.NET8.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.Net8.Service
{
    public class BaseServices<TEntity, TVo> : IBaseServices<TEntity, TVo> where TEntity : class
    {
        private readonly IMapper _mapper;

        public BaseServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<TVo>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            // 对象关系映射
            var entities = await baseRepo.Query();
            var llout = _mapper.Map<List<TVo>>(entities);
            return llout;
        }

        Task<List<TEntity>> IBaseServices<TEntity, TVo>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
