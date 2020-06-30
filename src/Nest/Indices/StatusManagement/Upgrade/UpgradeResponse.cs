using Newtonsoft.Json;

namespace Best
{
	public interface IUpgradeResponse : IResponse
	{
		[JsonProperty("_shards")]
		ShardsMetaData Shards { get; set; }
	}

	public class UpgradeResponse : ResponseBase, IUpgradeResponse
	{
		public ShardsMetaData Shards { get; set; }
	}
}
