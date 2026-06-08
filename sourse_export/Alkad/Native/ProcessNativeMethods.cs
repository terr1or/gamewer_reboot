using System;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Contains ToolHelp, PSAPI, and process-related Win32 interop declarations.
/// </summary>
internal static class ProcessNativeMethods
{
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Process32First(IntPtr hSnapshot, ref ProcessEntry lppe);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Process32Next(IntPtr hSnapshot, ref ProcessEntry lppe);

	[DllImport("kernel32.dll")]
	public static extern int CloseHandle(IntPtr handle);

	[DllImport("psapi.dll")]
	public static extern uint GetProcessImageFileName(IntPtr hProcess, [Out] StringBuilder lpImageFileName, [MarshalAs(UnmanagedType.U4)] [In] int nSize);

	[DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [MarshalAs(UnmanagedType.U4)] [In] int nSize);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, [MarshalAs(UnmanagedType.LPTStr)] [Out] StringBuilder lpExeName, ref uint lpdwSize);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	private const string Kernel32LibraryName = "kernel32.dll";
	private const string PsApiLibraryName = "psapi.dll";

	public const uint SnapshotHeapList = 0x00000001U;
	public const uint SnapshotProcess = 0x00000002U;
	public const uint SnapshotThread = 0x00000004U;
	public const uint SnapshotModule = 0x00000008U;
	public const uint SnapshotModule32 = 0x00000010U;
	public const uint SnapshotAll = SnapshotHeapList | SnapshotProcess | SnapshotThread | SnapshotModule;
	public const uint SnapshotInherit = 0x80000000U;

	public const uint ProcessAllAccess = 0x1F0FFFU;
	public const uint ProcessTerminate = 0x0001U;
	public const uint ProcessCreateThread = 0x0002U;
	public const uint ProcessVirtualMemoryOperation = 0x0008U;
	public const uint ProcessVirtualMemoryRead = 0x0010U;
	public const uint ProcessVirtualMemoryWrite = 0x0020U;
	public const uint ProcessDuplicateHandle = 0x0040U;
	public const uint ProcessCreateProcess = 0x0080U;
	public const uint ProcessSetQuota = 0x0100U;
	public const uint ProcessSetInformation = 0x0200U;
	public const uint ProcessQueryInformation = 0x0400U;
	public const uint ProcessSetInformation2 = 0x0800U;
	public const uint ProcessSuspendResume = 0x1000U;
	public const uint ProcessSynchronize = 0x100000U;

	public static readonly IntPtr InvalidHandleValue = new IntPtr(-1);

	/// <summary>Managed representation of PROCESSENTRY32.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ProcessEntry
	{
		public uint Size;
		public uint UsageCount;
		public uint ProcessId;
		public IntPtr DefaultHeapId;
		public uint ModuleId;
		public uint ThreadCount;
		public uint ParentProcessId;
		public int BasePriority;
		public uint Flags;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string ExecutableFileName;
	}
}
