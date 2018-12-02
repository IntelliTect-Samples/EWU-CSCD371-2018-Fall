using System;

namespace MyDisposable
{
	public class MyDisposable : IDisposable
	{
		private bool _disposed;
		public static int Instances { get; set; }
		public string Name { get; set; }

		public MyDisposable(string name)
		{
			Name = name ?? throw new ArgumentNullException();
			Instances++;
			_disposed = false;
		}

		public void Dispose()
		{
			if (Instances > 0)
				Instances--;

			if (Name != null)
				Name = null;

			_disposed = true;

			GC.SuppressFinalize(this);
		}

		~MyDisposable()
		{
			Dispose();
		}

		public override string ToString()
		{
			if (_disposed)
				throw new ObjectDisposedException("Object already disposed");

			return $"There are {Instances} instances of MyDisposable! This MyDisposable has the name {Name}.";
		}
	}
}
