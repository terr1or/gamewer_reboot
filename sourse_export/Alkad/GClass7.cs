using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using GameWer;

// Token: 0x0200001F RID: 31
public class GClass7
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600006A RID: 106 RVA: 0x000022BC File Offset: 0x000004BC
	private static GClass7 GClass7_0 { get; } = new GClass7();

	// Token: 0x0600006B RID: 107 RVA: 0x00002075 File Offset: 0x00000275
	private GClass7()
	{
	}

	// Token: 0x0600006C RID: 108 RVA: 0x000041B0 File Offset: 0x000023B0
	internal static void smethod_0(string string_0, string string_1)
	{
		Console.WriteLine(DeProtectType.ArgValue_230 + string_0 + DeProtectType.ArgValue_231 + string_1);
		GClass7 obj = GClass7.GClass7_0;
		lock (obj)
		{
			try
			{
				Console.WriteLine(string.Format("\n[{0}] [{1}]: ", DateTime.Now, string_0) + string_1);
				File.AppendAllText(DeProtectType.ArgValue_232, string.Format("\n[{0}] [{1}]: ", DateTime.Now, string_0) + string_1);
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x04000270 RID: 624
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly GClass7 gclass7_0;
}
