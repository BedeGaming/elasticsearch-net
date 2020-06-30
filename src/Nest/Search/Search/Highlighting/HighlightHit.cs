using System.Collections.Generic;

namespace Best
{
	public class HighlightHit
	{
		public string DocumentId { get; internal set; }
		public string Field { get; internal set; }
		public IEnumerable<string> Highlights { get; set; }
	}
}
