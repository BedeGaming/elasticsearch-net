﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Best
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum GeoPointFielddataFormat
	{
		[EnumMember(Value = "array")]
		Array,
		[EnumMember(Value = "doc_values")]
		DocValues,
		[EnumMember(Value = "compressed")]
		Compressed,
		[EnumMember(Value = "disabled")]
		Disabled
	}
}
