using System;
using System.Runtime.InteropServices;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
internal static class NativeCallGuard
{
	public static void ThrowIfFailed(bool shouldThrow, string messageFormat, params object[] formatArguments)
	{
		if (shouldThrow)
		{
			string arg = string.Format(messageFormat, formatArguments);
			string arg2 = string.Format(DeProtectType.ArgValue_4, Marshal.GetLastWin32Error());
			string message = string.Format(DeProtectType.ArgValue_5, arg, arg2);
			throw new GameWerException(message);
		}
	}
}
