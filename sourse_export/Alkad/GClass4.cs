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

// Token: 0x02000017 RID: 23
public class GClass4
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000039 RID: 57 RVA: 0x00002149 File Offset: 0x00000349
	internal static DateTime DateTime_0 { get; } = DateTime.Now;

	// Token: 0x0600003A RID: 58 RVA: 0x00003438 File Offset: 0x00001638
	internal static void smethod_0()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_86, DeProtectType.ArgValue_87);
			GClass4.smethod_1();
			GClass4.smethod_6();
			GClass4.smethod_4();
			GClass4.smethod_5();
			GClass33.smethod_0();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_88;
			string argValue_2 = DeProtectType.ArgValue_89;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000034A4 File Offset: 0x000016A4
	private static void smethod_1()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_90, DeProtectType.ArgValue_91);
		if (GClass26.string_1 != DeProtectType.ArgValue_92)
		{
			string fileName = Process.GetCurrentProcess().MainModule.FileName;
			string directoryName = new FileInfo(fileName).DirectoryName;
			if (!GClass4.smethod_2(fileName, string.Empty))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_93, DeProtectType.ArgValue_94);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_95), DeProtectType.ArgValue_96))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_97, DeProtectType.ArgValue_98);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_99), DeProtectType.ArgValue_100))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_101, DeProtectType.ArgValue_102);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_103), DeProtectType.ArgValue_104))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_105, DeProtectType.ArgValue_106);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_107), DeProtectType.ArgValue_108))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_109, DeProtectType.ArgValue_110);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_111), DeProtectType.ArgValue_112))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_113, DeProtectType.ArgValue_114);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_115), DeProtectType.ArgValue_116))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_117, DeProtectType.ArgValue_118);
				GClass4.smethod_11();
			}
			if (!GClass4.smethod_2(Path.Combine(directoryName, DeProtectType.ArgValue_119), DeProtectType.ArgValue_120))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_121, DeProtectType.ArgValue_122);
				GClass4.smethod_11();
			}
		}
		else
		{
			GClass33.string_1 = DeProtectType.ArgValue_123;
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00003664 File Offset: 0x00001864
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

	// Token: 0x0600003D RID: 61 RVA: 0x00003734 File Offset: 0x00001934
	private static void smethod_3()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_125, DeProtectType.ArgValue_126);
			ulong num = GClass28.smethod_1();
			GClass7.smethod_0(DeProtectType.ArgValue_127, DeProtectType.ArgValue_128 + num.ToString());
			if (num == 0UL)
			{
				GClass7.smethod_0(DeProtectType.ArgValue_129, DeProtectType.ArgValue_130);
				MessageBox.Show("Ошибка работы со Steam. Перезапустите Steam от имени админа и войдите в свою учетную запись!\n\nError working with Steam. Restart Steam as administrator and log in to your account!", DeProtectType.ArgValue_131, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				GClass4.smethod_11();
			}
			GClass10.igameWerForm_0.OnIncomingSteamID(num);
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_132;
			string argValue_2 = DeProtectType.ArgValue_133;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000037E8 File Offset: 0x000019E8
	private static void smethod_4()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_134, DeProtectType.ArgValue_135);
			bool flag = int.Parse(DeProtectType.ArgValue_136) == 1;
			using (WindowsIdentity current = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
				flag = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			if (flag == (int.Parse(DeProtectType.ArgValue_137) == 1))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_138, DeProtectType.ArgValue_139);
				MessageBox.Show("Для работы античита - необходимо запустить античит от имени администратора.\n\nFor anti-cheat to work, you must run anti-cheat on behalf of the administrator.", DeProtectType.ArgValue_140, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				GClass4.smethod_11();
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_141;
			string argValue_2 = DeProtectType.ArgValue_142;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000038B8 File Offset: 0x00001AB8
	private static void smethod_5()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_143, DeProtectType.ArgValue_144);
			if (GClass28.smethod_0() == (int.Parse(DeProtectType.ArgValue_145) == 1))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_146, DeProtectType.ArgValue_147);
				MessageBox.Show("Для работы античита - необходимо запустить Steam и авторизоваться в нем. Если Steam у вас запущен, перезапустите его от имени администратора.\n\nFor anti-cheat to work, you need to start Steam and log in to it. If you have Steam running, restart it as administrator.", DeProtectType.ArgValue_148, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				GClass4.smethod_11();
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_149;
			string argValue_2 = DeProtectType.ArgValue_150;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00003948 File Offset: 0x00001B48
	private static void smethod_6()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_151, DeProtectType.ArgValue_152);
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
				GClass7.smethod_0(DeProtectType.ArgValue_156, DeProtectType.ArgValue_157);
				DialogResult dialogResult = MessageBox.Show("Вы даете согласие на сбор и обработку ваших персональных данных и информации собраной с этого устройства для автоматического анализа и предоставления администраторам игровых серверов?\n\nDo you consent to the collection and processing of your personal data and information collected from this device to automatically analyze and provide game server administrators?", DeProtectType.ArgValue_158, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dialogResult == DialogResult.No)
				{
					GClass7.smethod_0(DeProtectType.ArgValue_159, DeProtectType.ArgValue_160);
					MessageBox.Show("Данная программа является античитом, и без сбора информации к сожалению - не может работоать. Так как - вы не дали согласия, данная программа(античит) будет закрыта.\n\nThis program is an anti-cheat, and unfortunately it cannot work without collecting information. Since - you did not give consent, this program (anti-cheat) will be closed.", DeProtectType.ArgValue_161, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					GClass4.smethod_11();
				}
				else
				{
					GClass7.smethod_0(DeProtectType.ArgValue_162, DeProtectType.ArgValue_163);
					File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DeProtectType.ArgValue_164), DateTime.Now.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_165;
			string argValue_2 = DeProtectType.ArgValue_166;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002150 File Offset: 0x00000350
	internal static void smethod_7()
	{
		GClass4.smethod_3();
		GClass10.igameWerForm_0.OnApplicationState(DeProtectType.ArgValue_167);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00003A70 File Offset: 0x00001C70
	internal static void smethod_8()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_168, DeProtectType.ArgValue_169);
		GClass25.smethod_0(new Action(GClass4.smethod_10), new Action<Exception>(GClass4.smethod_9), 10f);
		while (GClass4.bool_0)
		{
			try
			{
				Action action = null;
				while ((action = GClass4.smethod_13()) != null)
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
						GClass7.smethod_0(argValue_, argValue_2 + str + argValue_3 + ((ex2 != null) ? ex2.ToString() : null));
					}
				}
			}
			catch (Exception ex3)
			{
				string argValue_4 = DeProtectType.ArgValue_174;
				string argValue_5 = DeProtectType.ArgValue_175;
				Exception ex4 = ex3;
				GClass7.smethod_0(argValue_4, argValue_5 + ((ex4 != null) ? ex4.ToString() : null));
			}
			Thread.Sleep(33);
		}
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002166 File Offset: 0x00000366
	private static void smethod_9(Exception exception_0)
	{
		GClass7.smethod_0(DeProtectType.ArgValue_176, DeProtectType.ArgValue_177 + ((exception_0 != null) ? exception_0.ToString() : null));
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002189 File Offset: 0x00000389
	private static void smethod_10()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_178, DeProtectType.ArgValue_179);
		GClass6.smethod_3();
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00003B64 File Offset: 0x00001D64
	internal static void smethod_11()
	{
		try
		{
			GClass7.smethod_0(DeProtectType.ArgValue_180, DeProtectType.ArgValue_181);
			GClass4.bool_0 = (int.Parse(DeProtectType.ArgValue_182) == 1);
			GClass5.smethod_1();
			GClass8.smethod_4();
			GAttribute0.smethod_1();
			GClass10.smethod_4();
			GClass6.smethod_7();
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_183;
			string argValue_2 = DeProtectType.ArgValue_184;
			Exception ex2 = ex;
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
		Environment.Exit(int.Parse(DeProtectType.ArgValue_185));
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00003BF4 File Offset: 0x00001DF4
	internal static void smethod_12(Action action_0)
	{
		Queue<Action> obj = GClass4.queue_0;
		lock (obj)
		{
			GClass4.queue_0.Enqueue(action_0);
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00003C38 File Offset: 0x00001E38
	internal static Action smethod_13()
	{
		Action result = null;
		Queue<Action> obj = GClass4.queue_0;
		lock (obj)
		{
			if (GClass4.queue_0.Count > int.Parse(DeProtectType.ArgValue_186))
			{
				result = GClass4.queue_0.Dequeue();
			}
		}
		return result;
	}

	// Token: 0x0400025F RID: 607
	internal static bool bool_0 = true;

	// Token: 0x04000260 RID: 608
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly DateTime dateTime_0;

	// Token: 0x04000261 RID: 609
	private static readonly Queue<Action> queue_0 = new Queue<Action>();
}
