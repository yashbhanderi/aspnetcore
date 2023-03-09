namespace PublisherDomain {
	public class Cover {

		public Cover() {
			Artists = new List<Artist>();
		}

		public int CoverId { get; set; }
		public string CoverName { get; set; } = string.Empty;
		public bool IsLatest { get; set; }

		public List<Artist> Artists { get; set; }

		public override string ToString() {
			return $"{CoverId}, {CoverName}, {IsLatest}";
		}
	}
}