using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class CatHelpRecord : ICatRecord
	{
		[JsonProperty("endpoint")]
		public string Endpoint { get; set; }

	}
}
