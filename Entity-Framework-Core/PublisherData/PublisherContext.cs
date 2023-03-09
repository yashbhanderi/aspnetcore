﻿using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData {
	public class PublisherContext : DbContext {
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		public DbSet<Artist> Artists { get; set; }

		public DbSet<Cover> Covers { get; set; }

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

			modelBuilder.Entity<Artist>().HasData(artistList);
			modelBuilder.Entity<Cover>().HasData(coverList);


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

// Migrations:

// :::Add-Migrations
// Convert Model -> Migration File

// Migrations File to Database : Two ways

// ::: 1) Update-Migration
// COnvert Migration -> SQL Query -> Execute Query

// ::: 2) Script-Migrations
// -> It will convert all migrations file into SQL Query
// -> Not latest migrations !!! But all the migrations
// -> WHether table is already created or not.
// -> You want to examine the SQL script that would be generated by a migration without actually applying it to the database. This can be useful for reviewing the changes or debugging potential issues.