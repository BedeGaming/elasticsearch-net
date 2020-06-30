using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class CompletionStats
	{
		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("size_in_bytes")]
		public long SizeInBytes { get; set; }
	}
}
