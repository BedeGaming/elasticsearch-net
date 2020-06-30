using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	[JsonConverter(typeof(BulkResponseItemJsonConverter))]
	public class BulkUpdateResponseItem : BulkResponseItemBase
	{
		public override string Operation { get; internal set; }
	}
}