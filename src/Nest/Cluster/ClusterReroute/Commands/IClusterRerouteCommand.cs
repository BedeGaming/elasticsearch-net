using Newtonsoft.Json;

namespace Best
{
	[ContractJsonConverter(typeof(ClusterRerouteCommandJsonConverter))]
	public interface IClusterRerouteCommand
	{
		[JsonIgnore]
		string Name { get; }
	}
}