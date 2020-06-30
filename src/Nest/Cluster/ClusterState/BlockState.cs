using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public class BlockState
	{
		[JsonProperty("read_only")]
		public bool ReadOnly { get; set; }
	}
}