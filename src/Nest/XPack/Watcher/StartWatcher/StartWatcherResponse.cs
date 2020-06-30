using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface IStartWatcherResponse : IAcknowledgedResponse {}

	public class StartWatcherResponse : AcknowledgedResponseBase, IStartWatcherResponse {}
}
