using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class LoggingActionResult
	{
		[JsonProperty("logged_text")]
		public string LoggedText { get; set; }
	}
}