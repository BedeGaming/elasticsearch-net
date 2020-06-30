using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Best
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum NestedScoreMode
	{
		[EnumMember(Value = "avg")]
		Average,
		[EnumMember(Value = "total")]
		Total,
		[EnumMember(Value = "min")]
		Min,
		[EnumMember(Value = "max")]
		Max,
		[EnumMember(Value = "none")]
		None
	}
}
