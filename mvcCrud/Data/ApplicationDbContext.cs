using Microsoft.EntityFrameworkCore;
using mvcCrud.Models;

namespace mvcCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //category is model 
        //table name is categories
        public DbSet<Category> categories { get; set; }
    }
}
