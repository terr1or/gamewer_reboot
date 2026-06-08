using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ProcessModuleRegistry
{
	public static void Start()
	{
		if (!ProcessModuleRegistry.bool_0)
		{
			ProcessModuleRegistry.bool_0 = true;
			ProcessModuleRegistry.thread_0 = new Thread(new ThreadStart(ProcessModuleRegistry.smethod_2));
			ProcessModuleRegistry.thread_0.IsBackground = true;
			ProcessModuleRegistry.thread_0.Priority = ThreadPriority.Highest;
			ProcessModuleRegistry.thread_0.Start();
		}
	}
	public static ProcessModuleInfo[] GetSnapshot()
	{
		List<ProcessModuleInfo> obj = ProcessModuleRegistry.list_0;
		ProcessModuleInfo[] array;
		lock (obj)
		{
			array = new ProcessModuleInfo[ProcessModuleRegistry.list_0.Count];
			ProcessModuleRegistry.list_0.CopyTo(array);
		}
		return array;
	}
	private static void smethod_2()
	{
		while (RuntimeGuard.bool_0)
		{
			try
			{
				ProcessModuleRegistry.smethod_3();
			}
			catch
			{
			}
			Thread.Sleep(int.Parse(DeProtectType.ArgValue_406));
		}
	}
	private static void smethod_3()
	{
		ProcessNativeMethods.ProcessEntry @struct = default(ProcessNativeMethods.ProcessEntry);
		IntPtr intPtr = ProcessNativeMethods.CreateToolhelp32Snapshot(ProcessNativeMethods.SnapshotProcess, uint.Parse(DeProtectType.ArgValue_407));
		if (!(intPtr == ProcessNativeMethods.InvalidHandleValue))
		{
			@struct.Size = ProcessModuleRegistry.uint_0;
			if (ProcessNativeMethods.Process32First(intPtr, ref @struct))
			{
				do
				{
					if (!ProcessModuleRegistry.hashSet_0.Contains(@struct.ProcessId))
					{
						ProcessModuleRegistry.hashSet_0.Add(@struct.ProcessId);
						ProcessModuleRegistry.RegisterProcess(@struct);
					}
				}
				while (ProcessNativeMethods.Process32Next(intPtr, ref @struct) && RuntimeGuard.bool_0);
				ProcessNativeMethods.CloseHandle(intPtr);
			}
		}
	}
	public static void AddModule(ProcessModuleInfo gclass29_0)
	{
		if (gclass29_0.String_0.EndsWith(DeProtectType.ArgValue_408) || gclass29_0.String_0.EndsWith(DeProtectType.ArgValue_409))
		{
			gclass29_0.String_0 = gclass29_0.String_0.Substring(0, gclass29_0.String_0.Length - 4);
		}
		List<ProcessModuleInfo> obj = ProcessModuleRegistry.list_0;
		lock (obj)
		{
			ProcessModuleRegistry.list_0.Add(gclass29_0);
		}
		try
		{
			Action<ProcessModuleInfo> action = ProcessModuleRegistry.action_0;
			if (action != null)
			{
				action(gclass29_0);
			}
		}
		catch (Exception ex)
		{
			string argValue_ = DeProtectType.ArgValue_410;
			string argValue_2 = DeProtectType.ArgValue_411;
			Exception ex2 = ex;
			FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}
	public static bool IsSignedFile(string string_0)
	{
		try
		{
			X509Certificate certificate = X509Certificate.CreateFromSignedFile(string_0);
			new X509Certificate2(certificate);
			return true;
		}
		catch
		{
		}
		return false;
	}
	public static void Stop(ProcessModuleInfo gclass29_0)
	{
		ProcessModuleRegistry.Class15 @class = new ProcessModuleRegistry.Class15();
		@class.gclass29_0 = gclass29_0;
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}
	private static string smethod_7(ProcessNativeMethods.ProcessEntry struct1_0)
	{
		string text = "";
		try
		{
			IntPtr intPtr = ProcessNativeMethods.OpenProcess(ProcessNativeMethods.SnapshotProcess7, 0, struct1_0.ProcessId);
			if (intPtr != IntPtr.Zero && intPtr != ProcessNativeMethods.InvalidHandleValue)
			{
				int num = int.Parse(DeProtectType.ArgValue_412);
				try
				{
					try
					{
						StringBuilder stringBuilder = new StringBuilder(num);
						ProcessNativeMethods.GetModuleFileNameEx(intPtr, IntPtr.Zero, stringBuilder, num);
						if (stringBuilder.Length == int.Parse(DeProtectType.ArgValue_413))
						{
							ProcessNativeMethods.GetProcessImageFileName(intPtr, stringBuilder, num);
						}
						text = stringBuilder.ToString();
						if (string.IsNullOrEmpty(text) || !File.Exists(text))
						{
							throw new Exception(DeProtectType.ArgValue_414);
						}
					}
					catch
					{
						try
						{
							StringBuilder stringBuilder = new StringBuilder(num);
							ProcessNativeMethods.GetProcessImageFileName(intPtr, stringBuilder, num);
							text = stringBuilder.ToString();
							if (string.IsNullOrEmpty(text) || !File.Exists(text))
							{
								throw new Exception(DeProtectType.ArgValue_415);
							}
						}
						catch
						{
						}
					}
				}
				catch (Exception)
				{
				}
				ProcessNativeMethods.CloseHandle(intPtr);
			}
		}
		catch
		{
		}
		return text;
	}
	private static void RegisterProcess(ProcessNativeMethods.ProcessEntry struct1_0)
	{
		if ((ulong)struct1_0.ProcessId >= (ulong)((long)int.Parse(DeProtectType.ArgValue_416)))
		{
			try
			{
				ProcessModuleInfo gclass = null;
				try
				{
					Process processById = Process.GetProcessById((int)struct1_0.ProcessId);
					gclass = new ProcessModuleInfo
					{
						uint_0 = struct1_0.ProcessId,
						String_0 = (processById.ProcessName.EndsWith(DeProtectType.ArgValue_417) ? processById.ProcessName.Substring(0, processById.ProcessName.Length - 4) : processById.ProcessName),
						String_1 = struct1_0.ExecutableFileName
					};
					StringBuilder stringBuilder = new StringBuilder(512);
					ProcessNativeMethods.GetClassName(processById.MainWindowHandle, stringBuilder, 512);
					try
					{
						if (!File.Exists(gclass.String_1))
						{
							string fileName = processById.MainModule.FileName;
							gclass.String_1 = fileName;
						}
					}
					catch
					{
						try
						{
							gclass.String_1 = processById.StartInfo.FileName;
						}
						catch
						{
						}
					}
					try
					{
						gclass.String_4 = stringBuilder.ToString();
						gclass.String_5 = processById.MainWindowTitle;
					}
					catch
					{
					}
				}
				catch (Exception)
				{
					string string_ = ProcessModuleRegistry.smethod_7(struct1_0);
					gclass = new ProcessModuleInfo
					{
						uint_0 = struct1_0.ProcessId,
						String_0 = struct1_0.ExecutableFileName,
						String_1 = string_
					};
				}
				if (gclass.String_0.EndsWith(DeProtectType.ArgValue_418))
				{
					gclass.String_0 = gclass.String_0.Substring(0, gclass.String_0.Length - 4);
				}
				if (string.IsNullOrEmpty(gclass.String_1) || !File.Exists(gclass.String_1))
				{
					gclass.String_1 = gclass.String_0;
					gclass.String_2 = "";
					gclass.bool_0 = false;
					gclass.String_3 = HashUtility.ComputeMd5(gclass.String_0);
					gclass.long_0 = 0L;
					ProcessModuleRegistry.AddModule(gclass);
				}
				else
				{
					string text = gclass.String_1.ToLower();
					if (!text.Contains(DeProtectType.ArgValue_419) && !text.Contains(DeProtectType.ArgValue_420))
					{
						ProcessModuleRegistry.smethod_9(gclass);
					}
					Dictionary<string, ProcessModuleInfo> obj = ProcessModuleRegistry.dictionary_0;
					lock (obj)
					{
						if (!ProcessModuleRegistry.dictionary_0.ContainsKey(gclass.String_1))
						{
							ProcessModuleRegistry.dictionary_0[gclass.String_1] = gclass;
							ProcessModuleRegistry.Stop(gclass);
							return;
						}
						long num = 0L;
						try
						{
							num = new FileInfo(gclass.String_1).Length;
						}
						catch
						{
						}
						if (num != ProcessModuleRegistry.dictionary_0[gclass.String_1].long_0)
						{
							ProcessModuleRegistry.dictionary_0[gclass.String_1] = gclass;
							ProcessModuleRegistry.Stop(gclass);
							return;
						}
						gclass.long_0 = num;
						gclass.String_3 = ProcessModuleRegistry.dictionary_0[gclass.String_1].String_3;
						gclass.bool_0 = ProcessModuleRegistry.dictionary_0[gclass.String_1].bool_0;
					}
					ProcessModuleRegistry.AddModule(gclass);
				}
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_421;
				string argValue_2 = DeProtectType.ArgValue_422;
				Exception ex2 = ex;
				FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
	}
	private static void smethod_9(ProcessModuleInfo gclass29_0)
	{
		ProcessModuleRegistry.Class17 @class = new ProcessModuleRegistry.Class17();
		@class.gclass29_0 = gclass29_0;
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}
	internal static Thread thread_0;
	private static bool bool_0 = false;
	private static readonly HashSet<uint> hashSet_0 = new HashSet<uint>();
	private static readonly Dictionary<string, ProcessModuleInfo> dictionary_0 = new Dictionary<string, ProcessModuleInfo>();
	private static readonly List<ProcessModuleInfo> list_0 = new List<ProcessModuleInfo>();
	private static readonly uint uint_0 = (uint)Marshal.SizeOf(typeof(ProcessNativeMethods.ProcessEntry));
	private static bool bool_1 = false;
	public static Action<ProcessModuleInfo> action_0;
	[CompilerGenerated]
	private sealed class Class15
	{
		internal void method_0(object object_0)
		{
			try
			{
				if (File.Exists(this.gclass29_0.String_1))
				{
					this.gclass29_0.String_6 = FileVersionInfo.GetVersionInfo(this.gclass29_0.String_1).OriginalFilename;
					DirectoryInfo directoryInfo = new DirectoryInfo(this.gclass29_0.String_1);
					this.gclass29_0.String_2 = new FileInfo(directoryInfo.FullName).Directory.FullName;
					if (Directory.Exists(this.gclass29_0.String_2 + DeProtectType.ArgValue_423 + this.gclass29_0.String_0 + DeProtectType.ArgValue_424) && this.gclass29_0.String_1.Contains(DeProtectType.ArgValue_425))
					{
						List<FileInfo> list = new List<FileInfo>();
						Action action_;
						if ((action_ = this.action_0) == null)
						{
							action_ = (this.action_0 = new Action(this.method_1));
						}
						RetryScheduler.RunForeverDelayed(action_, new Action<Exception>(ProcessModuleRegistry.Class16.class16_0.method_0), 15f);
						if (Directory.Exists(this.gclass29_0.String_2 + DeProtectType.ArgValue_426 + this.gclass29_0.String_0 + DeProtectType.ArgValue_427))
						{
							FileInfo[] files = new DirectoryInfo(this.gclass29_0.String_2 + DeProtectType.ArgValue_428 + this.gclass29_0.String_0 + DeProtectType.ArgValue_429).GetFiles(DeProtectType.ArgValue_430);
							list.AddRange(files);
						}
						if (Directory.Exists(this.gclass29_0.String_2 + DeProtectType.ArgValue_431 + this.gclass29_0.String_0 + DeProtectType.ArgValue_432))
						{
							FileInfo[] files2 = new DirectoryInfo(this.gclass29_0.String_2 + DeProtectType.ArgValue_433 + this.gclass29_0.String_0 + DeProtectType.ArgValue_434).GetFiles(DeProtectType.ArgValue_435);
							for (int i = 0; i < files2.Length; i++)
							{
								if (!ProcessModuleRegistry.IsSignedFile(files2[i].FullName))
								{
									FileLogger.Log(DeProtectType.ArgValue_436, DeProtectType.ArgValue_437);
									RuntimeGuard.ExitApplication();
									return;
								}
							}
							list.AddRange(files2);
						}
						if (Directory.Exists(this.gclass29_0.String_2 + DeProtectType.ArgValue_438 + this.gclass29_0.String_0 + DeProtectType.ArgValue_439))
						{
							FileInfo[] files3 = new DirectoryInfo(this.gclass29_0.String_2 + DeProtectType.ArgValue_440 + this.gclass29_0.String_0 + DeProtectType.ArgValue_441).GetFiles(DeProtectType.ArgValue_442);
							for (int j = 0; j < files3.Length; j++)
							{
								if (!ProcessModuleRegistry.IsSignedFile(files3[j].FullName))
								{
									FileLogger.Log(DeProtectType.ArgValue_443, DeProtectType.ArgValue_444);
									RuntimeGuard.ExitApplication();
									return;
								}
							}
							list.AddRange(files3);
						}
						for (int k = 0; k < list.Count; k++)
						{
							FileInfo fileInfo = list[k];
							Dictionary<string, ProcessModuleInfo> dictionary_ = ProcessModuleRegistry.dictionary_0;
							lock (dictionary_)
							{
								if (!ProcessModuleRegistry.dictionary_0.ContainsKey(fileInfo.FullName))
								{
									ProcessModuleInfo gclass = new ProcessModuleInfo();
									gclass.String_0 = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length - 1);
									gclass.String_1 = fileInfo.FullName;
									gclass.String_2 = fileInfo.Directory.FullName;
									gclass.uint_0 = 0U;
									gclass.String_4 = DeProtectType.ArgValue_445;
									ProcessModuleRegistry.dictionary_0.Add(fileInfo.FullName, gclass);
									ProcessModuleRegistry.Stop(gclass);
								}
							}
						}
					}
					try
					{
						this.gclass29_0.long_0 = new FileInfo(this.gclass29_0.String_1).Length;
					}
					catch
					{
					}
					this.gclass29_0.bool_0 = ProcessModuleRegistry.IsSignedFile(this.gclass29_0.String_1);
					using (MD5 md = MD5.Create())
					{
						using (FileStream fileStream = File.OpenRead(this.gclass29_0.String_1))
						{
							this.gclass29_0.String_3 = BitConverter.ToString(md.ComputeHash(fileStream)).Replace(DeProtectType.ArgValue_446, "").ToLowerInvariant();
						}
						goto IL_491;
					}
				}
				this.gclass29_0.bool_0 = false;
				this.gclass29_0.String_3 = HashUtility.ComputeMd5(this.gclass29_0.String_0);
				this.gclass29_0.long_0 = 0L;
				IL_491:;
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_447;
				string argValue_2 = DeProtectType.ArgValue_448;
				Exception ex2 = ex;
				FileLogger.Log(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			ProcessModuleRegistry.AddModule(this.gclass29_0);
		}
		internal void method_1()
		{
			if (Directory.Exists(this.gclass29_0.String_2))
			{
				FileInfo[] files = new DirectoryInfo(this.gclass29_0.String_2).GetFiles();
				int i = 0;
				while (i < files.Length)
				{
					if (files[i].FullName.EndsWith(DeProtectType.ArgValue_449) && !ProcessModuleRegistry.bool_1)
					{
						ProcessModuleRegistry.bool_1 = true;
						try
						{
							files[i].Delete();
							goto IL_14C;
						}
						catch
						{
							goto IL_14C;
						}
						goto IL_6F;
					}
					goto IL_6F;
					IL_14C:
					i++;
					continue;
					IL_6F:
					if (!ProcessModuleRegistry.dictionary_0.ContainsKey(files[i].FullName) && !files[i].FullName.Contains(DeProtectType.ArgValue_450))
					{
						ProcessModuleInfo gclass = new ProcessModuleInfo();
						gclass.String_0 = (files[i].Name.EndsWith(files[i].Extension) ? files[i].Name.Substring(0, files[i].Name.Length - files[i].Extension.Length - 1) : files[i].Name);
						gclass.String_1 = files[i].FullName;
						gclass.String_2 = files[i].Directory.FullName;
						gclass.uint_0 = 0U;
						gclass.String_4 = DeProtectType.ArgValue_451;
						ProcessModuleRegistry.dictionary_0.Add(files[i].FullName, gclass);
						ProcessModuleRegistry.Stop(gclass);
						goto IL_14C;
					}
					goto IL_14C;
				}
			}
		}
		public ProcessModuleInfo gclass29_0;
		public Action action_0;
	}
	[CompilerGenerated]
	[Serializable]
	private sealed class Class16
	{
		internal void method_0(Exception exception_0)
		{
		}
		public static readonly ProcessModuleRegistry.Class16 class16_0 = new ProcessModuleRegistry.Class16();
		public static Action<Exception> action_0;
	}
	[CompilerGenerated]
	private sealed class Class17
	{
		internal void method_0(object object_0)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(this.gclass29_0.String_1);
				if (fileInfo.Length < 10485760L)
				{
					string @string = Encoding.UTF8.GetString(File.ReadAllBytes(this.gclass29_0.String_1));
					if (@string.Contains(DeProtectType.ArgValue_452))
					{
						Process processById = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById != null)
						{
							processById.Kill();
						}
						FileLogger.Log(DeProtectType.ArgValue_453, DeProtectType.ArgValue_454);
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_455))
					{
						Process processById2 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById2 != null)
						{
							processById2.Kill();
						}
						FileLogger.Log(DeProtectType.ArgValue_456, DeProtectType.ArgValue_457);
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_458))
					{
						Process processById3 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById3 != null)
						{
							processById3.Kill();
						}
						FileLogger.Log(DeProtectType.ArgValue_459, DeProtectType.ArgValue_460);
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_461))
					{
						FileLogger.Log(DeProtectType.ArgValue_462, DeProtectType.ArgValue_463);
						Process processById4 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById4 != null)
						{
							processById4.Kill();
						}
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_464))
					{
						FileLogger.Log(DeProtectType.ArgValue_465, DeProtectType.ArgValue_466);
						Process processById5 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById5 != null)
						{
							processById5.Kill();
						}
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_467))
					{
						Process processById6 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById6 != null)
						{
							processById6.Kill();
						}
						FileLogger.Log(DeProtectType.ArgValue_468, DeProtectType.ArgValue_469);
						RuntimeGuard.ExitApplication();
					}
					else if (@string.Contains(DeProtectType.ArgValue_470))
					{
						Process processById7 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById7 != null)
						{
							processById7.Kill();
						}
						FileLogger.Log(DeProtectType.ArgValue_471, DeProtectType.ArgValue_472);
						RuntimeGuard.ExitApplication();
					}
				}
			}
			catch
			{
				try
				{
					FileLogger.Log(DeProtectType.ArgValue_473, DeProtectType.ArgValue_474);
					RuntimeGuard.ExitApplication();
				}
				catch
				{
				}
			}
		}
		public ProcessModuleInfo gclass29_0;
	}
}
