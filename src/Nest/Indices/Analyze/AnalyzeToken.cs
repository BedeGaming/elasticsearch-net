﻿using System;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class AnalyzeToken
	{
		[JsonProperty("token")]
		public string Token { get; internal set; }

		[JsonProperty("type")]
		public string Type { get; internal set; }

		[JsonProperty("start_offset")]
		public int StartOffset { get; internal set; }

        [Obsolete("Use EndOffset")]
		[JsonIgnore]
	    public int EndPostion => EndOffset;

		[JsonProperty("end_offset")]
		public int EndOffset { get; internal set; }

		[JsonProperty("position")]
		public int Position { get; internal set; }
	}
}
