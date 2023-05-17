using OdevData.Repository.Staffs;

namespace Odev2Service.RestExtension;
public static class RepositoryExtension
{
    public static void AddRepositoryExtension(this IServiceCollection services)
    { 
        services.AddScoped<IStaffRepository, StaffRepository>();
    }
}