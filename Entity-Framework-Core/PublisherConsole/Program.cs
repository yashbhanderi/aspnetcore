using Microsoft.EntityFrameworkCore;
using PublisherData;

namespace PublisherConsole {
	public class Program {
		public static readonly PublisherContext _context = new();

		public static void Execute() {

			// ::: Retrive the Data || Convert into List of C# Objects 
			//var authors = context.Authors.ToList();

			// ::: Only get data which has books property
			//var authors = context.Authors.Include(a => a.Books).ToList();

			// ::: Filtering
			//var authors = context.Authors.Where(a => a.FirstName.Contains("m") && a.LastName.Contains("m")).ToList();

			// ::: Sorting
			//var authors = context.Authors
			//				.OrderBy(a => a.LastName)
			//				//.OrderBy(a => a.FirstName)	<---- Don't USE THIS !!!
			//				.ThenBy(a => a.FirstName)
			//				.ToList();

			//foreach (var a in authors) {
			//	Console.WriteLine(a.ToString());
			//}

			// ::: Tracking changes and ChangeTracker Object


			//var authors = context.Authors.Where(a => a.FirstName.StartsWith("m")).ToList();

			//foreach (var a in authors) {
			//	a.LastName += " Updated";
			//}

			//Console.WriteLine("Before Update\n" + context.ChangeTracker.DebugView.LongView);

			//// Internally Calls SaveChanges()
			//context.ChangeTracker.DetectChanges();	


			//Console.WriteLine("After Update\n" + context.ChangeTracker.DebugView.LongView);


			// ::: Many to Many Relationship :::


			//? 1) New Artist with New Cover

			//var artist = new Artist { FirstName = "Ravindra", LastName = "Jadeja" };
			//var cover = new Cover { CoverName = "cover4", IsLatest = false };

			//artist.Covers.Add(cover);

			//_context.Artists.Add(artist);

			//? 2) New Cover with Existing Artist

			//var artist = _context.Artists.Where(a => a.LastName.Contains("Sharma")).FirstOrDefault();
			//var cover = new Cover { CoverName = "cover5", IsLatest = true };

			//if (artist != null)
			//	artist.Covers.Add(cover);


			//? 3) Existing Artist and Existing Cover

			//var artist = _context.Artists.Find(102);
			//var cover1 = _context.Covers.Find(203);
			//var cover2 = _context.Covers.Find(201);
			//var cover3 = _context.Covers.Find(202);

			//artist?.Covers.AddRange(new List<Cover> { cover1, cover2, cover3 });


			//? 4) Retrive all artists who have covers

			var artists = _context.Artists.Where(a => a.Covers.Any()).Include(a => a.Covers).ToList();  //! Any Returns True If object has any given elements i.e. a.Covers.Length > 0

			foreach (var artist in artists) {
				Console.WriteLine(artist + "\n Covers:-\n");

				foreach (var c in artist.Covers) {
					Console.WriteLine(c);
				}

				Console.WriteLine();
			}

			//_context.SaveChanges();

		}

		public static void Main() {

			Console.WriteLine("Start of the program");

			try {
				Execute();
			}
			catch (Exception ex) {
				Console.WriteLine("ERRRROOOORRR!!!");
			}

		}
	}
}