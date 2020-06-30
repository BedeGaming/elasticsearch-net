using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface IStopWatcherResponse : IAcknowledgedResponse {}

	public class StopWatcherResponse : AcknowledgedResponseBase, IStopWatcherResponse {}
}
