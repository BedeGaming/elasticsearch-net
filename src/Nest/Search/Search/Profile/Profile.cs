using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Best
{
	public class Profile
	{
		[JsonProperty("shards")]
		public IEnumerable<ShardProfile> Shards { get; internal set; }
	}
}
