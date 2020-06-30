using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public interface IRecoveryStatusResponse : IResponse
	{
		Dictionary<string, RecoveryStatus> Indices { get; set; }
	}

	[JsonObject]
	public class RecoveryStatusResponse : ResponseBase, IRecoveryStatusResponse
	{

		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter))]
		public Dictionary<string, RecoveryStatus> Indices { get; set; } 
	}
}