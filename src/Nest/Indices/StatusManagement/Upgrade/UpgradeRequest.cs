using Elasticsearch.Net;

namespace Best
{
	public partial interface IUpgradeRequest : IRequest<UpgradeRequestParameters> { }

	public partial class UpgradeRequest { }

	[DescriptorFor("IndicesUpgrade")]
	public partial class UpgradeDescriptor { }
}
