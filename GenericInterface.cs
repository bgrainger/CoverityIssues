using System;

namespace CoverityIssues
{
	public static class GenericInterface
	{
		public static void TestMethod()
		{
			// Explicit null dereferenced (FORWARD_NULL) / var_deref_model: Passing "null" to "Execute", which dereferences it. (The virtual call resolves to "CoverityIssues.Behavior`1::Execute(System.Object)".)
			MyBehavior.Execute(null);
		}

		// Changing "IBehavior" to "Behavior" prevents the issue being detected.
		private static IBehavior MyBehavior
		{
			get
			{
				return new Behavior(() => Console.WriteLine("test"));
			}
		}
	}

	public interface IBehavior
	{
		void Execute(object param);
	}

	public class Behavior : IBehavior
	{
		public Behavior(Action action)
		{
			m_action = action;
		}

		public void Execute(object param)
		{
			m_action();
		}

		readonly Action m_action;
	}

	public class Behavior<T> : IBehavior
	{
		public Behavior(Action<T> action)
		{
			m_action = action;
		}

		public void Execute(object param)
		{
			m_action((T) param);
		}

		readonly Action<T> m_action;
	}
}
