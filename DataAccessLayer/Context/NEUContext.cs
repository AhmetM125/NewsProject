using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class NEUContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
/*	optionsBuilder.UseSqlServer("server=LPTNET052\\SQLEXPRESS;database=M_NewsDb;integrated security=true;Encrypt=false");
*/		
			
			optionsBuilder.UseSqlServer("server=DESKTOP-RKAH2TS;database=M_NewsDb;integrated security=true;Encrypt=false");
		}
		/*public Context(DbContextOptions<Context> options) : base(options)
		{

		}
*/
		public DbSet<Admin> Admins { get; set; }
		public DbSet<News> News { get; set; }


	}
}
