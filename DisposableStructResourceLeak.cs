using System;
using System.Runtime.InteropServices;

namespace CoverityIssues
{
	public static class DisposableStructResourceLeak
	{
		public static void Method()
		{
			using (DisposableStruct ds = new DisposableStruct(IntPtr.Zero))
			{
			}
		}

		private struct DisposableStruct : IDisposable
		{
			public DisposableStruct(IntPtr ptr)
			{
				m_ptr = ptr;
			}

			public void Dispose()
			{
				if (m_ptr != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(m_ptr);
					m_ptr = IntPtr.Zero;
				}
			}

			IntPtr m_ptr;
		}
	}
}
