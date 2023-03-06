using PublisherData;
using PublisherDomain;

namespace PublisherConsole {
	public class Program {
		public static void AddAuthor() {
			var author = new Author { FirstName = "Josie", LastName = "Newf" };
			using var context = new PublisherContext();
			context.Authors.Add(author);
			context.SaveChanges();
		}

		public static void GetAuthors() {
			using var context = new PublisherContext();
			var authors = context.Authors.ToList();
			foreach (var author in authors) {
				Console.WriteLine(author.FirstName + " " + author.LastName);
			}
		}

		public static void Main() {

			Console.WriteLine("Start of the program");

			try {
				using PublisherContext context = new();
				context.Database.EnsureCreated();
			}
			catch (Exception ex) {
				Console.WriteLine("EROOOOOOOOOOOOOOOOOOOOOOOOOOORRR!!!!!!!!!!!!!");
				Console.WriteLine(ex);
			}

			//GetAuthors();
			//AddAuthor();
			//GetAuthors();

		}
	}
}