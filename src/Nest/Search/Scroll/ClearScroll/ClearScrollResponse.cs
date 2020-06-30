using Newtonsoft.Json;

namespace Best
{
	public interface IClearScrollResponse : IResponse
	{
	}

	[JsonObject]
	public class ClearScrollResponse : ResponseBase, IClearScrollResponse
	{
	}
}