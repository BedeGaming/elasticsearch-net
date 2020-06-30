using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public interface IGetIndexResponse : IResponse
	{
		IDictionary<string, IndexState> Indices { get; set; }
	}

	[JsonObject]
	public class GetIndexResponse : ResponseBase, IGetIndexResponse
	{
		public IDictionary<string, IndexState> Indices { get; set; } = new Dictionary<string, IndexState>();
	}
}
