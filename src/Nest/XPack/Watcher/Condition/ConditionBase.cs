using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface ICondition {}

	public abstract class ConditionBase : ICondition
	{
		internal abstract void WrapInContainer(IConditionContainer container);
	}
}
