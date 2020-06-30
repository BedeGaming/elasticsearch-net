using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public partial interface IGetLicenseRequest
	{
	}

	public partial class GetLicenseRequest
	{
	}

	[DescriptorFor("LicenseGet")]
	public partial class GetLicenseDescriptor : IGetLicenseRequest
	{

	}
}
