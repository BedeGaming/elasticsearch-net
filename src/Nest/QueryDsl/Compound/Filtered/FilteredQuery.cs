﻿using System;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<FilteredQueryDescriptor<object>>))]
	[Obsolete("Use the bool query instead with a must clause for the query and a filter clause for the filter.")]
	public interface IFilteredQuery : IQuery
	{
		[JsonProperty(PropertyName = "query")]
		QueryContainer Query { get; set; }

		[JsonProperty(PropertyName = "filter")]
		QueryContainer Filter { get; set; }
	}

	[Obsolete("Use the bool query instead with a must clause for the query and a filter clause for the filter.")]
	public class FilteredQuery : QueryBase, IFilteredQuery
	{
		protected override bool Conditionless => IsConditionless(this);
		public QueryContainer Query { get; set; }
		public QueryContainer Filter { get; set; }

		internal override void InternalWrapInContainer(IQueryContainer c) => c.Filtered = this;

		internal static bool IsConditionless(IFilteredQuery q) => q.Query.NotWritable() && q.Filter.NotWritable();
	}

	[Obsolete("Use the bool query instead with a must clause for the query and a filter clause for the filter.")]
	public class FilteredQueryDescriptor<T>
		: QueryDescriptorBase<FilteredQueryDescriptor<T>, IFilteredQuery>
		, IFilteredQuery where T : class
	{
		protected override bool Conditionless => FilteredQuery.IsConditionless(this);
		QueryContainer IFilteredQuery.Query { get; set; }
		QueryContainer IFilteredQuery.Filter { get; set; }

		public FilteredQueryDescriptor<T> Query(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(a => a.Query = selector?.Invoke(new QueryContainerDescriptor<T>()));

		public FilteredQueryDescriptor<T> Filter(Func<QueryContainerDescriptor<T>, QueryContainer> selector) =>
			Assign(a => a.Filter = selector?.Invoke(new QueryContainerDescriptor<T>()));
	}
}
