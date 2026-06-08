using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ScreenshotHotkeyMonitor
{
	internal static void smethod_0()
	{
		if (!ScreenshotHotkeyMonitor.bool_0)
		{
			ScreenshotHotkeyMonitor.bool_0 = true;
			ScreenshotHotkeyMonitor.thread_0 = new Thread(new ThreadStart(ScreenshotHotkeyMonitor.smethod_1));
			ScreenshotHotkeyMonitor.thread_0.IsBackground = true;
			ScreenshotHotkeyMonitor.thread_0.Priority = ThreadPriority.Highest;
			ScreenshotHotkeyMonitor.thread_0.Start();
		}
	}
	private static void smethod_1()
	{
		while (RuntimeGuard.bool_0)
		{
			try
			{
				ScreenshotHotkeyMonitor.smethod_2();
			}
			catch
			{
			}
			Thread.Sleep(int.Parse(DeProtectType.ArgValue_475));
		}
	}
	private static void smethod_2()
	{
		ScreenshotHotkeyMonitor.smethod_3(Keys.Insert);
	}
	private static void smethod_3(Keys keys_0)
	{
		bool flag;
		if ((flag = (KeyboardNativeMethods.GetAsyncKeyState((int)keys_0) != int.Parse(DeProtectType.ArgValue_476))) && !ScreenshotHotkeyMonitor.hashSet_0.Contains(keys_0))
		{
			ScreenshotHotkeyMonitor.hashSet_0.Add(keys_0);
			try
			{
				Action<Keys> action = ScreenshotHotkeyMonitor.action_0;
				if (action != null)
				{
					action(keys_0);
				}
				return;
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_477;
				string argValue_2 = DeProtectType.ArgValue_478;
				Exception ex2 = ex;
				FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
				return;
			}
		}
		if (!flag && ScreenshotHotkeyMonitor.hashSet_0.Contains(keys_0))
		{
			ScreenshotHotkeyMonitor.hashSet_0.Remove(keys_0);
		}
	}
	internal static Thread thread_0;
	private static bool bool_0 = false;
	private static HashSet<Keys> hashSet_0 = new HashSet<Keys>();
	internal static Action<Keys> action_0;
}
