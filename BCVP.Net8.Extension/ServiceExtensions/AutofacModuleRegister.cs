using Autofac;
using Autofac.Extras.DynamicProxy;
using BCVP.Net8.Repository.Base;
using BCVP.Net8.Service;
using BCVP.NET8.IServices;
using System.Reflection;

namespace BCVP.Net8.Extension.ServiceExtensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "BCVP.Net8.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "BCVP.Net8.Repository.dll");

            // 切面编程
            var aopTypes = new List<Type>() { typeof(ServiceAOP) };
            builder.RegisterType<ServiceAOP>();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency()
                   .InstancePerDependency()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(aopTypes.ToArray()); // 注册仓储

            builder.RegisterGeneric(typeof(BaseServices<,>)).As(typeof(IBaseServices<,>))
                .InstancePerDependency()
                .EnableInterfaceInterceptors()  
                .InterceptedBy(aopTypes.ToArray()); // 注册服务

            // 获取 Service.dll 程序集服务，并注册 - 使用反射技术
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                   .AsImplementedInterfaces()
                   .InstancePerDependency()
                   .PropertiesAutowired()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(aopTypes.ToArray());


            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerDependency();
        }
    }
}

// 这里用了反射批量 注册服务
// Service.dll/Repository.dll 是 C# 项目编译后生成的程序集文件