using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Best
{
	[JsonConverter(typeof (StringEnumConverter))]
	public enum NoMatchShortcut
	{
		[EnumMember(Value = "none")] None,
		[EnumMember(Value = "all")] All
	}
}