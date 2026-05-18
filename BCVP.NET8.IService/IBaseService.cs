using BCVP.Net8.Model;

namespace BCVP.NET8.IServices
{

    // 基础的服务类接口
    public interface IBaseServices<TEntity,TVo> where TEntity : class,new()
    {
        Task<List<TVo>> Query();

    }




}
