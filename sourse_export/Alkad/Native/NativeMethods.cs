using System;
using System.Runtime.InteropServices;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
internal static class NativeMethods
{
	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetModuleHandle(string lpModuleName);
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
	public const string Kernel32LibraryName = "kernel32.dll";
	public const string NtDllLibraryName = "ntdll.dll";
	public const string LoadLibraryAFunctionName = "LoadLibraryA";
	public const string NtCreateThreadExFunctionName = "NtCreateThreadEx";
	public const uint InfiniteTimeout = 0xFFFFFFFFU;
	public const uint WaitAbandoned = 0x80U;
	public const uint WaitObject0 = 0U;
	public const uint WaitTimeout = 0x102U;
	/// <summary>Process access rights used by OpenProcess.</summary>
	[Flags]
	public enum ProcessAccessFlags : uint
	{
		AllAccess = 0x1F0FFFU,
		Terminate = 0x0001U,
		CreateThread = 0x0002U,
		VirtualMemoryOperation = 0x0008U,
		VirtualMemoryRead = 0x0010U,
		VirtualMemoryWrite = 0x0020U,
		DuplicateHandle = 0x0040U,
		CreateProcess = 0x0080U,
		SetQuota = 0x0100U,
		SetInformation = 0x0200U,
		QueryInformation = 0x0400U,
		SuspendResume = 0x0800U,
		Synchronize = 0x100000U
	}
	/// <summary>VirtualAllocEx allocation flags.</summary>
	[Flags]
	public enum AllocationType
	{
		Commit = 0x1000,
		Reserve = 0x2000,
		Decommit = 0x4000,
		Release = 0x8000,
		Reset = 0x80000,
		Physical = 0x400000,
		TopDown = 0x100000,
		WriteWatch = 0x200000,
		LargePages = 0x20000000
	}
	/// <summary>VirtualAllocEx page protection flags.</summary>
	[Flags]
	public enum MemoryProtection
	{
		Execute = 0x10,
		ExecuteRead = 0x20,
		ExecuteReadWrite = 0x40,
		ExecuteWriteCopy = 0x80,
		NoAccess = 0x01,
		ReadOnly = 0x02,
		ReadWrite = 0x04,
		WriteCopy = 0x08,
		Guard = 0x100,
		NoCache = 0x200,
		WriteCombine = 0x400
	}
	/// <summary>Compatibility buffer passed to NtCreateThreadEx on 32-bit systems.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct NtCreateThreadExBuffer
	{
		public int Size;
		public uint Attribute1;
		public uint Size1;
		public IntPtr Value1;
		public uint Unknown1;
		public uint Attribute2;
		public uint Size2;
		public IntPtr Value2;
		public uint Unknown2;
	}
	public delegate int NtCreateThreadExDelegate(out IntPtr threadHandle, uint desiredAccess, IntPtr objectAttributes, IntPtr processHandle, IntPtr lpStartAddress, IntPtr lpParameter, int createSuspended, uint stackZeroBits, uint sizeOfStackCommit, uint sizeOfStackReserve, IntPtr lpBytesBuffer);
}
