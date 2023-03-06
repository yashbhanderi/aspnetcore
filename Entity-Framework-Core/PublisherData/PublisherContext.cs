using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData {
	public class PublisherContext : DbContext {
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(
			  "Data Source=DESKTOP-K63766J;Initial Catalog=PublisherDatabase;Integrated Security=True"
			);
		}

	}
}