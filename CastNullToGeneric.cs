using System;

namespace CoverityIssues
{
	public sealed class Wrapper<T>
		where T : class
	{
		public Wrapper(Action<T> action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			m_action = action;
		}

		public void Invoke(object parameter)
		{
			m_action((T) parameter);
		}

		readonly Action<T> m_action;
	}
	
	class CastNullToGeneric
	{
		public static Wrapper<string> Create()
		{
			return new Wrapper<string>(Console.WriteLine);
		}

		public static void Invoke<T>(Wrapper<T> wrapper)
			where T : class
		{
			if (wrapper != null)
			{
				object objParameter = null;
				wrapper.Invoke(objParameter);
			}
		}
	}
}
