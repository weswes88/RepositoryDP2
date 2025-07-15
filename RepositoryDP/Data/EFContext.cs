using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RepositoryDP.Model;

namespace RepositoryDP.Data
{
    public class EFContext : IdentityDbContext<MyUserModel, IdentityRole,string>
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) 
        {
            
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
