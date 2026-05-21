using Autofac;
using Autofac.Extensions.DependencyInjection;
using BCVP.Net8.Extension.ServiceExtensions;
using BCVP.Net8.Repository.Base;
using BCVP.Net8.Service;
using BCVP.NET8.Extensions;
using BCVP.NET8.IServices;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BCVP.NET8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // C- 不使用原生的DI 使用 Autofac 依赖注入
            // autofac 的作用是 批量注入
            var builder = WebApplication.CreateBuilder(args);
            //  将原生的依赖注入修改为，Autofac形式的依赖注入 。
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule<AutofacModuleRegister>();
                    builder.RegisterModule<AutofacPropertyityModuleReg>();
                });


            // C 这里需要一个控制器 启动器 作用是什么？
            // 作用是修改为支持依赖注入的控制器
            builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMappings();

            // C_注册 - 需要用接口 注册类 -！！！！！
            // 如果注释仓储层 - 会发生什么报错 - 之后使用auto来构造依赖注入
            // 这里是使用原生的 DI
            //builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //builder.Services.AddScoped(typeof(IBaseServices<,>), typeof(BaseServices<,>));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
