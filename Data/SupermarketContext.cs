using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketWeb.Models;


namespace SupermarkerEF.Data
{
	public class SupermarketContext : DbContext
	{
		public SupermarketContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }

		public DbSet<PayModel> PayModes { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }
	}
}