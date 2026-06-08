using System;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using GameWer;
using GameWer.SDK;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class IsolatedBootstrapper
{
	private static PermissionSet smethod_0()
	{
		PermissionSet permissionSet = new PermissionSet(PermissionState.None);
		permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags));
		return permissionSet;
	}
	private static AppDomainSetup smethod_1()
	{
		return new AppDomainSetup
		{
			ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
		};
	}
	private static void smethod_2()
	{
		try
		{
			Type typeFromHandle = typeof(GameWerUI);
			IsolatedBootstrapper.gameWerUI_0 = (GameWerUI)IsolatedBootstrapper.appDomain_0.CreateInstanceAndUnwrap(typeFromHandle.Assembly.FullName, typeFromHandle.FullName);
			IsolatedBootstrapper.igameWerForm_0 = new GameWerProxy(IsolatedBootstrapper.gameWerUI_0, IsolatedBootstrapper.appDomain_0);
			IsolatedBootstrapper.gameWerUI_0.InitUI();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_301;
			string argValue_2 = DeProtectType.ArgValue_302;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		FileLogger.Log(DeProtectType.ArgValue_303, DeProtectType.ArgValue_304);
		RuntimeGuard.ExitApplication();
	}
	internal static void Start()
	{
		FileLogger.Log(DeProtectType.ArgValue_305, DeProtectType.ArgValue_306);
		try
		{
			IsolatedBootstrapper.smethod_0();
			AppDomainSetup info = IsolatedBootstrapper.smethod_1();
			IsolatedBootstrapper.appDomain_0 = AppDomain.CreateDomain(DeProtectType.ArgValue_307, null, info);
			IsolatedBootstrapper.thread_0 = new Thread(new ThreadStart(IsolatedBootstrapper.smethod_2));
			IsolatedBootstrapper.thread_0.SetApartmentState(ApartmentState.STA);
			IsolatedBootstrapper.thread_0.Start();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_308;
			string argValue_2 = DeProtectType.ArgValue_309;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			RuntimeGuard.ExitApplication();
		}
	}
	internal static void smethod_4()
	{
		FileLogger.Log(DeProtectType.ArgValue_310, DeProtectType.ArgValue_311);
		try
		{
			Thread thread = IsolatedBootstrapper.thread_0;
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
			AppDomain.Unload(IsolatedBootstrapper.appDomain_0);
		}
		catch
		{
		}
	}
	internal static Thread thread_0;
	internal static AppDomain appDomain_0 = null;
	internal static GameWerUI gameWerUI_0;
	internal static IGameWerForm igameWerForm_0;
}
