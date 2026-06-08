using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using GameWer;

// Token: 0x02000042 RID: 66
public class GClass31
{
	// Token: 0x0600011A RID: 282 RVA: 0x00007434 File Offset: 0x00005634
	internal static void smethod_0()
	{
		if (!GClass31.bool_0)
		{
			GClass31.bool_0 = true;
			GClass31.thread_0 = new Thread(new ThreadStart(GClass31.smethod_1));
			GClass31.thread_0.IsBackground = true;
			GClass31.thread_0.Priority = ThreadPriority.Highest;
			GClass31.thread_0.Start();
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00007484 File Offset: 0x00005684
	private static void smethod_1()
	{
		while (GClass4.bool_0)
		{
			try
			{
				GClass31.smethod_2();
			}
			catch
			{
			}
			Thread.Sleep(int.Parse(DeProtectType.ArgValue_475));
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000025DE File Offset: 0x000007DE
	private static void smethod_2()
	{
		GClass31.smethod_3(Keys.Insert);
	}

	// Token: 0x0600011D RID: 285 RVA: 0x000074C8 File Offset: 0x000056C8
	private static void smethod_3(Keys keys_0)
	{
		bool flag;
		if ((flag = (GClass32.GetAsyncKeyState((int)keys_0) != int.Parse(DeProtectType.ArgValue_476))) && !GClass31.hashSet_0.Contains(keys_0))
		{
			GClass31.hashSet_0.Add(keys_0);
			try
			{
				Action<Keys> action = GClass31.action_0;
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
				GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
				return;
			}
		}
		if (!flag && GClass31.hashSet_0.Contains(keys_0))
		{
			GClass31.hashSet_0.Remove(keys_0);
		}
	}

	// Token: 0x040002F2 RID: 754
	internal static Thread thread_0;

	// Token: 0x040002F3 RID: 755
	private static bool bool_0 = false;

	// Token: 0x040002F4 RID: 756
	private static HashSet<Keys> hashSet_0 = new HashSet<Keys>();

	// Token: 0x040002F5 RID: 757
	internal static Action<Keys> action_0;
}
