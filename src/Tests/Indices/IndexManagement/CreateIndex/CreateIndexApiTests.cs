﻿using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Indices.IndexManagement.CreateIndex
{
	public class CreateIndexApiTests : ApiIntegrationTestBase<WritableCluster, ICreateIndexResponse, ICreateIndexRequest, CreateIndexDescriptor, CreateIndexRequest>
	{
		public CreateIndexApiTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.CreateIndex(CallIsolatedValue, f),
			fluentAsync: (client, f) => client.CreateIndexAsync(CallIsolatedValue, f),
			request: (client, r) => client.CreateIndex(r),
			requestAsync: (client, r) => client.CreateIndexAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.PUT;
		protected override string UrlPath => $"/{CallIsolatedValue}";

		protected override object ExpectJson { get; } = new
		{
			settings = new Dictionary<string, object>
			{
				{ "index.number_of_replicas", 1 },
				{ "index.number_of_shards", 1 },
				{ "similarity", new
					{
						bm25 = new
						{
							k1 = 1.1,
							b = 1.0,
							discount_overlaps = true,
							type = "BM25"
						},
						tfidf = new
						{
							discount_overlaps = true,
							type = "default"
						},
						dfr = new Dictionary<string, object>{
							{ "basic_model", "d" },
							{ "after_effect", "b" },
							{ "normalization", "h1" },
							{ "normalization.h1.c", 1.1 },
							{ "type", "DFR" }
						},
						ib = new Dictionary<string, object> {
							{ "distribution", "ll" },
							{ "lambda", "df" },
							{ "normalization", "h1" },
							{ "normalization.h1.c", 1.2 },
							{ "type", "IB" }
						},
						lmd = new
						{
							mu = 2,
							type = "LMDirichlet"
						},
						lmj = new
						{
							lambda = 2.0,
							type = "LMJelinekMercer"
						}
					}
				}
			}
		};

		protected override CreateIndexDescriptor NewDescriptor() => new CreateIndexDescriptor(CallIsolatedValue);

		protected override Func<CreateIndexDescriptor, ICreateIndexRequest> Fluent => d => d
			.Settings(s => s
				.NumberOfReplicas(1)
				.NumberOfShards(1)
				.Similarity(si => si
					.BM25("bm25", b => b
						.B(1.0)
						.K1(1.1)
						.DiscountOverlaps()
					)
					.Default("tfidf", c => c
						.DiscountOverlaps()
					)
					.DFR("dfr", df => df
						.AfterEffect(DFRAfterEffect.B)
						.BasicModel(DFRBasicModel.D)
						.NormalizationH1(1.1)
					)
					.IB("ib", ib => ib
						.Lambda(IBLambda.DocumentFrequency)
						.NormalizationH1(1.2)
						.Distribution(IBDistribution.LogLogistic)
					)
					.LMDirichlet("lmd", lm => lm
						.Mu(2)
					)
					.LMJelinek("lmj", lm => lm
						.Lamdba(2.0)
					)
				)
			);

		protected override CreateIndexRequest Initializer => new CreateIndexRequest(CallIsolatedValue)
		{
			Settings = new Nest.IndexSettings()
			{
				NumberOfReplicas = 1,
				NumberOfShards = 1,
				Similarity = new Similarities
				{
					{ "bm25", new BM25Similarity
						{
							B = 1.0,
							K1 = 1.1,
							DiscountOverlaps = true
						}
					},
					{ "tfidf", new DefaultSimilarity
						{
							DiscountOverlaps = true
						}
					},
					{ "dfr", new DFRSimilarity
						{
							AfterEffect = DFRAfterEffect.B,
							BasicModel = DFRBasicModel.D,
							Normalization = Normalization.H1,
							NormalizationH1C = 1.1
						}
					},
					{ "ib", new IBSimilarity
						{
							Distribution = IBDistribution.LogLogistic,
							Lambda = IBLambda.DocumentFrequency,
							Normalization = Normalization.H1,
							NormalizationH1C = 1.2
						}
					},
					{ "lmd", new LMDirichletSimilarity
						{
							Mu = 2
						}
					},
					{ "lmj", new LMJelinekMercerSimilarity
						{
							Lambda = 2.0
						}
					}
				}
			}
		};

		protected override void ExpectResponse(ICreateIndexResponse response)
		{
			response.ShouldBeValid();
			response.Acknowledged.Should().BeTrue();

			var indexSettings = this.Client.GetIndexSettings(g => g.Index(CallIsolatedValue));

			indexSettings.ShouldBeValid();
			indexSettings.Indices.Should().NotBeEmpty().And.ContainKey(CallIsolatedValue);

			var settings = indexSettings.Indices[CallIsolatedValue];

			settings.Settings.NumberOfShards.Should().Be(1);
			settings.Settings.NumberOfReplicas.Should().Be(1);
			var similarities = settings.Settings.Similarity;

			similarities.Should().NotBeNull();
			similarities.Should().ContainKey("bm25").WhichValue.Should().BeOfType<BM25Similarity>();
			similarities.Should().ContainKey("tfidf").WhichValue.Should().BeOfType<DefaultSimilarity>();
			similarities.Should().ContainKey("dfr").WhichValue.Should().BeOfType<DFRSimilarity>();
			similarities.Should().ContainKey("ib").WhichValue.Should().BeOfType<IBSimilarity>();
			similarities.Should().ContainKey("lmd").WhichValue.Should().BeOfType<LMDirichletSimilarity>();
			similarities.Should().ContainKey("lmj").WhichValue.Should().BeOfType<LMJelinekMercerSimilarity>();
		}
	}

	[SkipVersion("<2.3.0", "DFI Not supported prior to 2.3.0")]
	public class CreateIndexDFIApiTests : ApiIntegrationTestBase<WritableCluster, ICreateIndexResponse, ICreateIndexRequest, CreateIndexDescriptor, CreateIndexRequest>
	{
		public CreateIndexDFIApiTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }
		protected override LazyResponses ClientUsage() => Calls(
			fluent: (client, f) => client.CreateIndex(CallIsolatedValue, f),
			fluentAsync: (client, f) => client.CreateIndexAsync(CallIsolatedValue, f),
			request: (client, r) => client.CreateIndex(r),
			requestAsync: (client, r) => client.CreateIndexAsync(r)
		);

		protected override bool ExpectIsValid => true;
		protected override int ExpectStatusCode => 200;
		protected override HttpMethod HttpMethod => HttpMethod.PUT;
		protected override string UrlPath => $"/{CallIsolatedValue}";

		protected override object ExpectJson { get; } = new
		{
			settings = new Dictionary<string, object>
			{
				{ "index.number_of_replicas", 1 },
				{ "index.number_of_shards", 1 },
				{ "similarity", new
					{
						dfi = new
						{
							independence_measure = "chisquared",
							type = "DFI"
						}
					}
				}
			}
		};

		protected override CreateIndexDescriptor NewDescriptor() => new CreateIndexDescriptor(CallIsolatedValue);

		protected override Func<CreateIndexDescriptor, ICreateIndexRequest> Fluent => d => d
			.Settings(s => s
				.NumberOfReplicas(1)
				.NumberOfShards(1)
				.Similarity(si => si
					.DFI("dfi", df => df
						.IndependenceMeasure(DFIIndependenceMeasure.ChiSquared)
					)
				)
			);

		protected override CreateIndexRequest Initializer => new CreateIndexRequest(CallIsolatedValue)
		{
			Settings = new Nest.IndexSettings()
			{
				NumberOfReplicas = 1,
				NumberOfShards = 1,
				Similarity = new Similarities
				{
					{ "dfi", new DFISimilarity
						{
							IndependenceMeasure = DFIIndependenceMeasure.ChiSquared
						}
					}
				}
			}
		};

		protected override void ExpectResponse(ICreateIndexResponse response)
		{
			response.ShouldBeValid();
			response.Acknowledged.Should().BeTrue();

			var indexSettings = this.Client.GetIndexSettings(g => g.Index(CallIsolatedValue));

			indexSettings.ShouldBeValid();
			indexSettings.Indices.Should().NotBeEmpty().And.ContainKey(CallIsolatedValue);

			var settings = indexSettings.Indices[CallIsolatedValue];

			settings.Settings.NumberOfShards.Should().Be(1);
			settings.Settings.NumberOfReplicas.Should().Be(1);
			var similarities = settings.Settings.Similarity;

			similarities.Should().NotBeNull();
			similarities.Should().ContainKey("dfi").WhichValue.Should().BeOfType<DFISimilarity>();
		}
	}
}
