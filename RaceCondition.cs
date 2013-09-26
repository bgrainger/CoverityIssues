namespace CoverityIssues
{
	public class RaceCondition
	{
		public void SafeIncrement()
		{
			lock (m_lock)
			{
				m_counter++;
				m_counter++;
			}
		}

		public void UnsafeIncrement()
		{
			// expect a "Data race condition (GUARDED_BY_VIOLATION)" here, but don't get one
			m_counter++;
			m_counter++;
		}

		readonly object m_lock = new object();
		int m_counter;
	}
}
