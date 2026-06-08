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
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class SystemInventory
{
	// (get) Token: 0x06000122 RID: 290 RVA: 0x000025F9 File Offset: 0x000007F9
	internal static List<string> List_0 { get; } = new List<string>();
	internal static void smethod_0()
	{
		SystemInventory.smethod_3();
		SystemInventory.smethod_2();
		SystemInventory.smethod_1();
	}
	private static void smethod_1()
	{
		SystemInventory.string_15 = string.Join(DeProtectType.ArgValue_479, Environment.GetLogicalDrives());
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
			SystemInventory.string_16 = num.ToString();
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
								SystemInventory.string_12 += propertyData.Value.ToString();
							}
						}
						else
						{
							SystemInventory.string_11 = propertyData.Value.ToString();
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
										SystemInventory.string_14 = propertyData2.Value.ToString();
									}
								}
								else
								{
									SystemInventory.string_13 = propertyData2.Value.ToString();
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
			SystemInventory.string_2 = Registry.GetValue(DeProtectType.ArgValue_492, DeProtectType.ArgValue_493, DeProtectType.ArgValue_494).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_3 = Registry.GetValue(DeProtectType.ArgValue_495, DeProtectType.ArgValue_496, DeProtectType.ArgValue_497).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_4 = Registry.GetValue(DeProtectType.ArgValue_498, DeProtectType.ArgValue_499, DeProtectType.ArgValue_500).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_5 = Registry.GetValue(DeProtectType.ArgValue_501, DeProtectType.ArgValue_502, DeProtectType.ArgValue_503).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_6 = Registry.GetValue(DeProtectType.ArgValue_504, DeProtectType.ArgValue_505, DeProtectType.ArgValue_506).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_7 = Registry.GetValue(DeProtectType.ArgValue_507, DeProtectType.ArgValue_508, DeProtectType.ArgValue_509).ToString();
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_8 = Environment.MachineName;
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_9 = Environment.UserName;
		}
		catch
		{
		}
		try
		{
			SystemInventory.bool_0 = Environment.Is64BitOperatingSystem;
		}
		catch
		{
		}
		try
		{
			SystemInventory.string_10 = ((int)(new ComputerInfo().TotalPhysicalMemory / ulong.Parse(DeProtectType.ArgValue_510) / ulong.Parse(DeProtectType.ArgValue_511))).ToString();
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
	private static void smethod_2()
	{
		if (SystemInventory.List_0.Count > int.Parse(DeProtectType.ArgValue_512))
		{
			SystemInventory.string_0 = HashUtility.ComputeMd5(SystemInventory.List_0[int.Parse(DeProtectType.ArgValue_513)] + ((SystemInventory.List_0.Count > int.Parse(DeProtectType.ArgValue_514)) ? SystemInventory.List_0[int.Parse(DeProtectType.ArgValue_515)] : ""));
		}
	}
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
			SystemInventory.Class19 @class = new SystemInventory.Class19();
			StreamReader streamReader = SystemInventory.smethod_4(DeProtectType.ArgValue_519, DeProtectType.ArgValue_520);
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
			@class.string_0 = list.Find(new Predicate<string>(SystemInventory.Class20.class20_0.method_0));
			if (string.IsNullOrEmpty(@class.string_0) || source.Any(new Func<string, bool>(@class.method_0)))
			{
				@class.string_0 = list.Find(new Predicate<string>(SystemInventory.Class20.class20_0.method_1));
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
									SystemInventory.List_0.Add(HashUtility.ComputeMd5(value));
								}
							}
						}
					}
				}
			}
			else
			{
				SystemInventory.List_0.Add(@class.string_0);
			}
		}
		catch
		{
		}
		string value2 = NetworkInterface.GetAllNetworkInterfaces().Where(new Func<NetworkInterface, bool>(SystemInventory.Class20.class20_0.method_2)).Select(new Func<NetworkInterface, string>(SystemInventory.Class20.class20_0.method_3)).FirstOrDefault<string>();
		if (!source.Contains(value2))
		{
			SystemInventory.List_0.Add(HashUtility.ComputeMd5(value2));
		}
	}
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
	internal static string string_0 = string.Empty;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly List<string> list_0;
	internal static string string_1 = string.Empty;
	internal static string string_2 = string.Empty;
	internal static string string_3 = string.Empty;
	internal static string string_4 = string.Empty;
	internal static string string_5 = string.Empty;
	internal static string string_6 = string.Empty;
	internal static string string_7 = string.Empty;
	internal static string string_8 = string.Empty;
	internal static string string_9 = string.Empty;
	internal static bool bool_0 = false;
	internal static string string_10 = string.Empty;
	internal static string string_11 = string.Empty;
	internal static string string_12 = string.Empty;
	internal static string string_13 = string.Empty;
	internal static string string_14 = string.Empty;
	internal static string string_15 = string.Empty;
	internal static string string_16 = string.Empty;
	[CompilerGenerated]
	private sealed class Class19
	{
		internal bool method_0(string string_1)
		{
			return string_1 == this.string_0;
		}
		internal bool method_1(string string_1)
		{
			return string_1 == this.string_0;
		}
		public string string_0;
	}
	[CompilerGenerated]
	[Serializable]
	private sealed class Class20
	{
		internal bool method_0(string string_0)
		{
			return string_0.Contains(DeProtectType.ArgValue_533);
		}
		internal bool method_1(string string_0)
		{
			return string_0.Contains(DeProtectType.ArgValue_534);
		}
		internal bool method_2(NetworkInterface networkInterface_0)
		{
			return networkInterface_0.OperationalStatus == OperationalStatus.Up && networkInterface_0.NetworkInterfaceType != NetworkInterfaceType.Loopback;
		}
		internal string method_3(NetworkInterface networkInterface_0)
		{
			return networkInterface_0.GetPhysicalAddress().ToString();
		}
		public static readonly SystemInventory.Class20 class20_0 = new SystemInventory.Class20();
		public static Predicate<string> predicate_0;
		public static Predicate<string> predicate_1;
		public static Func<NetworkInterface, bool> func_0;
		public static Func<NetworkInterface, string> func_1;
	}
}
