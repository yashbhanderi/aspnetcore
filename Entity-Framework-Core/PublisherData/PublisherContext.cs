using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData {
	public class PublisherContext : DbContext {
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		public DbSet<Artist> Artists { get; set; }

		public DbSet<Cover> Covers { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Capital> Capitals { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(
			  "Data Source=DESKTOP-K63766J;Initial Catalog=PublisherDatabase;Integrated Security=True;TrustServerCertificate=True"
			);
			//.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			var artist1 = new Artist() { ArtistId = 101, FirstName = "Virat", LastName = "Kohli" };
			var artist2 = new Artist() { ArtistId = 102, FirstName = "Steve", LastName = "Smith" };
			var artist3 = new Artist() { ArtistId = 103, FirstName = "Rohit", LastName = "Sharma" };
			var artistList = new Artist[] { artist1, artist2, artist3 };

			var cover1 = new Cover() { CoverId = 201, CoverName = "cover1", IsLatest = true };
			var cover2 = new Cover() { CoverId = 202, CoverName = "cover2", IsLatest = false };
			var cover3 = new Cover() { CoverId = 203, CoverName = "cover3", IsLatest = true };
			var coverList = new Cover[] { cover1, cover2, cover3 };

			var country1 = new Country() { CountryId = 1, CountryName = "India", CountryCode = "IN" };
			var country2 = new Country() { CountryId = 2, CountryName = "USA", CountryCode = "US" };
			var country3 = new Country() { CountryId = 3, CountryName = "Russia", CountryCode = "RSA" };
			var countryList = new Country[] { country1, country2, country3 };

			var capital1 = new Capital() { CapitalId = 11, CapitalName = "Delhi", CapitalCode = "DL", CountryId = 1 };
			var capital2 = new Capital() { CapitalId = 12, CapitalName = "Washington D.C.", CapitalCode = "WSDC", CountryId = 2 };
			var capital3 = new Capital() { CapitalId = 13, CapitalName = "Moscow", CapitalCode = "MSC", CountryId = 3 };
			var capitalList = new Capital[] { capital1, capital2, capital3 };

			modelBuilder.Entity<Artist>().HasData(artistList);
			modelBuilder.Entity<Cover>().HasData(coverList);
			modelBuilder.Entity<Country>().HasData(countryList);
			modelBuilder.Entity<Capital>().HasData(capitalList);


			// This can make One (Author) -> Many (Books) Relationship
			// Without Following things:

			// Author:
			// public List<Book> books = new();

			// In the Book class:
			// public Author Id <-- Specifically describe for Foreign Key
			// public int AuthorId <--Naming Convension

			//modelBuilder.Entity<Author>()
			//			.HasMany<Book>()
			//			.WithOne();
			//			.HasForeignKey(b=> b.AuthorFK); <----- To change Naming Convension of EF Core | Initially It only check for Parent Table ref, and append the "Id" at Last. BUTTT Now, IF any Key has FK Behind it, It will be Foreign key
		}
	}
}