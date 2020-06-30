using Newtonsoft.Json;

namespace Best
{
	public class GraphConnection
	{
		[JsonProperty("doc_count")]
		public long DocumentCount { get; internal set; }

		[JsonProperty("source")]
		public long Source { get; internal set; }

		[JsonProperty("target")]
		public long Target { get; internal set; }

		[JsonProperty("weight")]
		public double Weight { get; internal set; }

	}
}
