using AutoMapper;
using BCVP.Net8.Model;
using BCVP.Net8.Service;
using BCVP.NET8.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BCVP.NET8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBaseServices<Role, RoleVo> _roleService;
        private readonly IServiceScopeFactory _scopeFactory;

        // 
        public IBaseServices<Role, RoleVo> _roleServiceObj { get; set; }

        // 注册依赖
        // 让容器负责从某个地方 拿到这些依赖 
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseServices<Role, RoleVo> roleService,
            IServiceScopeFactory scopeFactory
            )
        {
            _logger = logger;
            _roleService = roleService;
            _scopeFactory = scopeFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // 虽然方法声明返回 object，但实际返回的是 List<Role> 这里的Object的作用是什么？
        public async Task<Object> Get()
        {
            // 不使用依赖注入就需要自己使用 new 来创建 
            //var roleService = new BaseServices<Role, RoleVo>(_mapper);
            //var roleList = await roleService.Query();

            // 瞬态是什么意思

            // 这里在测试

            //如果是 瞬态（InstancePerDependency）
            //→ s1 和 s2 不是同一个对象（两个新的）
            //如果是 作用域（InstancePerLifetimeScope）
            //→ s1 和 s2 是同一个对象
            //如果是 单例
            //→ 永远同一个对象


            // 这里是测试 - 依赖注入实现的对象的 生命周期
            //using var scope = _scopeFactory.CreateScope();

            //var _dataStatisticService = scope.ServiceProvider.GetRequiredService<IBaseServices<Role, RoleVo>>();
            //var roleList = await _dataStatisticService.Query();
            //var _dataStatisticService2 = scope.ServiceProvider.GetRequiredService<IBaseServices<Role, RoleVo>>();
            //var roleList21 = await _dataStatisticService2.Query();

            var roleList = await _roleServiceObj.Query();
            return roleList;

        }


    }
}
