using Newtonsoft.Json;

namespace Best
{
	public interface IPingResponse : IResponse
	{
	}

	[JsonObject]
	public class PingResponse : ResponseBase, IPingResponse
	{
	}
}
