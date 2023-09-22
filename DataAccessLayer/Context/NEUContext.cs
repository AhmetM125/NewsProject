using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class NEUContext : IdentityDbContext<Admin>
	{
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LPTNET052\\SQLEXPRESS;database=M_NewsDb;integrated security=true;Encrypt=false");
			/*optionsBuilder.UseSqlServer("server=DESKTOP-RKAH2TS;database=M_NewsDb;integrated security=true;Encrypt=false");*/		
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);	
        }

        public DbSet<Admin> Admins { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Files> Files { get; set; }


	}
}
