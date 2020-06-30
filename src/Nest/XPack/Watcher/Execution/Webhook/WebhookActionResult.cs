using Newtonsoft.Json;

namespace Best
{
	public class WebhookActionResult
	{
		[JsonProperty("request")]
		public HttpInputRequestResult Request { get; set; }

		[JsonProperty("response")]
		public HttpInputResponseResult Response { get; set; }
	}
}
