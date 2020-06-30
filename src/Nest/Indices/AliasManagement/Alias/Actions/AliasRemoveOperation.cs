using Newtonsoft.Json;

namespace Best
{
	public class AliasRemoveOperation
	{
		[JsonProperty("index")]
		public IndexName Index { get; set; }
		[JsonProperty("alias")]
		public string Alias { get; set; }
	}
}