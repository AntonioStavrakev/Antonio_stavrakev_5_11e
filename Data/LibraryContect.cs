using Antonio_stavrakev_5_11e.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antonio_stavrakev_5_11e.Data
{
	public class LibraryContext : DbContext
	{
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.connectionString);
			}
			base.OnConfiguring(optionsBuilder);
		}


		public LibraryContext()
		{
		}
		public LibraryContext(DbContextOptions options) : base(options) { }
		


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
				.HasMany(b => b.Readers)
				.WithMany(r => r.Books);

			modelBuilder.Entity<Book>()
				.HasMany(b => b.Genres)
				.WithMany(g => g.Books);
		}

	}


}
