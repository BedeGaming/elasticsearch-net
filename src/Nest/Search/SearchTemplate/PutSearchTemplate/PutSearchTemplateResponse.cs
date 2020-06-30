using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best
{
	public interface IPutSearchTemplateResponse : IAcknowledgedResponse { }

	public class PutSearchTemplateResponse : AcknowledgedResponseBase, IPutSearchTemplateResponse { }
}
