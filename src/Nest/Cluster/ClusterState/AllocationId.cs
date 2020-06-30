using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public class AllocationId
	{
		[JsonProperty("id")]
		public string Id { get; internal set; }
	}
}