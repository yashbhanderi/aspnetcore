namespace Services
{
    public class CitiesService
    {
        private List<string> _cities;

        public CitiesService() {
            _cities = new List<string>()
            {
                "Surat", "Mumbai", "Ahmedabad", "Delhi", "Banglore"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}