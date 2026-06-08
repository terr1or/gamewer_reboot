using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class RuntimeGuard
{
	// (get) Token: 0x06000039 RID: 57 RVA: 0x00002149 File Offset: 0x00000349
	internal static DateTime DateTime_0 { get; } = DateTime.Now;
	internal static void Initialize()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_86, DeProtectType.ArgValue_87);
			RuntimeGuard.smethod_1();
			RuntimeGuard.smethod_6();
			RuntimeGuard.smethod_4();
			RuntimeGuard.smethod_5();
			SystemInventory.Initialize();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_88;
			string argValue_2 = DeProtectType.ArgValue_89;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	private static void smethod_1()
	{
		FileLogger.Log(DeProtectType.ArgValue_90, DeProtectType.ArgValue_91);
		if (ClientRuntimeState.string_1 != DeProtectType.ArgValue_92)
		{
			string fileName = Process.GetCurrentProcess().MainModule.FileName;
			string directoryName = new FileInfo(fileName).DirectoryName;
			if (!RuntimeGuard.smethod_2(fileName, string.Empty))
			{
				FileLogger.Log(DeProtectType.ArgValue_93, DeProtectType.ArgValue_94);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_95), DeProtectType.ArgValue_96))
			{
				FileLogger.Log(DeProtectType.ArgValue_97, DeProtectType.ArgValue_98);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_99), DeProtectType.ArgValue_100))
			{
				FileLogger.Log(DeProtectType.ArgValue_101, DeProtectType.ArgValue_102);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_103), DeProtectType.ArgValue_104))
			{
				FileLogger.Log(DeProtectType.ArgValue_105, DeProtectType.ArgValue_106);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_107), DeProtectType.ArgValue_108))
			{
				FileLogger.Log(DeProtectType.ArgValue_109, DeProtectType.ArgValue_110);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_111), DeProtectType.ArgValue_112))
			{
				FileLogger.Log(DeProtectType.ArgValue_113, DeProtectType.ArgValue_114);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_115), DeProtectType.ArgValue_116))
			{
				FileLogger.Log(DeProtectType.ArgValue_117, DeProtectType.ArgValue_118);
				RuntimeGuard.ExitApplication();
			}
			if (!RuntimeGuard.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_119), DeProtectType.ArgValue_120))
			{
				FileLogger.Log(DeProtectType.ArgValue_121, DeProtectType.ArgValue_122);
				RuntimeGuard.ExitApplication();
			}
		}
		else
		{
			SystemInventory.string_1 = DeProtectType.ArgValue_123;
		}
	}
	private static bool smethod_2(string string_0, string string_1)
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			try
			{
				using (MD5 md = MD5.Create())
				{
					using (FileStream fileStream = File.OpenRead(string_0))
					{
						byte[] value = md.ComputeHash(fileStream);
						if (BitConverter.ToString(value).Replace(DeProtectType.ArgValue_124, "").ToLowerInvariant() != string_1.ToLower())
						{
							return false;
						}
					}
				}
			}
			catch
			{
				return false;
			}
		}
		try
		{
			X509Certificate certificate = X509Certificate.CreateFromSignedFile(string_0);
			new X509Certificate2(certificate);
		}
		catch
		{
			return false;
		}
		return true;
	}
	private static void smethod_3()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_125, DeProtectType.ArgValue_126);
			ulong num = TokenPrivilegeInspector.smethod_1();
			FileLogger.Log(DeProtectType.ArgValue_127, DeProtectType.ArgValue_128 + num.ToString());
			if (num == 0UL)
			{
				FileLogger.Log(DeProtectType.ArgValue_129, DeProtectType.ArgValue_130);
				MessageBox.Show("Ошибка работы со Steam. Перезапустите Steam от имени админа и войдите в свою учетную запись!\n\nError working with Steam. Restart Steam as administrator and log in to your account!", DeProtectType.ArgValue_131, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RuntimeGuard.ExitApplication();
			}
			IsolatedBootstrapper.igameWerForm_0.OnIncomingSteamID(num);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_132;
			string argValue_2 = DeProtectType.ArgValue_133;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	private static void smethod_4()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_134, DeProtectType.ArgValue_135);
			bool flag = int.Parse(DeProtectType.ArgValue_136) == 1;
			using (WindowsIdentity current = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
				flag = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			if (flag == (int.Parse(DeProtectType.ArgValue_137) == 1))
			{
				FileLogger.Log(DeProtectType.ArgValue_138, DeProtectType.ArgValue_139);
				MessageBox.Show("Для работы античита - необходимо запустить античит от имени администратора.\n\nFor anti-cheat to work, you must run anti-cheat on behalf of the administrator.", DeProtectType.ArgValue_140, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RuntimeGuard.ExitApplication();
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_141;
			string argValue_2 = DeProtectType.ArgValue_142;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	private static void smethod_5()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_143, DeProtectType.ArgValue_144);
			if (TokenPrivilegeInspector.Initialize() == (int.Parse(DeProtectType.ArgValue_145) == 1))
			{
				FileLogger.Log(DeProtectType.ArgValue_146, DeProtectType.ArgValue_147);
				MessageBox.Show("Для работы античита - необходимо запустить Steam и авторизоваться в нем. Если Steam у вас запущен, перезапустите его от имени администратора.\n\nFor anti-cheat to work, you need to start Steam and log in to it. If you have Steam running, restart it as administrator.", DeProtectType.ArgValue_148, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RuntimeGuard.ExitApplication();
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_149;
			string argValue_2 = DeProtectType.ArgValue_150;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	private static void smethod_6()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_151, DeProtectType.ArgValue_152);
			bool flag = int.Parse(DeProtectType.ArgValue_153) == 1;
			try
			{
				if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DeProtectType.ArgValue_154)))
				{
					flag = (int.Parse(DeProtectType.ArgValue_155) == 1);
				}
			}
			catch
			{
			}
			if (!flag)
			{
				FileLogger.Log(DeProtectType.ArgValue_156, DeProtectType.ArgValue_157);
				DialogResult dialogResult = MessageBox.Show("Вы даете согласие на сбор и обработку ваших персональных данных и информации собраной с этого устройства для автоматического анализа и предоставления администраторам игровых серверов?\n\nDo you consent to the collection and processing of your personal data and information collected from this device to automatically analyze and provide game server administrators?", DeProtectType.ArgValue_158, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dialogResult == DialogResult.No)
				{
					FileLogger.Log(DeProtectType.ArgValue_159, DeProtectType.ArgValue_160);
					MessageBox.Show("Данная программа является античитом, и без сбора информации к сожалению - не может работоать. Так как - вы не дали согласия, данная программа(античит) будет закрыта.\n\nThis program is an anti-cheat, and unfortunately it cannot work without collecting information. Since - you did not give consent, this program (anti-cheat) will be closed.", DeProtectType.ArgValue_161, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					RuntimeGuard.ExitApplication();
				}
				else
				{
					FileLogger.Log(DeProtectType.ArgValue_162, DeProtectType.ArgValue_163);
					File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DeProtectType.ArgValue_164), DateTime.Now.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_165;
			string argValue_2 = DeProtectType.ArgValue_166;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	internal static void NotifyApplicationReady()
	{
		RuntimeGuard.smethod_3();
		IsolatedBootstrapper.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_167);
	}
	internal static void RunMainLoop()
	{
		FileLogger.Log(DeProtectType.ArgValue_168, DeProtectType.ArgValue_169);
		RetryScheduler.RunForever(new Action(RuntimeGuard.smethod_10), new Action<Exception>(RuntimeGuard.smethod_9), 10f);
		while (RuntimeGuard.bool_0)
		{
			try
			{
				Action action = null;
				while ((action = RuntimeGuard.DequeueMainLoopAction()) != null)
				{
					try
					{
						if (action != null)
						{
							action();
						}
					}
					catch (Exception ex)
					{
						string argValue_ = DeProtectType.ArgValue_170;
						string argValue_2 = DeProtectType.ArgValue_171;
						string str = (action != null) ? action.Method.ToString() : DeProtectType.ArgValue_172;
						string argValue_3 = DeProtectType.ArgValue_173;
						Exception ex2 = ex;
						FileLogger.Log(argValue_, argValue_2 + str + argValue_3 + ((ex2 != null) ? ex2.ToString() : null));
					}
				}
			}
			catch (Exception ex3)
			{
				string argValue_4 = DeProtectType.ArgValue_174;
				string argValue_5 = DeProtectType.ArgValue_175;
				Exception ex4 = ex3;
				FileLogger.Log(argValue_4, argValue_5 + ((ex4 != null) ? ex4.ToString() : null));
			}
			Thread.Sleep(33);
		}
	}
	private static void smethod_9(Exception exception_0)
	{
		FileLogger.Log(DeProtectType.ArgValue_176, DeProtectType.ArgValue_177 + ((exception_0 != null) ? exception_0.ToString() : null));
	}
	private static void smethod_10()
	{
		FileLogger.Log(DeProtectType.ArgValue_178, DeProtectType.ArgValue_179);
		ServerWebSocketClient.Connect();
	}
	internal static void ExitApplication()
	{
		try
		{
			FileLogger.Log(DeProtectType.ArgValue_180, DeProtectType.ArgValue_181);
			RuntimeGuard.bool_0 = (int.Parse(DeProtectType.ArgValue_182) == 1);
			ExitHotkeyMonitor.smethod_1();
			ModuleMonitor.Stop();
			DiscordRichPresenceManager.smethod_1();
			IsolatedBootstrapper.smethod_4();
			ServerWebSocketClient.Close();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_183;
			string argValue_2 = DeProtectType.ArgValue_184;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		Environment.Exit(int.Parse(DeProtectType.ArgValue_185));
	}
	internal static void EnqueueOnMainLoop(Action action_0)
	{
		Queue<Action> obj = RuntimeGuard.queue_0;
		lock (obj)
		{
			RuntimeGuard.queue_0.Enqueue(action_0);
		}
	}
	internal static Action DequeueMainLoopAction()
	{
		Action result = null;
		Queue<Action> obj = RuntimeGuard.queue_0;
		lock (obj)
		{
			if (RuntimeGuard.queue_0.Count > int.Parse(DeProtectType.ArgValue_186))
			{
				result = RuntimeGuard.queue_0.Dequeue();
			}
		}
		return result;
	}
	internal static bool bool_0 = true;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly DateTime dateTime_0;
	private static readonly Queue<Action> queue_0 = new Queue<Action>();
}
