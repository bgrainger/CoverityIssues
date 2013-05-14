using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoverityIssues
{
	class LineCount2
	{
		public void Method(int value)
		{
			if (value < 0)
			{
				Console.WriteLine("negative");
			}
			else if (value == 0)
			{
				Console.WriteLine("positive");
			}
			else
			{
				Console.WriteLine("zero");
			}
		}
	}
}
