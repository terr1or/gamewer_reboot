using System;
using System.IO;
using GameWer;

// Token: 0x02000003 RID: 3
public class GClass0
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002051 File Offset: 0x00000251
	public GClass0(GEnum0 injectionMethod = GEnum0.const_1)
	{
		this.class3_0 = new Class3();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002670 File Offset: 0x00000870
	public void method_0(int int_0, string string_0, GClass1 gclass1_0 = null)
	{
		if (int_0 <= 0)
		{
			throw new ArgumentException(DeProtectType.ArgValue_0 + int_0.ToString(), DeProtectType.ArgValue_1);
		}
		if (string.IsNullOrWhiteSpace(string_0) || !File.Exists(string_0))
		{
			throw new ArgumentException(string.Format(DeProtectType.ArgValue_2, string_0));
		}
		gclass1_0 = (gclass1_0 ?? GClass1.GClass1_0);
		IntPtr intPtr = Class0.OpenProcess(Class0.Enum0.flag_2 | Class0.Enum0.flag_3 | Class0.Enum0.flag_4 | Class0.Enum0.flag_5 | Class0.Enum0.flag_10, false, int_0);
		Class1.smethod_0(intPtr == IntPtr.Zero, DeProtectType.ArgValue_3, new object[]
		{
			int_0
		});
		IntPtr hHandle = this.class3_0.method_0(intPtr, string_0);
		if (gclass1_0.Boolean_0)
		{
			Class0.WaitForSingleObject(hHandle, uint.MaxValue);
		}
		Class0.CloseHandle(intPtr);
	}

	// Token: 0x04000001 RID: 1
	private Class3 class3_0;
}
