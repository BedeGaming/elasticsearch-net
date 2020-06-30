using System.Collections.Generic;

namespace Best
{
	public class SignificantTermsAggregate : MultiBucketAggregate<SignificantTermsBucket>
	{
		public SignificantTermsAggregate() { }
		public SignificantTermsAggregate(IDictionary<string, IAggregate> aggregations) : base(aggregations) { }

		public long DocCount { get; set; }
	}
}
