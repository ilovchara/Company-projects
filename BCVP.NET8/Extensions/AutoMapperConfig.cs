using AutoMapper;

namespace BCVP.NET8.Extensions
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
