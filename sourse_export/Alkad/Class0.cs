using System;
using System.Runtime.InteropServices;

// Token: 0x02000006 RID: 6
internal static class Class0
{
	// Token: 0x06000008 RID: 8
	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(Class0.Enum0 processAccess, bool bInheritHandle, int processId);

	// Token: 0x06000009 RID: 9
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);

	// Token: 0x0600000A RID: 10
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, Class0.Enum1 flAllocationType, Class0.Enum2 flProtect);

	// Token: 0x0600000B RID: 11
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

	// Token: 0x0600000C RID: 12
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetModuleHandle(string lpModuleName);

	// Token: 0x0600000D RID: 13
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	// Token: 0x0600000E RID: 14
	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

	// Token: 0x0600000F RID: 15
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

	// Token: 0x04000006 RID: 6
	public const string string_0 = "kernel32.dll";

	// Token: 0x04000007 RID: 7
	public const string string_1 = "ntdll.dll";

	// Token: 0x04000008 RID: 8
	public const string string_2 = "LoadLibraryA";

	// Token: 0x04000009 RID: 9
	public const string string_3 = "NtCreateThreadEx";

	// Token: 0x0400000A RID: 10
	public const uint uint_0 = 4294967295U;

	// Token: 0x0400000B RID: 11
	public const uint uint_1 = 128U;

	// Token: 0x0400000C RID: 12
	public const uint uint_2 = 0U;

	// Token: 0x0400000D RID: 13
	public const uint uint_3 = 258U;

	// Token: 0x02000007 RID: 7
	[Flags]
	public enum Enum0 : uint
	{
		// Token: 0x0400000F RID: 15
		flag_0 = 2035711U,
		// Token: 0x04000010 RID: 16
		flag_1 = 1U,
		// Token: 0x04000011 RID: 17
		flag_2 = 2U,
		// Token: 0x04000012 RID: 18
		flag_3 = 8U,
		// Token: 0x04000013 RID: 19
		flag_4 = 16U,
		// Token: 0x04000014 RID: 20
		flag_5 = 32U,
		// Token: 0x04000015 RID: 21
		flag_6 = 64U,
		// Token: 0x04000016 RID: 22
		flag_7 = 128U,
		// Token: 0x04000017 RID: 23
		flag_8 = 256U,
		// Token: 0x04000018 RID: 24
		flag_9 = 512U,
		// Token: 0x04000019 RID: 25
		flag_10 = 1024U,
		// Token: 0x0400001A RID: 26
		flag_11 = 4096U,
		// Token: 0x0400001B RID: 27
		flag_12 = 1048576U
	}

	// Token: 0x02000008 RID: 8
	[Flags]
	public enum Enum1
	{
		// Token: 0x0400001D RID: 29
		flag_0 = 4096,
		// Token: 0x0400001E RID: 30
		flag_1 = 8192,
		// Token: 0x0400001F RID: 31
		flag_2 = 16384,
		// Token: 0x04000020 RID: 32
		flag_3 = 32768,
		// Token: 0x04000021 RID: 33
		flag_4 = 524288,
		// Token: 0x04000022 RID: 34
		flag_5 = 4194304,
		// Token: 0x04000023 RID: 35
		flag_6 = 1048576,
		// Token: 0x04000024 RID: 36
		flag_7 = 2097152,
		// Token: 0x04000025 RID: 37
		flag_8 = 536870912
	}

	// Token: 0x02000009 RID: 9
	[Flags]
	public enum Enum2
	{
		// Token: 0x04000027 RID: 39
		flag_0 = 16,
		// Token: 0x04000028 RID: 40
		flag_1 = 32,
		// Token: 0x04000029 RID: 41
		flag_2 = 64,
		// Token: 0x0400002A RID: 42
		flag_3 = 128,
		// Token: 0x0400002B RID: 43
		flag_4 = 1,
		// Token: 0x0400002C RID: 44
		flag_5 = 2,
		// Token: 0x0400002D RID: 45
		flag_6 = 4,
		// Token: 0x0400002E RID: 46
		flag_7 = 8,
		// Token: 0x0400002F RID: 47
		flag_8 = 256,
		// Token: 0x04000030 RID: 48
		flag_9 = 512,
		// Token: 0x04000031 RID: 49
		flag_10 = 1024
	}

	// Token: 0x0200000A RID: 10
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Struct0
	{
		// Token: 0x04000032 RID: 50
		public int int_0;

		// Token: 0x04000033 RID: 51
		public uint uint_0;

		// Token: 0x04000034 RID: 52
		public uint uint_1;

		// Token: 0x04000035 RID: 53
		public IntPtr intptr_0;

		// Token: 0x04000036 RID: 54
		public uint uint_2;

		// Token: 0x04000037 RID: 55
		public uint uint_3;

		// Token: 0x04000038 RID: 56
		public uint uint_4;

		// Token: 0x04000039 RID: 57
		public IntPtr intptr_1;

		// Token: 0x0400003A RID: 58
		public uint uint_5;
	}

	// Token: 0x0200000B RID: 11
	// (Invoke) Token: 0x06000011 RID: 17
	public delegate int Delegate0(out IntPtr threadHandle, uint desiredAccess, IntPtr objectAttributes, IntPtr processHandle, IntPtr lpStartAddress, IntPtr lpParameter, int createSuspended, uint stackZeroBits, uint sizeOfStackCommit, uint sizeOfStackReserve, IntPtr lpBytesBuffer);
}
