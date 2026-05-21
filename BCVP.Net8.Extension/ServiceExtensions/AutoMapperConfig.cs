using AutoMapper;

namespace BCVP.Net8.Extension.ServiceExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration( cfg =>
            {
                cfg.AddProfile(new CustomProfile());
            });
        }
    }
}
