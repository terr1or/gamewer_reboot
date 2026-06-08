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
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class HardwareFingerprint
{
	// (get) Token: 0x060000BE RID: 190 RVA: 0x00002474 File Offset: 0x00000674
	internal static string String_0
	{
		get
		{
			return Registry.GetValue(DeProtectType.ArgValue_367, DeProtectType.ArgValue_368, DeProtectType.ArgValue_369).ToString();
		}
	}
	internal static void smethod_0()
	{
		HardwareFingerprint.ShowWindow(HardwareFingerprint.GetConsoleWindow(), 0);
	}
	[DllImport("kernel32.dll")]
	internal static extern IntPtr GetConsoleWindow();
	[DllImport("user32.dll")]
	internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
	[DllImport("kernel32.dll")]
	internal static extern IntPtr GetModuleHandle(string running);
	[Obfuscation]
	[DllImport("unmanaged.dll", CallingConvention = CallingConvention.StdCall)]
	private static extern IntPtr GetOtherHash();
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);
	[Obfuscation]
	[DllImport("unmanaged.dll", CallingConvention = CallingConvention.StdCall)]
	private static extern IntPtr VerifyApplicationCat(ref int len);
	[DllImport("user32.dll")]
	private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
	internal static void smethod_1(Keys keys_0)
	{
		HardwareFingerprint.keybd_event((byte)keys_0, 0, 1, 0);
	}
	internal static void smethod_2(Keys keys_0)
	{
		HardwareFingerprint.keybd_event((byte)keys_0, 0, 3, 0);
	}
	internal static ulong[] smethod_3()
	{
		List<ulong> list = new List<ulong>();
		int num = 0;
		IntPtr source = HardwareFingerprint.VerifyApplicationCat(ref num);
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
	// (get) Token: 0x060000CA RID: 202 RVA: 0x000058AC File Offset: 0x00003AAC
	[Obfuscation]
	internal static string String_1
	{
		get
		{
			if (string.IsNullOrEmpty(HardwareFingerprint.string_0))
			{
				Thread thread = new Thread(new ThreadStart(HardwareFingerprint.Class14.class14_0.method_0));
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();
			}
			return HardwareFingerprint.string_0;
		}
	}
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
	private const int int_0 = 1;
	private const int int_1 = 2;
	private static string string_0 = "";
	[CompilerGenerated]
	[Serializable]
	private sealed class Class14
	{
		internal void method_0()
		{
			IntPtr otherHash = HardwareFingerprint.GetOtherHash();
			byte[] array = new byte[64];
			Marshal.Copy(otherHash, array, 0, 64);
			HardwareFingerprint.string_0 = Encoding.UTF8.GetString(array);
		}
		public static readonly HardwareFingerprint.Class14 class14_0 = new HardwareFingerprint.Class14();
		public static ThreadStart threadStart_0;
	}
}
