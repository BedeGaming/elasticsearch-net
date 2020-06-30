using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Best
{
	public partial interface IDeleteLicenseRequest
	{
	}

	public partial class DeleteLicenseRequest
	{
	}

	[DescriptorFor("LicenseDelete")]
	public partial class DeleteLicenseDescriptor : IDeleteLicenseRequest
	{

	}
}
