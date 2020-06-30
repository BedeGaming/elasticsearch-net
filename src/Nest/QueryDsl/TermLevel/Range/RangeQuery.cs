using Newtonsoft.Json;

namespace Best
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof (RangeQueryJsonConverter))]
	public interface IRangeQuery : IFieldNameQuery { }

}
