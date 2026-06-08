using System;
using System.Runtime.InteropServices;
using GameWer;

// Token: 0x0200000C RID: 12
internal static class Class1
{
	// Token: 0x06000014 RID: 20 RVA: 0x00002740 File Offset: 0x00000940
	public static void smethod_0(bool bool_0, string string_0, params object[] object_0)
	{
		if (bool_0)
		{
			string arg = string.Format(string_0, object_0);
			string arg2 = string.Format(DeProtectType.ArgValue_4, Marshal.GetLastWin32Error());
			string message = string.Format(DeProtectType.ArgValue_5, arg, arg2);
			throw new GException0(message);
		}
	}
}
