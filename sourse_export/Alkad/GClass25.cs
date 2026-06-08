using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GameWer;

// Token: 0x02000037 RID: 55
public class GClass25
{
	// Token: 0x060000DD RID: 221 RVA: 0x000024CD File Offset: 0x000006CD
	private GClass25()
	{
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000024E3 File Offset: 0x000006E3
	private void method_0()
	{
		ThreadPool.QueueUserWorkItem(new WaitCallback(this.method_2));
	}

	// Token: 0x060000DF RID: 223 RVA: 0x000024F7 File Offset: 0x000006F7
	internal void method_1()
	{
		this.bool_1 = true;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00005F4C File Offset: 0x0000414C
	internal static GClass25 smethod_0(Action action_2, Action<Exception> action_3, float float_0)
	{
		GClass25 gclass = new GClass25();
		gclass.action_0 = action_2;
		gclass.action_1 = action_3;
		gclass.timeSpan_0 = TimeSpan.FromMilliseconds((double)(float_0 * (float)int.Parse(DeProtectType.ArgValue_381)));
		gclass.method_0();
		return gclass;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00005F90 File Offset: 0x00004190
	internal static GClass25 smethod_1(Action action_2, Action<Exception> action_3, float float_0)
	{
		GClass25 gclass = new GClass25();
		gclass.action_0 = action_2;
		gclass.timeSpan_0 = TimeSpan.FromMilliseconds((double)(float_0 * (float)int.Parse(DeProtectType.ArgValue_382)));
		gclass.action_1 = action_3;
		gclass.bool_0 = true;
		gclass.method_0();
		return gclass;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00005FDC File Offset: 0x000041DC
	[CompilerGenerated]
	private void method_2(object object_0)
	{
		while (!this.bool_1)
		{
			Thread.Sleep(this.timeSpan_0);
			GClass4.smethod_12(new Action(this.method_3));
			if (!this.bool_0)
			{
				break;
			}
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00006020 File Offset: 0x00004220
	[CompilerGenerated]
	private void method_3()
	{
		try
		{
			Action action = this.action_0;
			if (action != null)
			{
				action();
			}
		}
		catch (Exception obj)
		{
			Action<Exception> action2 = this.action_1;
			if (action2 != null)
			{
				action2(obj);
			}
		}
	}

	// Token: 0x040002AD RID: 685
	private Action action_0;

	// Token: 0x040002AE RID: 686
	private Action<Exception> action_1;

	// Token: 0x040002AF RID: 687
	private TimeSpan timeSpan_0;

	// Token: 0x040002B0 RID: 688
	private bool bool_0 = false;

	// Token: 0x040002B1 RID: 689
	private bool bool_1 = false;
}
