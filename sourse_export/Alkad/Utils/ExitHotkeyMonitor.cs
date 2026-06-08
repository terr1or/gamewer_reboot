using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ExitHotkeyMonitor
{
	internal static void Start()
	{
		FileLogger.Log(DeProtectType.ArgValue_196, DeProtectType.ArgValue_197);
		ScreenshotHotkeyMonitor.action_0 = new Action<Keys>(ExitHotkeyMonitor.smethod_2);
		ScreenshotHotkeyMonitor.Start();
	}
	internal static void smethod_1()
	{
		FileLogger.Log(DeProtectType.ArgValue_198, DeProtectType.ArgValue_199);
		try
		{
			Thread thread_ = ScreenshotHotkeyMonitor.thread_0;
			if (thread_ != null)
			{
				thread_.Abort();
			}
		}
		catch
		{
		}
	}
	private static void smethod_2(Keys keys_0)
	{
		RuntimeGuard.EnqueueOnMainLoop(new Action(ExitHotkeyMonitor.Class6.class6_0.method_0));
	}
	[CompilerGenerated]
	[Serializable]
	private sealed class Class6
	{
		internal void method_0()
		{
		}
		public static readonly ExitHotkeyMonitor.Class6 class6_0 = new ExitHotkeyMonitor.Class6();
		public static Action action_0;
	}
}
