using System;
using System.Runtime.InteropServices;

namespace CoverityIssues
{
	public static class MarshalPtrToStructure
	{
		public static void TestMethod()
		{
			RECT rect = new RECT();
			IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RECT)));
			Marshal.StructureToPtr(rect, ptr, false);

			// 1. returned_null: "PtrToStructure" returns null (checked 0 out of 1 times).
			// Dereference null return value (NULL_RETURNS)
			// 2. null_unbox: Unboxing null object "System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof (CoverityIssues.RECT))"
			RECT rect2 = (RECT) Marshal.PtrToStructure(ptr, typeof(RECT));

			// NOTE: no memory leak reported here
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}
}
