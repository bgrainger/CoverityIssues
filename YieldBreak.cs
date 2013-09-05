using System.Collections.Generic;
using System.IO;

namespace CoverityIssues
{
	public static class YieldBreak
	{
		public static IEnumerable<int> TestMethod()
		{
			// 1. new_resource: Created a new object of type System.IO.FileStream, which implements System.IDisposable.
			// 2. var_assign: Assigning: "$locvar0" = resource returned from "new System.IO.FileStream("C:\\temp\\tmp.tmp", Create)".
			using (new System.IO.FileStream("C:\\temp\\tmp.tmp", FileMode.Create))
			{
				// Resource leak (RESOURCE_LEAK)
				// 3. leaked_resource: Returning without closing "$locvar0" leaks the resource that it refers to.
				yield break;
			}			
		}
	}
}
