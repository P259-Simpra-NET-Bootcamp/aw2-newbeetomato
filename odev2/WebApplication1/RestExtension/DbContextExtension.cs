using OdevData.Context;
using Microsoft.EntityFrameworkCore;

namespace Odev2Service.RestExtension;
public static class DbContextExtension
{
    public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
    {
        var dbType = Configuration.GetConnectionString("DbType");
        if (dbType == "SQL")
        {
            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<Odev2DbContext>(opts =>
            opts.UseSqlServer(dbConfig));
        }
        else if (dbType == "PostgreSql")
        {
            var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddDbContext<Odev2DbContext>(opts =>
              opts.UseNpgsql(dbConfig));
        }

    }
}
