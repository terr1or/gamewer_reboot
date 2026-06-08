using System;
using System.IO;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class DllInjector
{
	public DllInjector(InjectionMode injectionMethod = InjectionMode.const_1)
	{
		this.class3_0 = new NtCreateThreadExStrategy();
	}
	public void method_0(int int_0, string string_0, InjectionOptions gclass1_0 = null)
	{
		if (int_0 <= 0)
		{
			throw new ArgumentException(DeProtectType.ArgValue_0 + int_0.ToString(), DeProtectType.ArgValue_1);
		}
		if (string.IsNullOrWhiteSpace(string_0) || !File.Exists(string_0))
		{
			throw new ArgumentException(string.Format(DeProtectType.ArgValue_2, string_0));
		}
		gclass1_0 = (gclass1_0 ?? InjectionOptions.GClass1_0);
		IntPtr intPtr = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.CreateThread | NativeMethods.ProcessAccessFlags.VirtualMemoryOperation | NativeMethods.ProcessAccessFlags.VirtualMemoryRead | NativeMethods.ProcessAccessFlags.VirtualMemoryWrite | NativeMethods.ProcessAccessFlags.Terminate0, false, int_0);
		NativeCallGuard.ThrowIfFailed(intPtr == IntPtr.Zero, DeProtectType.ArgValue_3, new object[]
		{
			int_0
		});
		IntPtr hHandle = this.class3_0.method_0(intPtr, string_0);
		if (gclass1_0.Boolean_0)
		{
			NativeMethods.WaitForSingleObject(hHandle, uint.MaxValue);
		}
		NativeMethods.CloseHandle(intPtr);
	}
	private NtCreateThreadExStrategy class3_0;
}
