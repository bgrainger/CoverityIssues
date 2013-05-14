namespace CoverityIssues
{
	class NullableTest
	{
		public void Coalesce(object value)
		{
			int number = (value as int?) ?? 0;
		}
	}
}
