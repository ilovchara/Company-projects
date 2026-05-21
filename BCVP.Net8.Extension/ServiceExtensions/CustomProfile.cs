using AutoMapper;
using BCVP.Net8.Model;

namespace BCVP.Net8.Extension.ServiceExtensions
{
    /// <summary>
    /// 构造 视图模型 与 基本模型的关系映射
    /// </summary>
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数用来创建 关系 映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<Role, RoleVo>()
                .ForMember(a => a.RoleName, o => o.MapFrom(d => d.Name));
            CreateMap<RoleVo, Role>()
                .ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName));
        }
    }
}
