using System;
/// <summary>Represents a GameWer-specific runtime failure.</summary>
[Serializable]
public class GameWerException : Exception
{
	public GameWerException(string message) : base(message)
	{
	}
}
