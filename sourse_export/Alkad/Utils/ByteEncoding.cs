using System;
using System.Text;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public static class ByteEncoding
{
	public static byte[] smethod_0(this Encoding encoding_0, string string_0)
	{
		return encoding_0.GetBytes(string_0 + DeProtectType.ArgValue_380);
	}
}
