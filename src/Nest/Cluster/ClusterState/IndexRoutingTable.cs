using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public class IndexRoutingTable
	{
		[JsonProperty("shards")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter))]
		public Dictionary<string, List<RoutingShard>> Shards { get; internal set; }
	}
}