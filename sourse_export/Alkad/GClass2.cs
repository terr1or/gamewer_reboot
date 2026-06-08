using System;
using System.Text;
using GameWer;

// Token: 0x0200000F RID: 15
public class GClass2
{
	// Token: 0x06000018 RID: 24 RVA: 0x000027C4 File Offset: 0x000009C4
	public IntPtr method_0(IntPtr intptr_0, string string_0)
	{
		if (intptr_0 == IntPtr.Zero)
		{
			throw new ArgumentException(DeProtectType.ArgValue_7, DeProtectType.ArgValue_8);
		}
		if (string.IsNullOrWhiteSpace(string_0))
		{
			throw new ArgumentException(DeProtectType.ArgValue_9, DeProtectType.ArgValue_10);
		}
		byte[] bytes = Encoding.ASCII.GetBytes(string_0 + DeProtectType.ArgValue_11);
		IntPtr intPtr = Class0.VirtualAllocEx(intptr_0, IntPtr.Zero, (uint)bytes.Length, Class0.Enum1.flag_0 | Class0.Enum1.flag_1, Class0.Enum2.flag_2);
		Class1.smethod_0(intPtr == IntPtr.Zero, DeProtectType.ArgValue_12, Array.Empty<object>());
		IntPtr intPtr2;
		Class1.smethod_0(!Class0.WriteProcessMemory(intptr_0, intPtr, bytes, bytes.Length, out intPtr2), DeProtectType.ArgValue_13, Array.Empty<object>());
		IntPtr moduleHandle = Class0.GetModuleHandle(DeProtectType.ArgValue_14);
		Class1.smethod_0(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_15, Array.Empty<object>());
		IntPtr procAddress = Class0.GetProcAddress(moduleHandle, DeProtectType.ArgValue_16);
		Class1.smethod_0(procAddress == IntPtr.Zero, DeProtectType.ArgValue_17, Array.Empty<object>());
		IntPtr intPtr3 = this.vmethod_0(intptr_0, procAddress, intPtr);
		Class1.smethod_0(intPtr3 == IntPtr.Zero, DeProtectType.ArgValue_18, new object[]
		{
			base.GetType().Name
		});
		return intPtr3;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x000028F8 File Offset: 0x00000AF8
	protected virtual IntPtr vmethod_0(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		return IntPtr.Zero;
	}
}
