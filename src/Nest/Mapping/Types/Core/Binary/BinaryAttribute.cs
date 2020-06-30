using Newtonsoft.Json;

namespace Best
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class BinaryAttribute : ElasticsearchPropertyAttributeBase, IBinaryProperty
	{
		public BinaryAttribute() : base("binary") { }
	}	
}
