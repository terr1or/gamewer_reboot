using System;
using System.Text;
using GameWer;

// Token: 0x02000036 RID: 54
public static class GClass24
{
	// Token: 0x060000DC RID: 220 RVA: 0x00005F2C File Offset: 0x0000412C
	public static byte[] smethod_0(this Encoding encoding_0, string string_0)
	{
		return encoding_0.GetBytes(string_0 + DeProtectType.ArgValue_380);
	}
}
