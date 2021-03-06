﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// Checks each suggestion against the specified query to prune suggestions
	/// for which no matching docs exist in the index.
	/// </summary>
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<PhraseSuggestCollate>))]
	public interface IPhraseSuggestCollate
	{
		/// <summary>
		/// The collate query to run.
		/// </summary>
		/// <remarks>
		/// Query parameters should be specified using <see cref="Params"/>
		/// </remarks>
		[JsonProperty("query")]
		IScript Query { get; set; }

		/// <summary>
		/// Controls if all phrase suggestions will be returned. When set to <c>true</c>, the suggestions will have
		/// an additional option collate_match, which will be <c>true</c> if matching documents for the phrase was found,
		/// <c>false</c> otherwise. The default value for <see cref="Prune"/> is <c>false</c>.
		/// </summary>
		[JsonProperty("prune")]
		bool? Prune { get; set; }

		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		[JsonProperty("params")]
		IDictionary<string, object> Params { get; set; }
	}

	/// <inheritdoc />
	public class PhraseSuggestCollate : IPhraseSuggestCollate
	{
		private IScript _query;

		/// <inheritdoc />
		public IScript Query
		{
			get => _query;
			set
			{
				_query = value;
				if (_query != null) Params = _query.Params;
			}
		}

		/// <inheritdoc />
		public bool? Prune { get; set; }

		/// <inheritdoc />
		public IDictionary<string, object> Params { get; set; }
	}

	public class PhraseSuggestCollateDescriptor<T> : DescriptorBase<PhraseSuggestCollateDescriptor<T>, IPhraseSuggestCollate>, IPhraseSuggestCollate
		where T : class
	{
		IScript IPhraseSuggestCollate.Query { get; set; }
		IDictionary<string, object> IPhraseSuggestCollate.Params { get; set; }
		bool? IPhraseSuggestCollate.Prune { get; set; }
		/// <summary>
		/// The collate query to run.
		/// </summary>
		/// <remarks>
		/// Query parameters should be specified using <see cref="Params(IDictionary&lt;string, object&gt;)"/> or
		/// Params(Func&lt;FluentDictionary&lt;string, object&gt;, FluentDictionary&lt;string, object&gt;&gt;)
		/// </remarks>
		public PhraseSuggestCollateDescriptor<T> Query(string script) => Assign(a => a.Query = (InlineScript)script);

		/// <summary>
		/// The collate query to run.
		/// </summary>
		/// <remarks>
		/// Query parameters should be specified using <see cref="Params(IDictionary&lt;string, object&gt;)"/> or
		/// Params(Func&lt;FluentDictionary&lt;string, object&gt;, FluentDictionary&lt;string, object&gt;&gt;)
		/// </remarks>
		public PhraseSuggestCollateDescriptor<T> Query(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(a => a.Query = scriptSelector?.Invoke(new ScriptDescriptor()));

		/// <summary>
		/// Controls if all phrase suggestions will be returned. When set to <c>true</c>, the suggestions will have
		/// an additional option collate_match, which will be <c>true</c> if matching documents for the phrase was found,
		/// <c>false</c> otherwise. The default value for <see cref="Prune"/> is <c>false</c>.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Prune(bool? prune = true) => Assign(a => a.Prune = prune);

		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Params(IDictionary<string, object> paramsDictionary) => Assign(a => a.Params = paramsDictionary);

		/// <summary>
		/// The parameters for the query. the suggestion value will be added to the variables you specify.
		/// </summary>
		public PhraseSuggestCollateDescriptor<T> Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramsDictionary) =>
			Assign(a => a.Params = paramsDictionary(new FluentDictionary<string, object>()));
	}
}
