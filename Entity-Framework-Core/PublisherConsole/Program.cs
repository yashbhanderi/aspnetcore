using PublisherData;

namespace PublisherConsole {
	public class Program {
		public static readonly PublisherContext _context = new();

		public static void Execute() {


			//TODO ::: One to One relationship

			//! In EF Core, ONE-TO-ONE can implement in ---> 2 WAYS <----

			//! 1) SHARED PRIMARY KEY ASSN,
			//! The dependent table shares the same primary key as the principal table. This
			//?			In this scenario, you cannot insert a row into the dependent table without first inserting a row into the principal table

			//! 2) FOREIGN KEY 
			//! The dependent table has a foreign key that references the primary key of the principal table.
			//?          In this scenario, you can insert a row into the dependent table without first inserting a row into the principal table ( But Primary Key to create FK should be exist in Principle Table)



			//! In a one - to - one relationship, the principal table can exist without the dependent table,
			//! but the dependent table cannot exist without the principal table.

			//TODO 1) Fetch the Country and Capital List
			//var cty = _context.Countries.Include(c => c.Capital).ToList();

			//TODO 2) Fetch the Countries which have capitals
			//var cty = _context.Countries.Where(c => c.Capital.CountryId == c.CountryId).Include(c => c.Capital).ToList();


			//TODO 3) Add Capital to Existing Country
			//var cty = _context.Countries.Where(c => c.CountryName == "England").FirstOrDefault();
			//var capital = new Capital() { CapitalName = "London", CapitalCode = "LON", CountryId = cty.CountryId };
			//cty.Capital = capital;
			//_context.SaveChanges();

			//TODO 4) Remove Capital From Country
			//! JUST REMOVE ROW FROM CAPITAL -> BCZ Capital can't exist without country

			//var country = _context.Countries.Where(c => c.CountryName == "England").Include(c => c.Capital).FirstOrDefault();

			//if (country != null) {
			//! TWO WAYS
			//! 1)	_context.Capitals.Remove(country.Capital);
			//! 2)	country.Capital = null;
			//}

			_context.SaveChanges();



			//foreach (var country in _context.Countries.Select(c => new { cap = c.Capital }).ToList()) {
			//	Console.WriteLine("Country: " + country);
			//	Console.WriteLine("Capital: " + country.cap);
			//	Console.WriteLine();
			//}
		}


		public static void Main() {

			Console.WriteLine("Start of the program");

			Execute();

		}
	}
}