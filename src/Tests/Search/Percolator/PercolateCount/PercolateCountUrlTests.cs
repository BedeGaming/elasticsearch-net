﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Search.Percolator.PercolateCount
{
	public class CountPercolateUrlTests
	{
		[U] public async Task Urls()
		{
			var id = "name-of-doc";
			var index = "indexx";
			await POST($"/{index}/project/{id}/_percolate/count")
				.Fluent(c=>c.PercolateCount<Project>(s=>s.Id(id).Index(index)))
				.Request(c=>c.PercolateCount(new PercolateCountRequest<Project>(index, typeof(Project), id)))
				.FluentAsync(c=>c.PercolateCountAsync<Project>(s=> s.Id(id).Index(index)))
				.RequestAsync(c=>c.PercolateCountAsync(new PercolateCountRequest<Project>(index, typeof(Project), id)))
				;

			await POST($"/project/project/{id}/_percolate/count")
				.Fluent(c=>c.PercolateCount<Project>(s=>s.Id(id)))
				.Request(c=>c.PercolateCount(new PercolateCountRequest<Project>(id)))
				.FluentAsync(c=>c.PercolateCountAsync<Project>(s=>s.Id(id)))
				.RequestAsync(c=>c.PercolateCountAsync(new PercolateCountRequest<Project>(id)))
				;

			await POST($"/{index}/project/_percolate/count")
				.Fluent(c=>c.PercolateCount<Project>(s=>s.Index(index)))
				.Request(c=>c.PercolateCount(new PercolateCountRequest<Project>(index, typeof(Project))))
				.FluentAsync(c=>c.PercolateCountAsync<Project>(s=> s.Index(index)))
				.RequestAsync(c=>c.PercolateCountAsync(new PercolateCountRequest<Project>(index, typeof(Project))))
				;

			await POST($"/project/project/_percolate/count")
				.Fluent(c=>c.PercolateCount<Project>(s=>s))
				.Request(c=>c.PercolateCount(new PercolateCountRequest<Project>()))
				.FluentAsync(c=>c.PercolateCountAsync<Project>(s=>s))
				.RequestAsync(c=>c.PercolateCountAsync(new PercolateCountRequest<Project>()))
				;
		}
	}
}
