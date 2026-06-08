using System;
using System.Runtime.Remoting.Proxies;
using System.Threading;
using GameWer;
using GameWer.SDK.CustomSystem.Discord;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class DiscordRichPresenceManager : ProxyAttribute
{
	internal static void Start()
	{
		FileLogger.Log(DeProtectType.ArgValue_187, DeProtectType.ArgValue_188);
		try
		{
			Interface.OnIncomingDiscordAccount = new Action<string>(DiscordRichPresenceManager.smethod_2);
			Interface.Init(DeProtectType.ArgValue_189);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_190;
			string argValue_2 = DeProtectType.ArgValue_191;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void smethod_1()
	{
		FileLogger.Log(DeProtectType.ArgValue_192, DeProtectType.ArgValue_193);
		try
		{
			Thread workerThread = Interface.WorkerThread;
			if (workerThread != null)
			{
				workerThread.Abort();
			}
		}
		catch
		{
		}
	}
	private static void smethod_2(string string_1)
	{
		FileLogger.Log(DeProtectType.ArgValue_194, DeProtectType.ArgValue_195 + string_1);
		DiscordRichPresenceManager.string_0 = string_1;
	}
	internal static string string_0 = string.Empty;
}
