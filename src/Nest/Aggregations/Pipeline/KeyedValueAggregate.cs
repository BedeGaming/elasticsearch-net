using System.Collections.Generic;

namespace Best
{
	public class KeyedValueAggregate : ValueAggregate
	{
		public IList<string> Keys { get; set; }
	}
}
