using Newtonsoft.Json;

namespace Best
{
	public class ExtendedBounds<T>
	{
		[JsonProperty("min")]
		public T Minimum { get; set; }

		[JsonProperty("max")]
		public T Maximum { get; set; }
	}
}