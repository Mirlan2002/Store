using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Store.Models
{
    public class ApplicationContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Media> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "8af10569-b018-4fe7-a380-7d6a14c70b74",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "mirlandaniaruulu19@gmail.com",
                NormalizedEmail = "MIRLANDANIARUULU19@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "mypassword"),
                SecurityStamp = String.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "8af10569-b018-4fe7-a380-7d6a14c70b74",
                UserId = "3b62472e-4f66-49fa-a20f-7685b9565d8"
            });
        }
    }
}
