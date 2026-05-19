using Autofac;
using BCVP.Net8.Repository.Base;
using BCVP.Net8.Service;
using BCVP.NET8.IServices;
using System.Reflection;

namespace BCVP.Net8.Extension
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "BCVP.Net8.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "BCVP.Net8.Repository.dll");

            // 注册泛型仓储 - 使用的是 瞬态 - 每次都是新对象s
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            // 注册泛型服务
            builder.RegisterGeneric(typeof(BaseServices<,>)).As(typeof(IBaseServices<,>)).InstancePerDependency();

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                   .AsImplementedInterfaces()
                   .InstancePerDependency()
                   .PropertiesAutowired();

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerDependency();
        }
    }
}
