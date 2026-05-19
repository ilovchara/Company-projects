using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace BCVP.NET8.Extensions
{
    public class AutofacPropertyityModuleReg : Module
    {
        // 所有 Controller 开启属性注入，让控制器可以直接用属性接收服务，不用写构造函数。
        protected override void Load(ContainerBuilder builder)
        {
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                   .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                   .PropertiesAutowired();
        }
    }

}
