namespace NotNullable.Tests
{
	class StringWrapper
	{
		public string String { get; private set; }

		public StringWrapper()
		{
			String = "";
		}

		public StringWrapper(string str)
		{
			if (str != null)
				String = str;
			else
				String = "";
		}
	}
}
