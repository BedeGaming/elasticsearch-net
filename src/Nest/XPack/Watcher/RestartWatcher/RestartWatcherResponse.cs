using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface IRestartWatcherResponse : IAcknowledgedResponse {}

	public class RestartWatcherResponse : AcknowledgedResponseBase, IRestartWatcherResponse {}
}
