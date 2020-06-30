using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class ClusterRerouteExplanation
	{
		[JsonProperty("command")]
		public string Command { get; set; }
		
		[JsonProperty("parameters")]
		public ClusterRerouteParameters Parameters { get; set; }

		[JsonProperty("decisions")]
		public IEnumerable<ClusterRerouteDecision> Decisions { get; set; }
	}
}
