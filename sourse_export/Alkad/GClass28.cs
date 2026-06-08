using System;
using System.Diagnostics;
using GameWer;
using Steamworks;

// Token: 0x0200003A RID: 58
public class GClass28
{
	// Token: 0x060000E8 RID: 232 RVA: 0x00006108 File Offset: 0x00004308
	static GClass28()
	{
		SteamClient.Init(uint.Parse(DeProtectType.ArgValue_401), true);
		GClass28.ulong_0 += SteamClient.SteamId;
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00006154 File Offset: 0x00004354
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
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		return false;
	}

	// Token: 0x060000EA RID: 234 RVA: 0x000061B8 File Offset: 0x000043B8
	internal static ulong smethod_1()
	{
		return GClass28.ulong_0 - 2147483647UL;
	}

	// Token: 0x040002B6 RID: 694
	private static string string_0 = null;

	// Token: 0x040002B7 RID: 695
	private static bool bool_0 = false;

	// Token: 0x040002B8 RID: 696
	private static ulong ulong_0 = 2147483647UL;
}
