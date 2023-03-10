namespace PublisherDomain {
	public class Capital {
		public int CapitalId { get; set; }

		public string CapitalName { get; set; } = string.Empty;

		public string CapitalCode { get; set; }

		public int CountryId { get; set; }

		public Country Country { get; set; }
		public override string ToString() {
			return $"{CapitalId}, {CapitalName}, {CapitalCode}";
		}
	}
}
