using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<NeverCondition>))]
	public interface INeverCondition : ICondition {}

	public class NeverCondition : ConditionBase, INeverCondition
	{
		internal override void WrapInContainer(IConditionContainer container) => container.Never = this;
	}
}
