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
    public class BaseServices<TEntity,TVo> : IBaseServices<TEntity> where TEntity : class
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

        // 这里有问题 - 这里的重载关系有问题 回来再解决吧
        Task<List<TEntity>> IBaseServices<TEntity>.Query()
        {
            throw new NotImplementedException();
        }
    }
}
