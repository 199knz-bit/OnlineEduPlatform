using Microsoft.EntityFrameworkCore;
namespace OnlineEduPlatform.Data
{
    public static class DbSeederExtension
    {
        public static void EnsureDbSeeded(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var created = db.Database.EnsureCreated();
                DbSeeder.Seed(db);
            }
        }
    }
}
