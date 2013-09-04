using System;
using System.Threading;

namespace CoverityIssues
{
	public static class InterlockedExchange
	{
		public static void TestMethod()
		{
			s_object = new object();
			TestMethod(s_object);
		}

		public static void TestMethod(object existing)
		{
			object old = Interlocked.Exchange(ref s_object, null);
			if (old == existing)
				Console.WriteLine(old.ToString());
		}

		static object s_object;
	}
}
