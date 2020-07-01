// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elasticsearch.Net;
using Elasticsearch.Net.Utf8Json;
using Elasticsearch.Net.Specification.SqlApi;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	///<summary>Descriptor for ClearCursor <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-pagination.html</para></summary>
	public partial class ClearSqlCursorDescriptor : RequestDescriptorBase<ClearSqlCursorDescriptor, ClearSqlCursorRequestParameters, IClearSqlCursorRequest>, IClearSqlCursorRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SqlClearCursor;
	// values part of the url path
	// Request parameters
	}

	///<summary>Descriptor for Query <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-rest-overview.html</para></summary>
	public partial class QuerySqlDescriptor : RequestDescriptorBase<QuerySqlDescriptor, QuerySqlRequestParameters, IQuerySqlRequest>, IQuerySqlRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SqlQuery;
		// values part of the url path
		// Request parameters
		///<summary>a short version of the Accept header, e.g. json, yaml</summary>
		public QuerySqlDescriptor Format(string format) => Qs("format", format);
	}

	///<summary>Descriptor for Translate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/sql-translate.html</para></summary>
	public partial class TranslateSqlDescriptor : RequestDescriptorBase<TranslateSqlDescriptor, TranslateSqlRequestParameters, ITranslateSqlRequest>, ITranslateSqlRequest
	{
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SqlTranslate;
	// values part of the url path
	// Request parameters
	}
}