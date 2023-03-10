namespace PublisherDomain {
	public class Country {

		public int CountryId { get; set; }
		public string CountryName { get; set; } = string.Empty;

		public string CountryCode { get; set; } = string.Empty;

		public Capital Capital { get; set; }

		public override string ToString() {
			return $"{CountryId}, {CountryName}, {CountryCode}";
		}
	}
}
