using System;
using FluentAssertions;
using Tests.Framework;

namespace Tests.CommonOptions.DateMath
{
	public class DateMathTests
	{
		[U]
		public void ImplicitConversionFromNullString()
		{
			string nullString = null;
			Best.DateMath dateMath = nullString;
			dateMath.Should().BeNull();
		}

		[U]
		public void ImplicitConversionFromNullNullableDateTime()
		{
			DateTime? nullableDateTime = null;
			Best.DateMath dateMath = nullableDateTime;
			dateMath.Should().BeNull();
		}

		[U]
		public void ImplicitConversionFromDateMathString()
		{
			string nullString = "now+3d";
			Best.DateMath dateMath = nullString;
			dateMath.Should().NotBeNull();
		}

		[U]
		public void ImplicitConversionFromNullableDateTimeWithValue()
		{
			DateTime? nullableDateTime = DateTime.Now;
			Best.DateMath dateMath = nullableDateTime;
			dateMath.Should().NotBeNull();
		}
	}
}