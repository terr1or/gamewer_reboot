using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using GameWer;

// Token: 0x02000019 RID: 25
public class GClass5
{
	// Token: 0x0600004F RID: 79 RVA: 0x000021EC File Offset: 0x000003EC
	internal static void smethod_0()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_196, DeProtectType.ArgValue_197);
		GClass31.action_0 = new Action<Keys>(GClass5.smethod_2);
		GClass31.smethod_0();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00003D50 File Offset: 0x00001F50
	internal static void smethod_1()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_198, DeProtectType.ArgValue_199);
		try
		{
			Thread thread_ = GClass31.thread_0;
			if (thread_ != null)
			{
				thread_.Abort();
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002213 File Offset: 0x00000413
	private static void smethod_2(Keys keys_0)
	{
		GClass4.smethod_12(new Action(GClass5.Class6.class6_0.method_0));
	}

	// Token: 0x0200001A RID: 26
	[CompilerGenerated]
	[Serializable]
	private sealed class Class6
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_0()
		{
		}

		// Token: 0x04000263 RID: 611
		public static readonly GClass5.Class6 class6_0 = new GClass5.Class6();

		// Token: 0x04000264 RID: 612
		public static Action action_0;
	}
}
