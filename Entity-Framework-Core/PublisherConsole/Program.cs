using PublisherData;


namespace PublisherConsole {
	public class Program {
		public static readonly PublisherContext context = new();

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

		}

		public static void Main() {

			Console.WriteLine("Start of the program");

			Execute();

		}
	}
}