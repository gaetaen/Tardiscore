using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TardiscoreAPI.Model;
using TardiscoreAPI.Model.Identity;

namespace TardiscoreAPI.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}