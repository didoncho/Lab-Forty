using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
	public class DataContext : DbContext
	{
		public DbSet<User> Users{ get; set; }
		public DbSet<UserInformation> UserInformations{ get; set; }
		public DbSet<Products> Products{ get; set; }
		public DbSet<Order> Orders{ get; set; }


		//Connection to DB
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("AKHSKAJ");

			//optionsBuilder.UseNpgsql(
			//	  "Host=192.168.89.215;Port=5432;Username=postgres;Password=123456;Database=testMig;Include Error Detail=true;"
			// ); 
			
			base.OnConfiguring(optionsBuilder);
		}


		//Entity configuration
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


		}
	}
}
