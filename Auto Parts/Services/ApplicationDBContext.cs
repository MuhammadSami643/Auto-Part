using Auto_Parts.Models;
using Microsoft.EntityFrameworkCore;

namespace Auto_Parts.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Form> Form { get; set; }
    }
}
