using System;

namespace CoverityIssues
{
	public static class ResourceManagerNullReturn
	{
		public static void TestMethod()
		{
			// 1. returned_null: "TestString.get" returns null (checked 0 out of 1 times).
			// Dereference null return value (NULL_RETURNS)
			// 2. dereference: Dereferencing a pointer that might be null "CoverityIssues.Resources.TestString" when calling "PrintLength"
			PrintLength(Resources.TestString);
		}

		public static void PrintLength(string s)
		{
			Console.WriteLine(s.Length);
		}
	}
}
