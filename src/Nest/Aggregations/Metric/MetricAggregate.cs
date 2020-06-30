using System;
using System.Collections.Generic;

namespace Best
{
	public abstract class MetricAggregateBase : IAggregate
	{
		public IDictionary<string, object> Meta { get; set; }
	}
}
