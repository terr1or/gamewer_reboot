using System;
using System.IO;
using System.Threading;

namespace GameWer
{
	/// <summary>
	/// Provides the class component for the GameWer client.
	/// </summary>
internal static class Bootstrap
	{
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				DeProtectType.DeProtect(args);
				Bootstrap.Initialize();
			}
			catch (Exception ex)
			{
				string path = "./output.log";
				string str = string.Format("\n[{0}] [Main]: Exception: ", DateTime.Now);
				Exception ex2 = ex;
				File.AppendAllText(path, str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
		private static void Initialize()
		{
			FileLogger.Log(DeProtectType.ArgValue_25, DeProtectType.ArgValue_26);
			Bootstrap.singleInstanceMutex = new Mutex(true, DeProtectType.ArgValue_27);
			if (Bootstrap.singleInstanceMutex.WaitOne(TimeSpan.Zero, true) || ClientRuntimeState.string_1 == DeProtectType.ArgValue_28)
			{
				RuntimeGuard.Initialize();
				IsolatedBootstrapper.Start();
				ModuleMonitor.Start();
				ExitHotkeyMonitor.Start();
				DiscordRichPresenceManager.Start();
				ServerWebSocketClient.Initialize();
				RuntimeGuard.NotifyApplicationReady();
				RuntimeGuard.RunMainLoop();
				Bootstrap.singleInstanceMutex.ReleaseMutex();
				FileLogger.Log(DeProtectType.ArgValue_29, DeProtectType.ArgValue_30);
			}
			else
			{
				FileLogger.Log(DeProtectType.ArgValue_31, DeProtectType.ArgValue_32);
			}
		}
		private static Mutex singleInstanceMutex;
	}
}
