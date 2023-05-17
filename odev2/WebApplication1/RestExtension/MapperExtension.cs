using AutoMapper;
using Odev2Schema;

namespace Odev2Service.RestExtension;
public static class MapperExtension
{
    public static void AddMapperExtension(this IServiceCollection services) //sor
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperProfile());
        });
        services.AddSingleton(config.CreateMapper());
    }
}
