using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using GameWer;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

// Token: 0x02000044 RID: 68
public class GClass33
{
	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000122 RID: 290 RVA: 0x000025F9 File Offset: 0x000007F9
	internal static List<string> List_0 { get; } = new List<string>();

	// Token: 0x06000123 RID: 291 RVA: 0x00002600 File Offset: 0x00000800
	internal static void smethod_0()
	{
		GClass33.smethod_3();
		GClass33.smethod_2();
		GClass33.smethod_1();
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00007574 File Offset: 0x00005774
	private static void smethod_1()
	{
		GClass33.string_15 = string.Join(DeProtectType.ArgValue_479, Environment.GetLogicalDrives());
		try
		{
			uint num = uint.Parse(DeProtectType.ArgValue_480);
			DriveInfo[] drives = DriveInfo.GetDrives();
			for (int i = 0; i < drives.Length; i++)
			{
				try
				{
					num += (uint)(drives[i].TotalSize / (long)int.Parse(DeProtectType.ArgValue_481) / (long)int.Parse(DeProtectType.ArgValue_482));
				}
				catch
				{
				}
			}
			GClass33.string_16 = num.ToString();
		}
		catch (Exception)
		{
		}
		try
		{
			ManagementClass managementClass = new ManagementClass(DeProtectType.ArgValue_483);
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				foreach (PropertyData propertyData in managementBaseObject.Properties)
				{
					string name = propertyData.Name;
					string text = name;
					if (text != null)
					{
						if (!(text == DeProtectType.ArgValue_484))
						{
							if (text == DeProtectType.ArgValue_485 || text == DeProtectType.ArgValue_486 || text == DeProtectType.ArgValue_487)
							{
								GClass33.string_12 += propertyData.Value.ToString();
							}
						}
						else
						{
							GClass33.string_11 = propertyData.Value.ToString();
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		try
		{
			ManagementClass managementClass2 = new ManagementClass(DeProtectType.ArgValue_488);
			ManagementObjectCollection instances2 = managementClass2.GetInstances();
			foreach (ManagementBaseObject managementBaseObject2 in instances2)
			{
				try
				{
					foreach (PropertyData propertyData2 in managementBaseObject2.Properties)
					{
						try
						{
							string name2 = propertyData2.Name;
							string text2 = name2;
							if (text2 != null)
							{
								if (!(text2 == DeProtectType.ArgValue_489))
								{
									if (text2 == DeProtectType.ArgValue_490)
									{
										GClass33.string_14 = propertyData2.Value.ToString();
									}
								}
								else
								{
									GClass33.string_13 = propertyData2.Value.ToString();
								}
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
			Console.WriteLine(DeProtectType.ArgValue_491);
		}
		try
		{
			GClass33.string_2 = Registry.GetValue(DeProtectType.ArgValue_492, DeProtectType.ArgValue_493, DeProtectType.ArgValue_494).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_3 = Registry.GetValue(DeProtectType.ArgValue_495, DeProtectType.ArgValue_496, DeProtectType.ArgValue_497).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_4 = Registry.GetValue(DeProtectType.ArgValue_498, DeProtectType.ArgValue_499, DeProtectType.ArgValue_500).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_5 = Registry.GetValue(DeProtectType.ArgValue_501, DeProtectType.ArgValue_502, DeProtectType.ArgValue_503).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_6 = Registry.GetValue(DeProtectType.ArgValue_504, DeProtectType.ArgValue_505, DeProtectType.ArgValue_506).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_7 = Registry.GetValue(DeProtectType.ArgValue_507, DeProtectType.ArgValue_508, DeProtectType.ArgValue_509).ToString();
		}
		catch
		{
		}
		try
		{
			GClass33.string_8 = Environment.MachineName;
		}
		catch
		{
		}
		try
		{
			GClass33.string_9 = Environment.UserName;
		}
		catch
		{
		}
		try
		{
			GClass33.bool_0 = Environment.Is64BitOperatingSystem;
		}
		catch
		{
		}
		try
		{
			GClass33.string_10 = ((int)(new ComputerInfo().TotalPhysicalMemory / ulong.Parse(DeProtectType.ArgValue_510) / ulong.Parse(DeProtectType.ArgValue_511))).ToString();
		}
		catch
		{
		}
		try
		{
		}
		catch
		{
		}
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00007B20 File Offset: 0x00005D20
	private static void smethod_2()
	{
		if (GClass33.List_0.Count > int.Parse(DeProtectType.ArgValue_512))
		{
			GClass33.string_0 = GClass21.smethod_0(GClass33.List_0[int.Parse(DeProtectType.ArgValue_513)] + ((GClass33.List_0.Count > int.Parse(DeProtectType.ArgValue_514)) ? GClass33.List_0[int.Parse(DeProtectType.ArgValue_515)] : ""));
		}
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00007B9C File Offset: 0x00005D9C
	private static void smethod_3()
	{
		string[] source = new string[]
		{
			DeProtectType.ArgValue_516,
			DeProtectType.ArgValue_517,
			DeProtectType.ArgValue_518
		};
		try
		{
			GClass33.Class19 @class = new GClass33.Class19();
			StreamReader streamReader = GClass33.smethod_4(DeProtectType.ArgValue_519, DeProtectType.ArgValue_520);
			for (int i = 0; i < int.Parse(DeProtectType.ArgValue_521); i++)
			{
				streamReader.ReadLine();
			}
			List<string> list = new List<string>();
			while (!streamReader.EndOfStream)
			{
				string item = streamReader.ReadLine();
				list.Add(item);
			}
			@class.string_0 = list.Find(new Predicate<string>(GClass33.Class20.class20_0.method_0));
			if (string.IsNullOrEmpty(@class.string_0) || source.Any(new Func<string, bool>(@class.method_0)))
			{
				@class.string_0 = list.Find(new Predicate<string>(GClass33.Class20.class20_0.method_1));
			}
			if (string.IsNullOrEmpty(@class.string_0) || source.Any(new Func<string, bool>(@class.method_1)))
			{
				for (int j = 0; j < list.Count; j++)
				{
					string text = list[j];
					if (text != null)
					{
						text = text.Trim();
						while (text.Contains(DeProtectType.ArgValue_524))
						{
							text = text.Replace(DeProtectType.ArgValue_522, DeProtectType.ArgValue_523);
						}
						string[] array = text.Trim().Split(new char[]
						{
							' '
						});
						if (array.Length == int.Parse(DeProtectType.ArgValue_525))
						{
							string text2 = array[int.Parse(DeProtectType.ArgValue_526)];
							string value = array[int.Parse(DeProtectType.ArgValue_527)];
							if (!source.Contains(value))
							{
								string[] array2 = text2.Split(new char[]
								{
									'.'
								}, StringSplitOptions.RemoveEmptyEntries);
								if (array2.Length != int.Parse(DeProtectType.ArgValue_528) || ((!(array2[1] == DeProtectType.ArgValue_529) || !(array2[2] == DeProtectType.ArgValue_530)) && (!(array2[1] == DeProtectType.ArgValue_531) || !(array2[2] == DeProtectType.ArgValue_532))))
								{
									GClass33.List_0.Add(GClass21.smethod_0(value));
								}
							}
						}
					}
				}
			}
			else
			{
				GClass33.List_0.Add(@class.string_0);
			}
		}
		catch
		{
		}
		string value2 = NetworkInterface.GetAllNetworkInterfaces().Where(new Func<NetworkInterface, bool>(GClass33.Class20.class20_0.method_2)).Select(new Func<NetworkInterface, string>(GClass33.Class20.class20_0.method_3)).FirstOrDefault<string>();
		if (!source.Contains(value2))
		{
			GClass33.List_0.Add(GClass21.smethod_0(value2));
		}
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00007E9C File Offset: 0x0000609C
	private static StreamReader smethod_4(string string_17, string string_18 = "")
	{
		ProcessStartInfo startInfo = new ProcessStartInfo
		{
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			FileName = string_17,
			Arguments = string_18
		};
		Process process = Process.Start(startInfo);
		return (process != null) ? process.StandardOutput : null;
	}

	// Token: 0x040002F6 RID: 758
	internal static string string_0 = string.Empty;

	// Token: 0x040002F7 RID: 759
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly List<string> list_0;

	// Token: 0x040002F8 RID: 760
	internal static string string_1 = string.Empty;

	// Token: 0x040002F9 RID: 761
	internal static string string_2 = string.Empty;

	// Token: 0x040002FA RID: 762
	internal static string string_3 = string.Empty;

	// Token: 0x040002FB RID: 763
	internal static string string_4 = string.Empty;

	// Token: 0x040002FC RID: 764
	internal static string string_5 = string.Empty;

	// Token: 0x040002FD RID: 765
	internal static string string_6 = string.Empty;

	// Token: 0x040002FE RID: 766
	internal static string string_7 = string.Empty;

	// Token: 0x040002FF RID: 767
	internal static string string_8 = string.Empty;

	// Token: 0x04000300 RID: 768
	internal static string string_9 = string.Empty;

	// Token: 0x04000301 RID: 769
	internal static bool bool_0 = false;

	// Token: 0x04000302 RID: 770
	internal static string string_10 = string.Empty;

	// Token: 0x04000303 RID: 771
	internal static string string_11 = string.Empty;

	// Token: 0x04000304 RID: 772
	internal static string string_12 = string.Empty;

	// Token: 0x04000305 RID: 773
	internal static string string_13 = string.Empty;

	// Token: 0x04000306 RID: 774
	internal static string string_14 = string.Empty;

	// Token: 0x04000307 RID: 775
	internal static string string_15 = string.Empty;

	// Token: 0x04000308 RID: 776
	internal static string string_16 = string.Empty;

	// Token: 0x02000045 RID: 69
	[CompilerGenerated]
	private sealed class Class19
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00002611 File Offset: 0x00000811
		internal bool method_0(string string_1)
		{
			return string_1 == this.string_0;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00002611 File Offset: 0x00000811
		internal bool method_1(string string_1)
		{
			return string_1 == this.string_0;
		}

		// Token: 0x04000309 RID: 777
		public string string_0;
	}

	// Token: 0x02000046 RID: 70
	[CompilerGenerated]
	[Serializable]
	private sealed class Class20
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000262B File Offset: 0x0000082B
		internal bool method_0(string string_0)
		{
			return string_0.Contains(DeProtectType.ArgValue_533);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002638 File Offset: 0x00000838
		internal bool method_1(string string_0)
		{
			return string_0.Contains(DeProtectType.ArgValue_534);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002645 File Offset: 0x00000845
		internal bool method_2(NetworkInterface networkInterface_0)
		{
			return networkInterface_0.OperationalStatus == OperationalStatus.Up && networkInterface_0.NetworkInterfaceType != NetworkInterfaceType.Loopback;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002660 File Offset: 0x00000860
		internal string method_3(NetworkInterface networkInterface_0)
		{
			return networkInterface_0.GetPhysicalAddress().ToString();
		}

		// Token: 0x0400030A RID: 778
		public static readonly GClass33.Class20 class20_0 = new GClass33.Class20();

		// Token: 0x0400030B RID: 779
		public static Predicate<string> predicate_0;

		// Token: 0x0400030C RID: 780
		public static Predicate<string> predicate_1;

		// Token: 0x0400030D RID: 781
		public static Func<NetworkInterface, bool> func_0;

		// Token: 0x0400030E RID: 782
		public static Func<NetworkInterface, string> func_1;
	}
}
