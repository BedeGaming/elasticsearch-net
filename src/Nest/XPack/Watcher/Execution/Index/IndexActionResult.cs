using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class IndexActionResult
	{
		[JsonProperty("id")]
		public Id Id { get; set; }

		[JsonProperty("response")]
		public IndexActionResultIndexResponse Response { get; set; }
	}
}
