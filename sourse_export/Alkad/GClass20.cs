using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameWer;
using Microsoft.Win32;

// Token: 0x02000031 RID: 49
public class GClass20
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060000BE RID: 190 RVA: 0x00002474 File Offset: 0x00000674
	internal static string String_0
	{
		get
		{
			return Registry.GetValue(DeProtectType.ArgValue_367, DeProtectType.ArgValue_368, DeProtectType.ArgValue_369).ToString();
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x0000248F File Offset: 0x0000068F
	internal static void smethod_0()
	{
		GClass20.ShowWindow(GClass20.GetConsoleWindow(), 0);
	}

	// Token: 0x060000C0 RID: 192
	[DllImport("kernel32.dll")]
	internal static extern IntPtr GetConsoleWindow();

	// Token: 0x060000C1 RID: 193
	[DllImport("user32.dll")]
	internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	// Token: 0x060000C2 RID: 194
	[DllImport("kernel32.dll")]
	internal static extern IntPtr GetModuleHandle(string running);

	// Token: 0x060000C3 RID: 195
	[Obfuscation]
	[DllImport("unmanaged.dll", CallingConvention = CallingConvention.StdCall)]
	private static extern IntPtr GetOtherHash();

	// Token: 0x060000C4 RID: 196
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

	// Token: 0x060000C5 RID: 197
	[Obfuscation]
	[DllImport("unmanaged.dll", CallingConvention = CallingConvention.StdCall)]
	private static extern IntPtr VerifyApplicationCat(ref int len);

	// Token: 0x060000C6 RID: 198
	[DllImport("user32.dll")]
	private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

	// Token: 0x060000C7 RID: 199 RVA: 0x0000249D File Offset: 0x0000069D
	internal static void smethod_1(Keys keys_0)
	{
		GClass20.keybd_event((byte)keys_0, 0, 1, 0);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x000024A9 File Offset: 0x000006A9
	internal static void smethod_2(Keys keys_0)
	{
		GClass20.keybd_event((byte)keys_0, 0, 3, 0);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00005808 File Offset: 0x00003A08
	internal static ulong[] smethod_3()
	{
		List<ulong> list = new List<ulong>();
		int num = 0;
		IntPtr source = GClass20.VerifyApplicationCat(ref num);
		if (num != 0)
		{
			byte[] array = new byte[num];
			Marshal.Copy(source, array, 0, num);
			string @string = Encoding.UTF8.GetString(array);
			string[] array2 = @string.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array2.Length; i++)
			{
				string s = array2[i].Trim();
				ulong item = 0UL;
				if (ulong.TryParse(s, out item))
				{
					list.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060000CA RID: 202 RVA: 0x000058AC File Offset: 0x00003AAC
	[Obfuscation]
	internal static string String_1
	{
		get
		{
			if (string.IsNullOrEmpty(GClass20.string_0))
			{
				Thread thread = new Thread(new ThreadStart(GClass20.Class14.class14_0.method_0));
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();
			}
			return GClass20.string_0;
		}
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00005904 File Offset: 0x00003B04
	internal static string smethod_4(string string_1)
	{
		string result;
		if (!string.IsNullOrEmpty(string_1))
		{
			byte[] array = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(string_1));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString(DeProtectType.ArgValue_370));
			}
			result = stringBuilder.ToString();
		}
		else
		{
			result = string.Empty;
		}
		return result;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00005974 File Offset: 0x00003B74
	internal static string smethod_5(string string_1)
	{
		if (!string.IsNullOrEmpty(string_1))
		{
			using (MD5 md = MD5.Create())
			{
				byte[] bytes = Encoding.ASCII.GetBytes(string_1);
				byte[] array = md.ComputeHash(bytes);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString(DeProtectType.ArgValue_371));
				}
				return stringBuilder.ToString().ToLower();
			}
		}
		return string.Empty;
	}

	// Token: 0x040002A8 RID: 680
	private const int int_0 = 1;

	// Token: 0x040002A9 RID: 681
	private const int int_1 = 2;

	// Token: 0x040002AA RID: 682
	private static string string_0 = "";

	// Token: 0x02000032 RID: 50
	[CompilerGenerated]
	[Serializable]
	private sealed class Class14
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00005A10 File Offset: 0x00003C10
		internal void method_0()
		{
			IntPtr otherHash = GClass20.GetOtherHash();
			byte[] array = new byte[64];
			Marshal.Copy(otherHash, array, 0, 64);
			GClass20.string_0 = Encoding.UTF8.GetString(array);
		}

		// Token: 0x040002AB RID: 683
		public static readonly GClass20.Class14 class14_0 = new GClass20.Class14();

		// Token: 0x040002AC RID: 684
		public static ThreadStart threadStart_0;
	}
}
