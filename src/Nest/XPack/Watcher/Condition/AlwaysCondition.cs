using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<AlwaysCondition>))]
	public interface IAlwaysCondition : ICondition {}

	public class AlwaysCondition : ConditionBase, IAlwaysCondition
	{
		internal override void WrapInContainer(IConditionContainer container) => container.Always = this;
	}
}
