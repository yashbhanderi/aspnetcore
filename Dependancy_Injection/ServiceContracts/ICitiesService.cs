namespace ServiceContracts {
	public interface ICitiesService {
		List<string> GetCities();
		Guid InstanceID { get; }
	}
}