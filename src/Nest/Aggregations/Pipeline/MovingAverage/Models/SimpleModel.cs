using Newtonsoft.Json;

namespace Best
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface ISimpleModel : IMovingAverageModel { }

	public class SimpleModel : ISimpleModel
	{
		string IMovingAverageModel.Name { get; } = "simple";
	}

	public class SimpleModelDescriptor
		: DescriptorBase<SimpleModelDescriptor, ISimpleModel>, ISimpleModel
	{
		string IMovingAverageModel.Name { get; } = "simple";
	}
}
