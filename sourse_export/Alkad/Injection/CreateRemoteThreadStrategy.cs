using System;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
internal class CreateRemoteThreadStrategy : RemoteThreadStrategy
{
	protected virtual IntPtr vmethod_1(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr intPtr = NativeMethods.CreateRemoteThread(intptr_0, IntPtr.Zero, 0U, intptr_1, intptr_2, 0U, IntPtr.Zero);
		NativeCallGuard.ThrowIfFailed(intPtr == IntPtr.Zero, DeProtectType.ArgValue_6, Array.Empty<object>());
		return intPtr;
	}
}
