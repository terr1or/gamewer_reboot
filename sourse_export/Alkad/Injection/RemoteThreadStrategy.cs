using System;
using System.Text;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class RemoteThreadStrategy
{
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
		IntPtr intPtr = NativeMethods.VirtualAllocEx(intptr_0, IntPtr.Zero, (uint)bytes.Length, NativeMethods.AllocationType.Commit | NativeMethods.AllocationType.Reserve, NativeMethods.MemoryProtection.ExecuteReadWrite);
		NativeCallGuard.ThrowIfFailed(intPtr == IntPtr.Zero, DeProtectType.ArgValue_12, Array.Empty<object>());
		IntPtr intPtr2;
		NativeCallGuard.ThrowIfFailed(!NativeMethods.WriteProcessMemory(intptr_0, intPtr, bytes, bytes.Length, out intPtr2), DeProtectType.ArgValue_13, Array.Empty<object>());
		IntPtr moduleHandle = NativeMethods.GetModuleHandle(DeProtectType.ArgValue_14);
		NativeCallGuard.ThrowIfFailed(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_15, Array.Empty<object>());
		IntPtr procAddress = NativeMethods.GetProcAddress(moduleHandle, DeProtectType.ArgValue_16);
		NativeCallGuard.ThrowIfFailed(procAddress == IntPtr.Zero, DeProtectType.ArgValue_17, Array.Empty<object>());
		IntPtr intPtr3 = this.vmethod_0(intptr_0, procAddress, intPtr);
		NativeCallGuard.ThrowIfFailed(intPtr3 == IntPtr.Zero, DeProtectType.ArgValue_18, new object[]
		{
			base.GetType().Name
		});
		return intPtr3;
	}
	protected virtual IntPtr vmethod_0(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		return IntPtr.Zero;
	}
}
