using System;

namespace CoverityIssues
{
	public static class StringIsNullOrEmpty
	{
		public static void TestMethod()
		{
			// error FORWARD_NULL (deref_while_null: Dereferencing "null" in "CoverityIssues.StringIsNullOrEmpty.HasLength(System.String)")
			Console.WriteLine(HasLength(null));
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool HasLength(string value)
		{
			// need to call extension method here; no defect is reported when calling '(string.IsNullOrEmpty(value))' directly
			if (value.IsNullOrEmpty())
				return false;

			// deref: Dereferencing "value".
			return value.Length != 0;
		}
	}
}
