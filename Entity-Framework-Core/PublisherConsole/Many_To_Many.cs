namespace PublisherConsole {
	class Many_To_Many {
		// ::: Many to Many Relationship :::

		//TODO 1) New Artist with New Cover

		//var artist = new Artist { FirstName = "Ravindra", LastName = "Jadeja" };
		//var cover = new Cover { CoverName = "cover4", IsLatest = false };

		//artist.Covers.Add(cover);

		//_context.Artists.Add(artist);

		//TODO 2) New Cover with Existing Artist

		//var artist = _context.Artists.Where(a => a.LastName.Contains("Sharma")).FirstOrDefault();
		//var cover = new Cover { CoverName = "cover5", IsLatest = true };

		//if (artist != null)
		//	artist.Covers.Add(cover);


		//TODO 3) Existing Artist and Existing Cover

		//var artist = _context.Artists.Find(102);
		//var cover1 = _context.Covers.Find(203);
		//var cover2 = _context.Covers.Find(201);
		//var cover3 = _context.Covers.Find(202);

		//artist?.Covers.AddRange(new List<Cover> { cover1, cover2, cover3 });


		//TODO 4) Retrive all artists who have covers

		//? Eager Loading: Eager Loading helps you to load all your needed entities at once; i.e., all your child entities will be loaded at single database call. 
		//? ---------> INCLUDE METHOD <-------- Is used to apply EAGER LOADING

		//? Lazy Loading: It is the default behavior of an Entity Framework,
		//? where a child entity is loaded -----> only when it is accessed for the first time. It simply delays the loading of the related data, until you ask for it.

		//!Use Eager Loading when the relations are not too much. Thus, Eager Loading is a good practice to reduce further queries on the Server.
		//!Use Eager Loading when you are sure that you will be using related entities with the main entity everywhere.
		//!Use Lazy Loading when you are using one-to - many collections.
		//!Use Lazy Loading when you are sure that you are not using related entities instantly.

		//TODO ::: 3 WAYS TO REMOVE LAZY LOADING ::: Bcz It poses N+1 Problem due to Many Round Trip to Database

		//! 1) INCLUDE METHOD
		//? var artists = _context.Artists.Where(a => a.Covers.Any()).Include(a => a.Covers).ToList();  
		//? Any Returns True If object has any given elements i.e. a.Covers.Length > 0


		//! 2) SELECT METHOD 
		//? var artists = _context.Artists.Where(a => a.Covers.Any())
		//? .Select(a => new {							<--- Returns SPECIFIC COLUMNS !!!
		//?	FullName = a.FirstName + " " + a.LastName,
		//?	Covers = a.Covers
		//? }).ToList();

		//! 3) EXPLICIT LOADING : When You ask for related data without INCLUDE OR SELECT 
		//var artists = _context.Artists.ToList();
		//foreach (var artist in artists) {
		//? _context.Entry(artist).Collection(a => a.Covers).Load(); // Multiple Objects i.e One->Many, Many->Many
		//? _context.Entry(artist).Reference(a => a.Covers).Load(); // One Object i.e Many->One, One->One

		//	foreach (var c in artist.Covers) {
		//		Console.WriteLine(c);
		//	}
		//}


		//TODO 5) REMOVE OBJECT ---> THAT IN A RELATIONSHIP

		//var cover = _context.Covers.Find(205);
		//_context.Covers.Remove(cover);
		//_context.SaveChanges


		//TODO 6) Un Assign Artist From Cover

		//var artist = _context.Artists.Where(a => a.Covers.Any() && a.ArtistId == 102).Include(a => a.Covers).FirstOrDefault();

		//foreach (var cover in artist.Covers) {
		//	cover.Artists.Remove(artist);
		//}

		//_context.SaveChanges();
	}
}
