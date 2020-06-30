using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public class RoutingNodesState
	{
		[JsonProperty("unassigned")]
		public List<RoutingShard> Unassigned { get; internal set; }

		[JsonProperty("nodes")]
		public Dictionary<string, List<RoutingShard>> Nodes { get; internal set; }
	}
}