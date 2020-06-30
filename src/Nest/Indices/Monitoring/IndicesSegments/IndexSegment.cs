using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class IndexSegment
	{
		[JsonProperty(PropertyName = "shards")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter))]
		public Dictionary<string, ShardsSegment> Shards { get; internal set; }
	}
}