using Newtonsoft.Json;

namespace Best
{
	public class ShieldNodeStatus : Throwable
	{
		[JsonProperty("success")]
		public bool Success { get; set; }
	}
}