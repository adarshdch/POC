using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2
{
	public class DemoContext : DbContext
	{
		public DemoContext() : base("DemoContext")
		{
			
		}

		public DbSet<Data> Data { get; set; }
	}
}