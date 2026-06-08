using System;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using GameWer;
using GameWer.SDK;

// Token: 0x02000024 RID: 36
public class GClass10
{
	// Token: 0x06000087 RID: 135 RVA: 0x000050C0 File Offset: 0x000032C0
	private static PermissionSet smethod_0()
	{
		PermissionSet permissionSet = new PermissionSet(PermissionState.None);
		permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags));
		return permissionSet;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000050E8 File Offset: 0x000032E8
	private static AppDomainSetup smethod_1()
	{
		return new AppDomainSetup
		{
			ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
		};
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00005114 File Offset: 0x00003314
	private static void smethod_2()
	{
		try
		{
			Type typeFromHandle = typeof(GameWerUI);
			GClass10.gameWerUI_0 = (GameWerUI)GClass10.appDomain_0.CreateInstanceAndUnwrap(typeFromHandle.Assembly.FullName, typeFromHandle.FullName);
			GClass10.igameWerForm_0 = new GameWerProxy(GClass10.gameWerUI_0, GClass10.appDomain_0);
			GClass10.gameWerUI_0.InitUI();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_301;
			string argValue_2 = DeProtectType.ArgValue_302;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		GClass7.smethod_0(DeProtectType.ArgValue_303, DeProtectType.ArgValue_304);
		GClass4.smethod_11();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000051BC File Offset: 0x000033BC
	internal static void smethod_3()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_305, DeProtectType.ArgValue_306);
		try
		{
			GClass10.smethod_0();
			AppDomainSetup info = GClass10.smethod_1();
			GClass10.appDomain_0 = AppDomain.CreateDomain(DeProtectType.ArgValue_307, null, info);
			GClass10.thread_0 = new Thread(new ThreadStart(GClass10.smethod_2));
			GClass10.thread_0.SetApartmentState(ApartmentState.STA);
			GClass10.thread_0.Start();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_308;
			string argValue_2 = DeProtectType.ArgValue_309;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			GClass4.smethod_11();
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0000525C File Offset: 0x0000345C
	internal static void smethod_4()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_310, DeProtectType.ArgValue_311);
		try
		{
			Thread thread = GClass10.thread_0;
			if (thread != null)
			{
				thread.Abort();
			}
		}
		catch
		{
		}
		try
		{
			AppDomain.Unload(GClass10.appDomain_0);
		}
		catch
		{
		}
	}

	// Token: 0x04000277 RID: 631
	internal static Thread thread_0;

	// Token: 0x04000278 RID: 632
	internal static AppDomain appDomain_0 = null;

	// Token: 0x04000279 RID: 633
	internal static GameWerUI gameWerUI_0;

	// Token: 0x0400027A RID: 634
	internal static IGameWerForm igameWerForm_0;
}
