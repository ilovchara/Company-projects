using AutoMapper;
using BCVP.Net8.Repository.Base;
using BCVP.NET8.IService;
using BCVP.NET8.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 依赖注入流程
// 1. 在program 注册对应的依赖
// 2. 在需要依赖的类中 - 构造函数中创建字段 - 接收依赖
// 3. 之后根据需要 来使用就行 --- 这个是最大的难点 - 什么时候要用到这些对象方法呢

namespace BCVP.Net8.Service
{
    public class BaseServices<TEntity, TVo> : IBaseServices<TEntity, TVo>
        where TEntity : class, new()  // ← 添加 new() 约束
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseServices(IMapper mapper, IBaseRepository<TEntity> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<TVo>> Query()
        {
            var entities = await _baseRepository.Query();
            var llout = _mapper.Map<List<TVo>>(entities);
            return llout;
        }
    }
}
