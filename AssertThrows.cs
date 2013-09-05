using System;
using NUnit.Framework;

namespace CoverityIssues
{
	[TestFixture]
	public class AssertThrows
	{
		[Test]
		public void AssertThrowsArgumentNullException()
		{
			// Explicit null dereferenced (FORWARD_NULL)
			// var_deref_model: Passing "null" to "ThrowArgumentNullException", which dereferences it.
			Assert.Throws<ArgumentNullException>(() => ThrowArgumentNullException(null));
		}

		void ThrowArgumentNullException(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");
		}
	}
}
