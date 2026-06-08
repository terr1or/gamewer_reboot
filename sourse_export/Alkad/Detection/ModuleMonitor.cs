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
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ModuleMonitor
{
	internal static void Start()
	{
		FileLogger.Log(DeProtectType.ArgValue_233, DeProtectType.ArgValue_234);
		ModuleMonitor.smethod_3();
		ProcessModuleRegistry.action_0 = new Action<ProcessModuleInfo>(ModuleMonitor.ReportModuleIfNeeded);
		ProcessModuleRegistry.Start();
		ModuleMonitor.smethod_1();
		RetryScheduler.RunForeverDelayed(new Action(ModuleMonitor.ScanLoop), new Action<Exception>(ModuleMonitor.Class10.class10_0.method_0), 15f);
	}
	private static void smethod_1()
	{
		ModuleMonitor.udpClient_0 = new UdpClient(51110);
		ThreadPool.QueueUserWorkItem(new WaitCallback(ModuleMonitor.Class10.class10_0.method_1));
	}
	private static void smethod_2(string string_0)
	{
		ProcessModuleInfo gclass = new ProcessModuleInfo
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
			gclass.bool_0 = ProcessModuleRegistry.IsSignedFile(string_0);
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
		ProcessModuleRegistry.AddModule(gclass);
	}
	private static void smethod_3()
	{
		FileLogger.Log(DeProtectType.ArgValue_237, DeProtectType.ArgValue_238);
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
	internal static void Stop()
	{
		FileLogger.Log(DeProtectType.ArgValue_240, DeProtectType.ArgValue_241);
		try
		{
			ProcessModuleRegistry.thread_0.Abort();
		}
		catch
		{
		}
	}
	private static void InjectSdkIntoProcess(int int_0, string string_0)
	{
		if (int_0 <= 0)
		{
			throw new ArgumentException(DeProtectType.ArgValue_242 + int_0.ToString(), DeProtectType.ArgValue_243);
		}
		if (string.IsNullOrWhiteSpace(string_0) || !File.Exists(string_0))
		{
			throw new ArgumentException(string.Format(DeProtectType.ArgValue_244, string_0));
		}
		IntPtr intPtr = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.CreateThread | NativeMethods.ProcessAccessFlags.VirtualMemoryOperation | NativeMethods.ProcessAccessFlags.VirtualMemoryRead | NativeMethods.ProcessAccessFlags.VirtualMemoryWrite | NativeMethods.ProcessAccessFlags.Terminate0, false, int_0);
		NativeCallGuard.ThrowIfFailed(intPtr == IntPtr.Zero, DeProtectType.ArgValue_245, new object[]
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
		IntPtr intPtr2 = NativeMethods.VirtualAllocEx(intPtr, IntPtr.Zero, (uint)bytes.Length, NativeMethods.AllocationType.Commit | NativeMethods.AllocationType.Reserve, NativeMethods.MemoryProtection.ExecuteReadWrite);
		NativeCallGuard.ThrowIfFailed(intPtr2 == IntPtr.Zero, DeProtectType.ArgValue_251, Array.Empty<object>());
		IntPtr intPtr3;
		NativeCallGuard.ThrowIfFailed(!NativeMethods.WriteProcessMemory(intPtr, intPtr2, bytes, bytes.Length, out intPtr3), DeProtectType.ArgValue_252, Array.Empty<object>());
		IntPtr moduleHandle = NativeMethods.GetModuleHandle(DeProtectType.ArgValue_253);
		NativeCallGuard.ThrowIfFailed(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_254, Array.Empty<object>());
		IntPtr procAddress = NativeMethods.GetProcAddress(moduleHandle, DeProtectType.ArgValue_255);
		NativeCallGuard.ThrowIfFailed(procAddress == IntPtr.Zero, DeProtectType.ArgValue_256, Array.Empty<object>());
		IntPtr value = ModuleMonitor.CreateNtThread(intPtr, procAddress, intPtr2);
		NativeCallGuard.ThrowIfFailed(value == IntPtr.Zero, DeProtectType.ArgValue_257, Array.Empty<object>());
		NativeMethods.CloseHandle(intPtr);
	}
	private unsafe static IntPtr CreateNtThread(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		IntPtr moduleHandle = NativeMethods.GetModuleHandle(DeProtectType.ArgValue_258);
		NativeCallGuard.ThrowIfFailed(moduleHandle == IntPtr.Zero, DeProtectType.ArgValue_259, Array.Empty<object>());
		IntPtr procAddress = NativeMethods.GetProcAddress(moduleHandle, DeProtectType.ArgValue_260);
		NativeCallGuard.ThrowIfFailed(procAddress == IntPtr.Zero, DeProtectType.ArgValue_261, Array.Empty<object>());
		NativeMethods.NtCreateThreadExDelegate @delegate = (NativeMethods.NtCreateThreadExDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(NativeMethods.NtCreateThreadExDelegate));
		NativeCallGuard.ThrowIfFailed(@delegate == null, DeProtectType.ArgValue_262, Array.Empty<object>());
		int num = 0;
		int num2 = 0;
		NativeMethods.NtCreateThreadExBuffer @struct = new NativeMethods.NtCreateThreadExBuffer
		{
			Size = sizeof(NativeMethods.NtCreateThreadExBuffer),
			Attribute1 = 65539U,
			Size1 = 8U,
			Value1 = new IntPtr((void*)(&num2)),
			Unknown1 = 0U,
			Attribute2 = 65540U,
			Size2 = 4U,
			Value2 = new IntPtr((void*)(&num)),
			Unknown2 = 0U
		};
		bool is64BitProcess = Environment.Is64BitProcess;
		IntPtr zero = IntPtr.Zero;
		@delegate(out zero, 2097151U, IntPtr.Zero, intptr_0, intptr_1, intptr_2, 0, 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? 65535U : 0U, is64BitProcess ? IntPtr.Zero : new IntPtr((void*)(&@struct)));
		NativeCallGuard.ThrowIfFailed(zero == IntPtr.Zero, DeProtectType.ArgValue_263, Array.Empty<object>());
		return zero;
	}
	private static void ReportModuleIfNeeded(ProcessModuleInfo gclass29_0)
	{
		if (!ModuleMonitor.smethod_11(gclass29_0) && !ModuleMonitor.smethod_9(gclass29_0))
		{
			try
			{
				if (gclass29_0.String_1.EndsWith(DeProtectType.ArgValue_264) && gclass29_0.uint_0 > 0U)
				{
					FileLogger.Log(DeProtectType.ArgValue_265, DeProtectType.ArgValue_266);
					ModuleMonitor.InjectSdkIntoProcess((int)gclass29_0.uint_0, AppDomain.CurrentDomain.BaseDirectory + DeProtectType.ArgValue_267);
					FileLogger.Log(DeProtectType.ArgValue_268, DeProtectType.ArgValue_269);
				}
			}
			catch (Exception ex)
			{
				FileLogger.Log(DeProtectType.ArgValue_270, DeProtectType.ArgValue_271 + ex.Message);
			}
			if (ModuleMonitor.hashSet_0 != null)
			{
				bool flag = false;
				HashSet<string> obj = ModuleMonitor.hashSet_0;
				lock (obj)
				{
					if (!ModuleMonitor.hashSet_0.Contains(gclass29_0.String_1))
					{
						ModuleMonitor.hashSet_0.Add(gclass29_0.String_1);
						flag = true;
					}
				}
				if (flag)
				{
					ServerWebSocketClient.SendEncrypted(new DetectionReportMessage
					{
						gstruct0_0 = new DetectionFinding[]
						{
							new DetectionFinding
							{
								String_0 = (string.IsNullOrEmpty(gclass29_0.String_3) ? HashUtility.ComputeMd5(gclass29_0.String_0) : gclass29_0.String_3),
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
	internal static void ScanLoop()
	{
		if (ModuleMonitor.hashSet_0 != null)
		{
			ProcessModuleInfo[] array = ProcessModuleRegistry.GetSnapshot();
			List<DetectionFinding> list = new List<DetectionFinding>();
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					HashSet<string> obj = ModuleMonitor.hashSet_0;
					lock (obj)
					{
						if (!ModuleMonitor.hashSet_0.Contains(array[i].String_1))
						{
							ModuleMonitor.hashSet_0.Add(array[i].String_1);
							list.Add(new DetectionFinding
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
					FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
				}
			}
			if (list.Count > 0)
			{
				ServerWebSocketClient.SendEncrypted(new DetectionReportMessage
				{
					gstruct0_0 = list.ToArray()
				}.vmethod_0());
			}
		}
	}
	private static bool smethod_9(ProcessModuleInfo gclass29_0)
	{
		string text = gclass29_0.String_0.ToLower();
		for (int i = 0; i < ProtectedProcessCatalog.string_0.Length; i++)
		{
			if (text.Contains(ProtectedProcessCatalog.string_0[i]))
			{
				FileLogger.Log(DeProtectType.ArgValue_274, DeProtectType.ArgValue_275 + gclass29_0.String_0);
				return ModuleMonitor.smethod_10(gclass29_0);
			}
		}
		return false;
	}
	private static bool smethod_10(ProcessModuleInfo gclass29_0)
	{
		if (gclass29_0.uint_0 > 0U)
		{
			FileLogger.Log(DeProtectType.ArgValue_276, DeProtectType.ArgValue_277 + gclass29_0.String_0 + DeProtectType.ArgValue_278);
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
	private static bool smethod_11(ProcessModuleInfo gclass29_0)
	{
		int num = (int)DateTime.Now.Subtract(RuntimeGuard.DateTime_0).TotalSeconds;
		bool result;
		if (num < int.Parse(DeProtectType.ArgValue_281) && string.IsNullOrEmpty(gclass29_0.String_2) == (int.Parse(DeProtectType.ArgValue_282) == 1) && Directory.Exists(gclass29_0.String_2 + DeProtectType.ArgValue_283 + gclass29_0.String_0 + DeProtectType.ArgValue_284))
		{
			FileLogger.Log(DeProtectType.ArgValue_285, DeProtectType.ArgValue_286 + gclass29_0.String_2);
			ModuleMonitor.smethod_10(gclass29_0);
			result = true;
		}
		else
		{
			result = false;
		}
		return result;
	}
	internal static HashSet<string> hashSet_0 = null;
	internal static UdpClient udpClient_0;
	[CompilerGenerated]
	[Serializable]
	private sealed class Class10
	{
		internal void method_0(Exception exception_0)
		{
		}
		internal void method_1(object object_0)
		{
			IPEndPoint ipendPoint = null;
			FileLogger.Log(DeProtectType.ArgValue_287, DeProtectType.ArgValue_288);
			for (;;)
			{
				try
				{
					byte[] array = ModuleMonitor.udpClient_0.Receive(ref ipendPoint);
					Console.WriteLine(DeProtectType.ArgValue_289 + array[0].ToString(DeProtectType.ArgValue_290));
					if (array[0] != 255)
					{
						ModuleMonitor.Class11 @class = new ModuleMonitor.Class11();
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
		public static readonly ModuleMonitor.Class10 class10_0 = new ModuleMonitor.Class10();
		public static Action<Exception> action_0;
		public static WaitCallback waitCallback_0;
	}
	[CompilerGenerated]
	private sealed class Class11
	{
		internal void method_0(object object_0)
		{
			ModuleMonitor.smethod_2(this.string_0);
		}
		public string string_0;
	}
}
