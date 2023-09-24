using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class NEUContext : DbContext
	{
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			/*optionsBuilder.UseSqlServer("server=LPTNET052\\SQLEXPRESS;database=NewsDb;integrated security=true;Encrypt=false");*/
            optionsBuilder.UseSqlServer("server=DESKTOP-RKAH2TS;database=NewsDb;integrated security=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserRole>()
                .HasKey(b => new
                {
                    b.RoleId,
                    b.UserId
                });
            builder.Entity<RolePermission>()
                .HasKey(x => new
                {
                    x.RoleId,
                    x.PermissionId
                });

        }

        public DbSet<Admin> Admins { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Files> Files { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


	}
}
