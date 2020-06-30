using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public class RoutingTableState
	{
		[JsonProperty("indices")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter))]
		public Dictionary<string, IndexRoutingTable> Indices { get; internal set; }
	}
}