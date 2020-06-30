using Newtonsoft.Json;

namespace Best
{
	[JsonObject]
	public interface IInput {}

	public abstract class InputBase : IInput
	{
		internal abstract void WrapInContainer(IInputContainer container);
	}
}
