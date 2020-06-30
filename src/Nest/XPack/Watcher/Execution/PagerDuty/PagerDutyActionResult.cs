using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class PagerDutyActionResult
	{
		[JsonProperty("sent_event")]
		public PagerDutyActionEventResult SentEvent { get; set; }
	}
}