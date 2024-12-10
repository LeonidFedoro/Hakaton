using hahahton.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace hahahton.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

        public DbSet<Event> Events { get; set; }

    }
}
