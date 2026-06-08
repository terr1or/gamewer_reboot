using System;
using System.Runtime.InteropServices;
using GameWer;

// Token: 0x02000010 RID: 16
internal class Class3 : GClass2
{
	// Token: 0x0600001B RID: 27 RVA: 0x0000290C File Offset: 0x00000B0C
	protected unsafe virtual IntPtr vmethod_1(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr moduleHandle = Class0.GetModuleHandle(DeProtectType.ArgValue_19);
		Class1.smethod_0(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_20, Array.Empty<object>());
		IntPtr procAddress = Class0.GetProcAddress(moduleHandle, DeProtectType.ArgValue_21);
		Class1.smethod_0(procAddress == IntPtr.Zero, DeProtectType.ArgValue_22, Array.Empty<object>());
		Class0.Delegate0 @delegate = (Class0.Delegate0)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Class0.Delegate0));
		Class1.smethod_0(@delegate == null, DeProtectType.ArgValue_23, Array.Empty<object>());
		int num = 0;
		int num2 = 0;
		Class0.Struct0 @struct = new Class0.Struct0
		{
			int_0 = sizeof(Class0.Struct0),
			uint_0 = 65539U,
			uint_1 = 8U,
			intptr_0 = new IntPtr((void*)(&num2)),
			uint_2 = 0U,
			uint_3 = 65540U,
			uint_4 = 4U,
			intptr_1 = new IntPtr((void*)(&num)),
			uint_5 = 0U
		};
		bool is64BitProcess = Environment.Is64BitProcess;
		IntPtr zero = IntPtr.Zero;
		@delegate(out zero, 2097151U, IntPtr.Zero, intptr_0, intptr_1, intptr_2, 0, 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? IntPtr.Zero : new IntPtr((void*)(&@struct)));
		Class1.smethod_0(zero == IntPtr.Zero, DeProtectType.ArgValue_24, Array.Empty<object>());
		return zero;
	}
}
