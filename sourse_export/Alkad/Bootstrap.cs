using System;
using System.IO;
using System.Threading;

namespace GameWer
{
	// Token: 0x02000011 RID: 17
	internal static class Bootstrap
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002A74 File Offset: 0x00000C74
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				DeProtectType.DeProtect(args);
				Bootstrap.DoInit();
			}
			catch (Exception ex)
			{
				string path = "./output.log";
				string str = string.Format("\n[{0}] [Main]: Exception: ", DateTime.Now);
				Exception ex2 = ex;
				File.AppendAllText(path, str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002AD4 File Offset: 0x00000CD4
		private static void DoInit()
		{
			GClass7.smethod_0(DeProtectType.ArgValue_25, DeProtectType.ArgValue_26);
			Bootstrap.MutexInstance = new Mutex(true, DeProtectType.ArgValue_27);
			if (Bootstrap.MutexInstance.WaitOne(TimeSpan.Zero, true) || GClass26.string_1 == DeProtectType.ArgValue_28)
			{
				GClass4.smethod_0();
				GClass10.smethod_3();
				GClass8.smethod_0();
				GClass5.smethod_0();
				GAttribute0.smethod_0();
				GClass6.smethod_0();
				GClass4.smethod_7();
				GClass4.smethod_8();
				Bootstrap.MutexInstance.ReleaseMutex();
				GClass7.smethod_0(DeProtectType.ArgValue_29, DeProtectType.ArgValue_30);
			}
			else
			{
				GClass7.smethod_0(DeProtectType.ArgValue_31, DeProtectType.ArgValue_32);
			}
		}

		// Token: 0x0400003B RID: 59
		private static Mutex MutexInstance;
	}
}
