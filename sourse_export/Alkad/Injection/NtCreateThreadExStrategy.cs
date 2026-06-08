using System;
using System.Runtime.InteropServices;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
internal class NtCreateThreadExStrategy : RemoteThreadStrategy
{
	protected unsafe virtual IntPtr vmethod_1(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr moduleHandle = NativeMethods.GetModuleHandle(DeProtectType.ArgValue_19);
		NativeCallGuard.ThrowIfFailed(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_20, Array.Empty<object>());
		IntPtr procAddress = NativeMethods.GetProcAddress(moduleHandle, DeProtectType.ArgValue_21);
		NativeCallGuard.ThrowIfFailed(procAddress == IntPtr.Zero, DeProtectType.ArgValue_22, Array.Empty<object>());
		NativeMethods.NtCreateThreadExDelegate @delegate = (NativeMethods.NtCreateThreadExDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(NativeMethods.NtCreateThreadExDelegate));
		NativeCallGuard.ThrowIfFailed(@delegate == null, DeProtectType.ArgValue_23, Array.Empty<object>());
		int num = 0;
		int num2 = 0;
		NativeMethods.NtCreateThreadExBuffer @struct = new NativeMethods.NtCreateThreadExBuffer
		{
			Size = sizeof(NativeMethods.NtCreateThreadExBuffer),
			Attribute1 = 65539U,
			Size1 = 8U,
			Value1 = new IntPtr((void*)(&num2)),
			Unknown1 = 0U,
			Attribute2 = 65540U,
			Size2 = 4U,
			Value2 = new IntPtr((void*)(&num)),
			Unknown2 = 0U
		};
		bool is64BitProcess = Environment.Is64BitProcess;
		IntPtr zero = IntPtr.Zero;
		@delegate(out zero, 2097151U, IntPtr.Zero, intptr_0, intptr_1, intptr_2, 0, 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? IntPtr.Zero : new IntPtr((void*)(&@struct)));
		NativeCallGuard.ThrowIfFailed(zero == IntPtr.Zero, DeProtectType.ArgValue_24, Array.Empty<object>());
		return zero;
	}
}
