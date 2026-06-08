using System;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class UnixClock
{
	internal static DateTime smethod_0(double double_0)
	{
		DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		result = result.AddSeconds(double_0).ToLocalTime();
		return result;
	}
}
