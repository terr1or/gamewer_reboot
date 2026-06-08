using System;
using GameWer;

// Token: 0x0200000D RID: 13
internal class Class2 : GClass2
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002784 File Offset: 0x00000984
	protected virtual IntPtr vmethod_1(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr intPtr = Class0.CreateRemoteThread(intptr_0, IntPtr.Zero, 0U, intptr_1, intptr_2, 0U, IntPtr.Zero);
		Class1.smethod_0(intPtr == IntPtr.Zero, DeProtectType.ArgValue_6, Array.Empty<object>());
		return intPtr;
	}
}
