using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Best
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum GeoOptimizeBBox
	{
		[EnumMember(Value = "memory")]
		Memory,
		[EnumMember(Value = "indexed")]
		Indexed,
		[EnumMember(Value = "none")]
		None
	}
}
