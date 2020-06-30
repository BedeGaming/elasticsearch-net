using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class FlushStats
	{
	
		[JsonProperty(PropertyName = "total")]
		public long Total { get; set; }

		[JsonProperty(PropertyName = "total_time")]
		public string TotalTime { get; set; }
		[JsonProperty(PropertyName = "total_time_in_millis")]
		public long TotalTimeInMilliseconds { get; set; }

	}
}
