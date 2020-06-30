using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public interface IDeleteLicenseResponse : IResponse
	{
	}

	public class DeleteLicenseResponse : ResponseBase, IDeleteLicenseResponse
	{
	}
}
