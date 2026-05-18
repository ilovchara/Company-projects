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

        // 注册依赖
        // 让容器负责从某个地方 拿到这些依赖 
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseServices<Role,RoleVo> roleService)
        {
            _logger = logger;
            _roleService = roleService;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        // 虽然方法声明返回 object，但实际返回的是 List<Role> 这里的Object的作用是什么？
        public async Task<Object> Get() 
        {
            // 不使用依赖注入就需要自己使用 new 来创建 
            //var roleService = new BaseServices<Role, RoleVo>(_mapper);
            //var roleList = await roleService.Query();

            var roleList = await _roleService.Query();
            return roleList;

        }


    }
}
