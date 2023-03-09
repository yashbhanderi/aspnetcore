namespace PublisherDomain {
	public class Artist {

		public Artist() {
			Covers = new List<Cover>();
		}

		public int ArtistId { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public List<Cover> Covers { get; set; }

		public override string ToString() {
			return $"{ArtistId}, {FirstName}, {LastName}";
		}
	}
}
