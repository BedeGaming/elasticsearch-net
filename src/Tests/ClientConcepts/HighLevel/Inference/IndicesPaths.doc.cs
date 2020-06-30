﻿using Elasticsearch.Net;
using FluentAssertions;
using Best;
using Tests.Framework;
using Tests.Framework.MockData;

namespace Tests.ClientConcepts.HighLevel.Inference
{
	public class IndicesPaths
	{
		/**[[indices-paths]]
		* === Indices paths
		*
		* Some APIs in Elasticsearch take an index name, a collection of index names,
		* or the special `_all` marker (used to specify all indices), in the URI path of the request, to specify the indices that
		* the request should execute against.
		*
		* In NEST, these index names can be specified using the `Indices` type.
		*
		* ==== Implicit Conversion
		*
		* To make working with `Indices` easier, several types implicitly convert to it:
		*
		* - `string`
		* - comma separated `string`
		* - `string` array
		* - a CLR type, <<index-name-inference, where a default index name or index name for the type has been specified on `ConnectionSettings`>>
		* - `IndexName`
		* - `IndexName` array
		*
		* Here are some examples of how implicit conversions can be used to specify index names
		*/
		[U] public void ImplicitConversions()
		{
			Best.Indices singleIndexFromString = "name";
			Best.Indices multipleIndicesFromString = "name1, name2";
			Best.Indices multipleIndicesFromStringArray = new [] { "name1", "name2" };
			Best.Indices allFromString = "_all";

			Best.Indices allWithOthersFromString = "_all, name2"; //<1> `_all` will override any specific index names here

			Best.Indices singleIndexFromType = typeof(Project); //<2> The `Project` type has been mapped to a specific index name using <<index-name-type-mapping,`.InferMappingFor<Project>`>>

			Best.Indices singleIndexFromIndexName = IndexName.From<Project>();

			singleIndexFromString.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(1).And.Contain("name")
			);

			multipleIndicesFromString.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(2).And.Contain("name2")
			);

			allFromString.Match(
				all => all.Should().NotBeNull(),
				many => many.Indices.Should().BeNull()
			);

			allWithOthersFromString.Match(
				all => all.Should().NotBeNull(),
				many => many.Indices.Should().BeNull()
			);

			multipleIndicesFromStringArray.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(2).And.Contain("name2")
			);

			singleIndexFromType.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(1).And.Contain(typeof(Project))
			);

			singleIndexFromIndexName.Match(
				all => all.Should().BeNull(),
				many => many.Indices.Should().HaveCount(1).And.Contain(typeof(Project))
			);
		}

		/**
		* [[nest-indices]]
		*==== using Best.Indices methods
		* To make creating `IndexName` or `Indices` instances easier, `Best.Indices` also contains several static methods
		* that can be used to construct them.
		*
		*===== Single index
		*
		* A single index can be specified using a CLR type or a string, and the `.Index()` method.
		*
		* [TIP]
		* ====
		* This example uses the static import `using static Best.Indices;` in the using directives to shorthand `Best.Indices.Index()`
		* to simply `Index()`. Be sure to include this static import if copying any of these examples.
		* ====
		*/
		[U]
		public void UsingStaticPropertyField()
		{
			//hide
			var client = TestClient.Default;

			var singleString = Best.Indices.Index("name1"); // <1> specifying a single index using a string
			var singleTyped = Best.Indices.Index<Project>(); //<2> specifying a single index using a type

			ISearchRequest singleStringRequest = new SearchDescriptor<Project>().Index(singleString);
			ISearchRequest singleTypedRequest = new SearchDescriptor<Project>().Index(singleTyped);

			((IUrlParameter)singleStringRequest.Index).GetString(client.ConnectionSettings).Should().Be("name1");
			((IUrlParameter)singleTypedRequest.Index).GetString(client.ConnectionSettings).Should().Be("project");

			var invalidSingleString = Best.Indices.Index("name1, name2"); //<3> an **invalid** single index name
		}

		/**===== Multiple indices
		*
		* Similarly to a single index, multiple indices can be specified using multiple CLR types or multiple strings
		*/
		[U]
		public void MultipleIndices()
		{
			//hide
			var client = TestClient.Default;

			var manyStrings = Best.Indices.Index("name1", "name2"); //<1> specifying multiple indices using strings
			var manyTypes = Best.Indices.Index<Project>().And<Developer>(); //<2> specifying multiple indices using types

			ISearchRequest manyStringRequest = new SearchDescriptor<Project>().Index(manyStrings);
			ISearchRequest manyTypedRequest = new SearchDescriptor<Project>().Index(manyTypes);

			((IUrlParameter)manyStringRequest.Index).GetString(client.ConnectionSettings).Should().Be("name1,name2");
			((IUrlParameter)manyTypedRequest.Index).GetString(client.ConnectionSettings).Should().Be("project,devs"); // <3> The index names here come from the Connection Settings passed to `TestClient`. See the documentation on <<index-name-inference, Index Name Inference>> for more details.

			manyStringRequest = new SearchDescriptor<Project>().Index(new[] { "name1", "name2" });
			((IUrlParameter)manyStringRequest.Index).GetString(client.ConnectionSettings).Should().Be("name1,name2");

			manyStringRequest = new SearchDescriptor<Project>().Type(new[] { "name1", "name2" });
			((IUrlParameter)manyStringRequest.Type).GetString(client.ConnectionSettings).Should().Be("name1,name2");
		}

		/**===== All Indices
		*
		* Elasticsearch allows searching across multiple indices using the special `_all` marker.
		*
		* NEST exposes the `_all` marker with `Indices.All` and `Indices.AllIndices`. Why expose it in two ways, you ask?
		* Well, you may be using both `Best.Indices` and `Best.Types` in the same file and you may also be using C#6
		* static imports too; in this scenario, the `All` property becomes ambiguous between `Indices.All` and `Types.All`, so the
		* `_all` marker for indices is exposed as `Indices.AllIndices`, to alleviate this ambiguity
		*/
		[U]
		public void IndicesAllAndAllIndicesSpecifiedWhenUsingStaticUsingDirective()
		{
			//hide
			var client = TestClient.Default;

			var indicesAll = Best.Indices.All;
			var allIndices = Best.Indices.AllIndices;

			ISearchRequest indicesAllRequest = new SearchDescriptor<Project>().Index(indicesAll);
			ISearchRequest allIndicesRequest = new SearchDescriptor<Project>().Index(allIndices);

			((IUrlParameter)indicesAllRequest.Index).GetString(client.ConnectionSettings).Should().Be("_all");
			((IUrlParameter)allIndicesRequest.Index).GetString(client.ConnectionSettings).Should().Be("_all");
		}

	}
}
