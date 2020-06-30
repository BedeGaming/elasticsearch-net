using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class CompactNodeInfo
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; internal set; }
	}
}