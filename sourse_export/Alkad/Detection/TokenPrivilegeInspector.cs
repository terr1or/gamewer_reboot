using System;
using System.Diagnostics;
using GameWer;
using Steamworks;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class TokenPrivilegeInspector
{
	static TokenPrivilegeInspector()
	{
		SteamClient.Init(uint.Parse(DeProtectType.ArgValue_401), true);
		TokenPrivilegeInspector.ulong_0 += SteamClient.SteamId;
	}
	internal static bool smethod_0()
	{
		try
		{
			return Process.GetProcessesByName(DeProtectType.ArgValue_402).Length != int.Parse(DeProtectType.ArgValue_403);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_404;
			string argValue_2 = DeProtectType.ArgValue_405;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		return false;
	}
	internal static ulong smethod_1()
	{
		return TokenPrivilegeInspector.ulong_0 - 2147483647UL;
	}
	private static string string_0 = null;
	private static bool bool_0 = false;
	private static ulong ulong_0 = 2147483647UL;
}
