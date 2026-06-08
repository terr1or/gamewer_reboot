using System;
using System.Runtime.Remoting.Proxies;
using System.Threading;
using GameWer;
using GameWer.SDK.CustomSystem.Discord;

// Token: 0x02000018 RID: 24
public class GAttribute0 : ProxyAttribute
{
	// Token: 0x0600004A RID: 74 RVA: 0x00003C9C File Offset: 0x00001E9C
	internal static void smethod_0()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_187, DeProtectType.ArgValue_188);
		try
		{
			Interface.OnIncomingDiscordAccount = new Action<string>(GAttribute0.smethod_2);
			Interface.Init(DeProtectType.ArgValue_189);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_190;
			string argValue_2 = DeProtectType.ArgValue_191;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00003D0C File Offset: 0x00001F0C
	internal static void smethod_1()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_192, DeProtectType.ArgValue_193);
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

	// Token: 0x0600004C RID: 76 RVA: 0x000021BB File Offset: 0x000003BB
	private static void smethod_2(string string_1)
	{
		GClass7.smethod_0(DeProtectType.ArgValue_194, DeProtectType.ArgValue_195 + string_1);
		GAttribute0.string_0 = string_1;
	}

	// Token: 0x04000262 RID: 610
	internal static string string_0 = string.Empty;
}
