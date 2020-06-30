using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface ISchedule {}

	public abstract class ScheduleBase : ISchedule
	{
		internal abstract void WrapInContainer(IScheduleContainer container);
	}
}
