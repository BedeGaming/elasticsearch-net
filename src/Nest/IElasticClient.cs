using System;
using Elasticsearch.Net;

namespace Best
{
	public partial interface IElasticClient 
	{
		IConnectionSettingsValues ConnectionSettings { get; }
		IElasticsearchSerializer Serializer { get; }
		IElasticLowLevelClient LowLevel { get; }
		Inferrer Infer { get; }
	}
}
