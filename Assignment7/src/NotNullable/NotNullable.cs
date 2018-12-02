using System;

namespace NotNullable
{
	/**
	 My implementation uses a value type, with a constraint that the generic type have a default constructor.

		When it works:
		- NotNullable(T) is passed a non null value.
		- NotNullable(T) is passed a null value but the generic type has a default constructor that does not return null.

		Caveats:
		- Cannot use NotNullable<T> with types that do not implement a default constructor, for example `string`.
			Possible solution: wrap type that doesn't have a default constructor in a class that does. See: `StringWrapper`.
		- Types that implement a default constructor that sets the value to null. See: `System.Nullable<>`.
	 */

	public class NotNullable<T>
		where T : new()
	{
		private T _value;
		public T Value
		{
			get => _value;
			set
			{
				if (value != null)
					_value = value;
				else if (new T() != null)
					_value = new T();
				else // if default constructor of type T creates a null object, throw an ArgumentException rather than allowing Value to be null.
					throw new ArgumentException("Both argument is null and default constructor returns null. " +
					                            "Try wrapping class with class who's default constructor does not return null.");
			}
		}

		public NotNullable(T value)
		{
			Value = value;
		}
	}
}
