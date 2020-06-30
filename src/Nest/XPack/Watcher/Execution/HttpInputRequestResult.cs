using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<HttpInputRequestResult>))]
	public class HttpInputRequestResult : HttpInputRequest {}
}
