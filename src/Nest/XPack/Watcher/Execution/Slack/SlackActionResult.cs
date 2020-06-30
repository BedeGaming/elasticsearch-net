using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class SlackActionResult
	{
		[JsonProperty("account")]
		public string Account { get; set; }

		[JsonProperty("sent_messages")]
		public IEnumerable<SlackActionMessageResult> SentMessages { get; set; }
	}
}
