using System;
using System.IO;

namespace CoverityIssues
{
	public static class ReturnScope
	{
		public static IDisposable TestMethod()
		{
			// 1. new_resource: Created a new object of type System.IO.FileStream, which implements System.IDisposable.
			// 2. var_assign: Assigning: "stream" = resource returned from "new System.IO.FileStream("C:\\temp\\tmp.tmp", Create)".
			Stream stream = new FileStream(@"C:\temp\tmp.tmp", FileMode.Create);
			// 3. leaked_resource: Variable "stream" going out of scope leaks the resource it refers to.
			return new Scope(() => stream.Dispose());

			// NOTE: issue doesn't occur for following code:
			// return new Scope(stream.Dispose);
		}
	}

	public struct Scope : IDisposable
	{
		public Scope(Action action)
		{
			m_action = action;
		}

		public void Dispose()
		{
			if (m_action != null)
				m_action();
		}

		readonly Action m_action;
	}
}
