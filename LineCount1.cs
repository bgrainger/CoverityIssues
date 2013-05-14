using System;

namespace CoverityIssues
{
	class LineCount1
	{
		public void Method(int value) {
			if (value < 0) {
				Console.WriteLine("negative");
			} else if (value == 0) {
				Console.WriteLine("positive");
			} else {
				Console.WriteLine("zero");
			}
		}
	}
}
