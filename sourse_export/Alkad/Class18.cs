using System;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x02000040 RID: 64
internal class Class18
{
	// Token: 0x0600010F RID: 271
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

	// Token: 0x06000110 RID: 272
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Process32First(IntPtr hSnapshot, ref Class18.Struct1 lppe);

	// Token: 0x06000111 RID: 273
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Process32Next(IntPtr hSnapshot, ref Class18.Struct1 lppe);

	// Token: 0x06000112 RID: 274
	[DllImport("kernel32.dll")]
	public static extern int CloseHandle(IntPtr handle);

	// Token: 0x06000113 RID: 275
	[DllImport("psapi.dll")]
	public static extern uint GetProcessImageFileName(IntPtr hProcess, [Out] StringBuilder lpImageFileName, [MarshalAs(UnmanagedType.U4)] [In] int nSize);

	// Token: 0x06000114 RID: 276
	[DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [MarshalAs(UnmanagedType.U4)] [In] int nSize);

	// Token: 0x06000115 RID: 277
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	// Token: 0x06000116 RID: 278
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, [MarshalAs(UnmanagedType.LPTStr)] [Out] StringBuilder lpExeName, ref uint lpdwSize);

	// Token: 0x06000117 RID: 279
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	// Token: 0x040002D0 RID: 720
	private const string string_0 = "kernel32.dll";

	// Token: 0x040002D1 RID: 721
	private const string string_1 = "psapi.dll";

	// Token: 0x040002D2 RID: 722
	public static uint uint_0 = 1U;

	// Token: 0x040002D3 RID: 723
	public static uint uint_1 = 2U;

	// Token: 0x040002D4 RID: 724
	public static uint uint_2 = 4U;

	// Token: 0x040002D5 RID: 725
	public static uint uint_3 = 8U;

	// Token: 0x040002D6 RID: 726
	public static uint uint_4 = 16U;

	// Token: 0x040002D7 RID: 727
	public static uint uint_5 = 15U;

	// Token: 0x040002D8 RID: 728
	public static uint uint_6 = 2147483648U;

	// Token: 0x040002D9 RID: 729
	public static uint uint_7 = 2035711U;

	// Token: 0x040002DA RID: 730
	public static uint uint_8 = 1U;

	// Token: 0x040002DB RID: 731
	public static uint uint_9 = 2U;

	// Token: 0x040002DC RID: 732
	public static uint uint_10 = 8U;

	// Token: 0x040002DD RID: 733
	public static uint uint_11 = 16U;

	// Token: 0x040002DE RID: 734
	public static uint uint_12 = 32U;

	// Token: 0x040002DF RID: 735
	public static uint uint_13 = 64U;

	// Token: 0x040002E0 RID: 736
	public static uint uint_14 = 128U;

	// Token: 0x040002E1 RID: 737
	public static uint uint_15 = 256U;

	// Token: 0x040002E2 RID: 738
	public static uint uint_16 = 512U;

	// Token: 0x040002E3 RID: 739
	public static uint uint_17 = 1024U;

	// Token: 0x040002E4 RID: 740
	public static uint uint_18 = 2048U;

	// Token: 0x040002E5 RID: 741
	public static uint uint_19 = 4096U;

	// Token: 0x040002E6 RID: 742
	public static uint uint_20 = 1048576U;

	// Token: 0x040002E7 RID: 743
	public static readonly IntPtr intptr_0 = new IntPtr(-1);

	// Token: 0x02000041 RID: 65
	public struct Struct1
	{
		// Token: 0x040002E8 RID: 744
		public uint uint_0;

		// Token: 0x040002E9 RID: 745
		public uint uint_1;

		// Token: 0x040002EA RID: 746
		public uint uint_2;

		// Token: 0x040002EB RID: 747
		public IntPtr intptr_0;

		// Token: 0x040002EC RID: 748
		public uint uint_3;

		// Token: 0x040002ED RID: 749
		public uint uint_4;

		// Token: 0x040002EE RID: 750
		public uint uint_5;

		// Token: 0x040002EF RID: 751
		public int int_0;

		// Token: 0x040002F0 RID: 752
		public uint uint_6;

		// Token: 0x040002F1 RID: 753
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string string_0;
	}
}
