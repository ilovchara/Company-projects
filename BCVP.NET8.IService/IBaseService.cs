using BCVP.Net8.Model;

namespace BCVP.NET8.IService
{

    // 基础的服务类接口
    public interface IBaseServices<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Query();

    }




}
