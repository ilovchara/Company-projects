using BCVP.Net8.Model;
using BCVP.Net8.Service;
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // 虽然方法声明返回 object，但实际返回的是 List<Role> 这里的Object的作用是什么？
        public async Task<Object> Get() 
        {
            //var userService = new UserService();
            //var userList = await userService.Query();
            //return userList;


            var roleService = new BaseServices<Role, RoleVo>();
            var roleList = await roleService.Query();
            return roleList;

        }


    }
}
