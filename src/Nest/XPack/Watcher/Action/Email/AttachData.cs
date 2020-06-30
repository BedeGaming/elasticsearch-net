using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class AttachData
	{
		[JsonProperty("format")]
		public DataAttachmentFormat Format { get; set; }
	}
}
