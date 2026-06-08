using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using GameWer;

// Token: 0x02000020 RID: 32
public class GClass8
{
	// Token: 0x0600006E RID: 110 RVA: 0x00004258 File Offset: 0x00002458
	internal static void smethod_0()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_233, DeProtectType.ArgValue_234);
		GClass8.smethod_3();
		GClass30.action_0 = new Action<GClass29>(GClass8.smethod_7);
		GClass30.smethod_0();
		GClass8.smethod_1();
		GClass25.smethod_1(new Action(GClass8.smethod_8), new Action<Exception>(GClass8.Class10.class10_0.method_0), 15f);
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000022CF File Offset: 0x000004CF
	private static void smethod_1()
	{
		GClass8.udpClient_0 = new UdpClient(51110);
		ThreadPool.QueueUserWorkItem(new WaitCallback(GClass8.Class10.class10_0.method_1));
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000042CC File Offset: 0x000024CC
	private static void smethod_2(string string_0)
	{
		GClass29 gclass = new GClass29
		{
			uint_0 = 0U,
			String_4 = DeProtectType.ArgValue_235,
			String_1 = string_0
		};
		if (File.Exists(string_0))
		{
			FileInfo fileInfo = new FileInfo(string_0);
			gclass.String_0 = (fileInfo.Name.EndsWith(fileInfo.Extension) ? fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length - 1) : fileInfo.Name);
			gclass.String_6 = FileVersionInfo.GetVersionInfo(gclass.String_1).OriginalFilename;
			DirectoryInfo directoryInfo = new DirectoryInfo(gclass.String_1);
			gclass.String_2 = new FileInfo(directoryInfo.FullName).Directory.FullName;
			gclass.bool_0 = GClass30.smethod_5(string_0);
			gclass.long_0 = fileInfo.Length;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(gclass.String_1))
				{
					gclass.String_3 = BitConverter.ToString(md.ComputeHash(fileStream)).Replace(DeProtectType.ArgValue_236, "").ToLowerInvariant();
				}
				goto IL_167;
			}
		}
		gclass.String_0 = gclass.String_1;
		gclass.String_6 = "";
		gclass.String_2 = "";
		gclass.bool_0 = false;
		gclass.long_0 = 0L;
		gclass.String_3 = "";
		IL_167:
		GClass30.smethod_4(gclass);
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00004464 File Offset: 0x00002664
	private static void smethod_3()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_237, DeProtectType.ArgValue_238);
		Process[] processes = Process.GetProcesses();
		for (int i = 0; i < processes.Length; i++)
		{
			try
			{
				string fullName = new FileInfo(processes[i].MainModule.FileName).Directory.FullName;
				if (File.Exists(fullName + DeProtectType.ArgValue_239))
				{
					processes[i].Kill();
					Environment.Exit(0);
					break;
				}
			}
			catch
			{
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000044EC File Offset: 0x000026EC
	internal static void smethod_4()
	{
		GClass7.smethod_0(DeProtectType.ArgValue_240, DeProtectType.ArgValue_241);
		try
		{
			GClass30.thread_0.Abort();
		}
		catch
		{
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00004528 File Offset: 0x00002728
	private static void smethod_5(int int_0, string string_0)
	{
		if (int_0 <= 0)
		{
			throw new ArgumentException(DeProtectType.ArgValue_242 + int_0.ToString(), DeProtectType.ArgValue_243);
		}
		if (string.IsNullOrWhiteSpace(string_0) || !File.Exists(string_0))
		{
			throw new ArgumentException(string.Format(DeProtectType.ArgValue_244, string_0));
		}
		IntPtr intPtr = Class0.OpenProcess(Class0.Enum0.flag_2 | Class0.Enum0.flag_3 | Class0.Enum0.flag_4 | Class0.Enum0.flag_5 | Class0.Enum0.flag_10, false, int_0);
		Class1.smethod_0(intPtr == IntPtr.Zero, DeProtectType.ArgValue_245, new object[]
		{
			int_0
		});
		if (intPtr == IntPtr.Zero)
		{
			throw new ArgumentException(DeProtectType.ArgValue_246, DeProtectType.ArgValue_247);
		}
		if (string.IsNullOrWhiteSpace(string_0))
		{
			throw new ArgumentException(DeProtectType.ArgValue_248, DeProtectType.ArgValue_249);
		}
		byte[] bytes = Encoding.ASCII.GetBytes(string_0 + DeProtectType.ArgValue_250);
		IntPtr intPtr2 = Class0.VirtualAllocEx(intPtr, IntPtr.Zero, (uint)bytes.Length, Class0.Enum1.flag_0 | Class0.Enum1.flag_1, Class0.Enum2.flag_2);
		Class1.smethod_0(intPtr2 == IntPtr.Zero, DeProtectType.ArgValue_251, Array.Empty<object>());
		IntPtr intPtr3;
		Class1.smethod_0(!Class0.WriteProcessMemory(intPtr, intPtr2, bytes, bytes.Length, out intPtr3), DeProtectType.ArgValue_252, Array.Empty<object>());
		IntPtr moduleHandle = Class0.GetModuleHandle(DeProtectType.ArgValue_253);
		Class1.smethod_0(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_254, Array.Empty<object>());
		IntPtr procAddress = Class0.GetProcAddress(moduleHandle, DeProtectType.ArgValue_255);
		Class1.smethod_0(procAddress == IntPtr.Zero, DeProtectType.ArgValue_256, Array.Empty<object>());
		IntPtr value = GClass8.smethod_6(intPtr, procAddress, intPtr2);
		Class1.smethod_0(value == IntPtr.Zero, DeProtectType.ArgValue_257, Array.Empty<object>());
		Class0.CloseHandle(intPtr);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000046CC File Offset: 0x000028CC
	private unsafe static IntPtr smethod_6(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr moduleHandle = Class0.GetModuleHandle(DeProtectType.ArgValue_258);
		Class1.smethod_0(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_259, Array.Empty<object>());
		IntPtr procAddress = Class0.GetProcAddress(moduleHandle, DeProtectType.ArgValue_260);
		Class1.smethod_0(procAddress == IntPtr.Zero, DeProtectType.ArgValue_261, Array.Empty<object>());
		Class0.Delegate0 @delegate = (Class0.Delegate0)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Class0.Delegate0));
		Class1.smethod_0(@delegate == null, DeProtectType.ArgValue_262, Array.Empty<object>());
		int num = 0;
		int num2 = 0;
		Class0.Struct0 @struct = new Class0.Struct0
		{
			int_0 = sizeof(Class0.Struct0),
			uint_0 = 65539U,
			uint_1 = 8U,
			intptr_0 = new IntPtr((void*)(&num2)),
			uint_2 = 0U,
			uint_3 = 65540U,
			uint_4 = 4U,
			intptr_1 = new IntPtr((void*)(&num)),
			uint_5 = 0U
		};
		bool is64BitProcess = Environment.Is64BitProcess;
		IntPtr zero = IntPtr.Zero;
		@delegate(out zero, 2097151U, IntPtr.Zero, intptr_0, intptr_1, intptr_2, 0, 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? IntPtr.Zero : new IntPtr((void*)(&@struct)));
		Class1.smethod_0(zero == IntPtr.Zero, DeProtectType.ArgValue_263, Array.Empty<object>());
		return zero;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00004834 File Offset: 0x00002A34
	private static void smethod_7(GClass29 gclass29_0)
	{
		if (!GClass8.smethod_11(gclass29_0) && !GClass8.smethod_9(gclass29_0))
		{
			try
			{
				if (gclass29_0.String_1.EndsWith(DeProtectType.ArgValue_264) && gclass29_0.uint_0 > 0U)
				{
					GClass7.smethod_0(DeProtectType.ArgValue_265, DeProtectType.ArgValue_266);
					GClass8.smethod_5((int)gclass29_0.uint_0, AppDomain.CurrentDomain.BaseDirectory + DeProtectType.ArgValue_267);
					GClass7.smethod_0(DeProtectType.ArgValue_268, DeProtectType.ArgValue_269);
				}
			}
			catch (Exception ex)
			{
				GClass7.smethod_0(DeProtectType.ArgValue_270, DeProtectType.ArgValue_271 + ex.Message);
			}
			if (GClass8.hashSet_0 != null)
			{
				bool flag = false;
				HashSet<string> obj = GClass8.hashSet_0;
				lock (obj)
				{
					if (!GClass8.hashSet_0.Contains(gclass29_0.String_1))
					{
						GClass8.hashSet_0.Add(gclass29_0.String_1);
						flag = true;
					}
				}
				if (flag)
				{
					GClass6.smethod_1(new GClass17
					{
						gstruct0_0 = new GStruct0[]
						{
							new GStruct0
							{
								String_0 = (string.IsNullOrEmpty(gclass29_0.String_3) ? GClass21.smethod_0(gclass29_0.String_0) : gclass29_0.String_3),
								String_1 = gclass29_0.String_0,
								String_5 = (string.IsNullOrEmpty(gclass29_0.String_1) ? gclass29_0.String_0 : gclass29_0.String_1),
								Boolean_0 = gclass29_0.bool_0,
								Int32_0 = (int)(gclass29_0.long_0 / 1024L),
								String_3 = gclass29_0.String_4,
								String_2 = gclass29_0.String_5,
								String_4 = gclass29_0.String_6
							}
						}
					}.vmethod_0());
				}
			}
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00004A2C File Offset: 0x00002C2C
	internal static void smethod_8()
	{
		if (GClass8.hashSet_0 != null)
		{
			GClass29[] array = GClass30.smethod_1();
			List<GStruct0> list = new List<GStruct0>();
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					HashSet<string> obj = GClass8.hashSet_0;
					lock (obj)
					{
						if (!GClass8.hashSet_0.Contains(array[i].String_1))
						{
							GClass8.hashSet_0.Add(array[i].String_1);
							list.Add(new GStruct0
							{
								String_0 = array[i].String_3,
								String_1 = array[i].String_0,
								String_5 = array[i].String_1,
								Boolean_0 = array[i].bool_0,
								Int32_0 = (int)(array[i].long_0 / 1024L),
								String_3 = array[i].String_4,
								String_2 = array[i].String_5,
								String_4 = array[i].String_6
							});
						}
					}
				}
				catch (Exception ex)
				{
					string argValue_ = DeProtectType.ArgValue_272;
					string argValue_2 = DeProtectType.ArgValue_273;
					Exception ex2 = ex;
					GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
				}
			}
			if (list.Count > 0)
			{
				GClass6.smethod_1(new GClass17
				{
					gstruct0_0 = list.ToArray()
				}.vmethod_0());
			}
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00004BBC File Offset: 0x00002DBC
	private static bool smethod_9(GClass29 gclass29_0)
	{
		string text = gclass29_0.String_0.ToLower();
		for (int i = 0; i < GClass27.string_0.Length; i++)
		{
			if (text.Contains(GClass27.string_0[i]))
			{
				GClass7.smethod_0(DeProtectType.ArgValue_274, DeProtectType.ArgValue_275 + gclass29_0.String_0);
				return GClass8.smethod_10(gclass29_0);
			}
		}
		return false;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00004C20 File Offset: 0x00002E20
	private static bool smethod_10(GClass29 gclass29_0)
	{
		if (gclass29_0.uint_0 > 0U)
		{
			GClass7.smethod_0(DeProtectType.ArgValue_276, DeProtectType.ArgValue_277 + gclass29_0.String_0 + DeProtectType.ArgValue_278);
			try
			{
				Process processById = Process.GetProcessById((int)gclass29_0.uint_0);
				processById.Kill();
				return true;
			}
			catch
			{
				try
				{
					Process.Start(DeProtectType.ArgValue_279, DeProtectType.ArgValue_280 + gclass29_0.uint_0.ToString());
					return true;
				}
				catch (Exception)
				{
				}
			}
		}
		return false;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00004CB8 File Offset: 0x00002EB8
	private static bool smethod_11(GClass29 gclass29_0)
	{
		int num = (int)DateTime.Now.Subtract(GClass4.DateTime_0).TotalSeconds;
		bool result;
		if (num < int.Parse(DeProtectType.ArgValue_281) && string.IsNullOrEmpty(gclass29_0.String_2) == (int.Parse(DeProtectType.ArgValue_282) == 1) && Directory.Exists(gclass29_0.String_2 + DeProtectType.ArgValue_283 + gclass29_0.String_0 + DeProtectType.ArgValue_284))
		{
			GClass7.smethod_0(DeProtectType.ArgValue_285, DeProtectType.ArgValue_286 + gclass29_0.String_2);
			GClass8.smethod_10(gclass29_0);
			result = true;
		}
		else
		{
			result = false;
		}
		return result;
	}

	// Token: 0x04000271 RID: 625
	internal static HashSet<string> hashSet_0 = null;

	// Token: 0x04000272 RID: 626
	internal static UdpClient udpClient_0;

	// Token: 0x02000021 RID: 33
	[CompilerGenerated]
	[Serializable]
	private sealed class Class10
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_0(Exception exception_0)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004D5C File Offset: 0x00002F5C
		internal void method_1(object object_0)
		{
			IPEndPoint ipendPoint = null;
			GClass7.smethod_0(DeProtectType.ArgValue_287, DeProtectType.ArgValue_288);
			for (;;)
			{
				try
				{
					byte[] array = GClass8.udpClient_0.Receive(ref ipendPoint);
					Console.WriteLine(DeProtectType.ArgValue_289 + array[0].ToString(DeProtectType.ArgValue_290));
					if (array[0] != 255)
					{
						GClass8.Class11 @class = new GClass8.Class11();
						int count = BitConverter.ToInt32(array, 1);
						@class.string_0 = Encoding.UTF8.GetString(array, 5, count);
						Console.WriteLine(DeProtectType.ArgValue_291 + @class.string_0);
						ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x04000273 RID: 627
		public static readonly GClass8.Class10 class10_0 = new GClass8.Class10();

		// Token: 0x04000274 RID: 628
		public static Action<Exception> action_0;

		// Token: 0x04000275 RID: 629
		public static WaitCallback waitCallback_0;
	}

	// Token: 0x02000022 RID: 34
	[CompilerGenerated]
	private sealed class Class11
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00002319 File Offset: 0x00000519
		internal void method_0(object object_0)
		{
			GClass8.smethod_2(this.string_0);
		}

		// Token: 0x04000276 RID: 630
		public string string_0;
	}
}
