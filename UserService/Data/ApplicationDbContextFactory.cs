using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DefineX.Services.UserService.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Specify your connection string here, ensure it's the same as in your appsettings.json
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
