using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class IndicesStats
	{
		[JsonProperty(PropertyName = "primaries")]
		public IndexStats Primaries { get; set; }
		[JsonProperty(PropertyName = "total")]
		public IndexStats Total { get; set; }
	}
}
