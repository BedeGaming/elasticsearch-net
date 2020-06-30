﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public class Explanation
	{
		[JsonProperty(PropertyName = "value")]
		public float Value { get; internal set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; internal set; }

		[JsonProperty(PropertyName = "details")]
		public IEnumerable<ExplanationDetail> Details { get; set; }
	}
}
