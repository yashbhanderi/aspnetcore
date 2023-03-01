using ServiceContracts;

namespace Services {
	public class CitiesService : ICitiesService, IDisposable {

		private readonly List<string> _cities;
		private readonly Guid _instanceID;

		public Guid InstanceID { get { return _instanceID; } }

		public CitiesService() {

			// TODO:   Create Database connection | and some logic


			_instanceID = Guid.NewGuid();   // Creating GUID every time when constrctor called !!!!
			_cities = new List<string>()
			{
				"Surat", "Mumbai", "Ahmedabad", "Delhi", "Banglore"
			};

		}

		public List<string> GetCities() {
			return _cities;
		}

		public void Dispose() {
			// TODO:	End the database connection | and some logic
		}
	}
}