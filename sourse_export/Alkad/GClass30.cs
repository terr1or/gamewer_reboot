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

// Token: 0x0200003C RID: 60
public class GClass30
{
	// Token: 0x060000FB RID: 251 RVA: 0x00006250 File Offset: 0x00004450
	public static void smethod_0()
	{
		if (!GClass30.bool_0)
		{
			GClass30.bool_0 = true;
			GClass30.thread_0 = new Thread(new ThreadStart(GClass30.smethod_2));
			GClass30.thread_0.IsBackground = true;
			GClass30.thread_0.Priority = ThreadPriority.Highest;
			GClass30.thread_0.Start();
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000062A0 File Offset: 0x000044A0
	public static GClass29[] smethod_1()
	{
		List<GClass29> obj = GClass30.list_0;
		GClass29[] array;
		lock (obj)
		{
			array = new GClass29[GClass30.list_0.Count];
			GClass30.list_0.CopyTo(array);
		}
		return array;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x000062F8 File Offset: 0x000044F8
	private static void smethod_2()
	{
		while (GClass4.bool_0)
		{
			try
			{
				GClass30.smethod_3();
			}
			catch
			{
			}
			Thread.Sleep(int.Parse(DeProtectType.ArgValue_406));
		}
	}

	// Token: 0x060000FE RID: 254 RVA: 0x0000633C File Offset: 0x0000453C
	private static void smethod_3()
	{
		Class18.Struct1 @struct = default(Class18.Struct1);
		IntPtr intPtr = Class18.CreateToolhelp32Snapshot(Class18.uint_1, uint.Parse(DeProtectType.ArgValue_407));
		if (!(intPtr == Class18.intptr_0))
		{
			@struct.uint_0 = GClass30.uint_0;
			if (Class18.Process32First(intPtr, ref @struct))
			{
				do
				{
					if (!GClass30.hashSet_0.Contains(@struct.uint_2))
					{
						GClass30.hashSet_0.Add(@struct.uint_2);
						GClass30.smethod_8(@struct);
					}
				}
				while (Class18.Process32Next(intPtr, ref @struct) && GClass4.bool_0);
				Class18.CloseHandle(intPtr);
			}
		}
	}

	// Token: 0x060000FF RID: 255 RVA: 0x000063DC File Offset: 0x000045DC
	public static void smethod_4(GClass29 gclass29_0)
	{
		if (gclass29_0.String_0.EndsWith(DeProtectType.ArgValue_408) || gclass29_0.String_0.EndsWith(DeProtectType.ArgValue_409))
		{
			gclass29_0.String_0 = gclass29_0.String_0.Substring(0, gclass29_0.String_0.Length - 4);
		}
		List<GClass29> obj = GClass30.list_0;
		lock (obj)
		{
			GClass30.list_0.Add(gclass29_0);
		}
		try
		{
			Action<GClass29> action = GClass30.action_0;
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
			GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000064AC File Offset: 0x000046AC
	public static bool smethod_5(string string_0)
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

	// Token: 0x06000101 RID: 257 RVA: 0x000064E4 File Offset: 0x000046E4
	public static void smethod_6(GClass29 gclass29_0)
	{
		GClass30.Class15 @class = new GClass30.Class15();
		@class.gclass29_0 = gclass29_0;
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}

	// Token: 0x06000102 RID: 258 RVA: 0x00006510 File Offset: 0x00004710
	private static string smethod_7(Class18.Struct1 struct1_0)
	{
		string text = "";
		try
		{
			IntPtr intPtr = Class18.OpenProcess(Class18.uint_17, 0, struct1_0.uint_2);
			if (intPtr != IntPtr.Zero && intPtr != Class18.intptr_0)
			{
				int num = int.Parse(DeProtectType.ArgValue_412);
				try
				{
					try
					{
						StringBuilder stringBuilder = new StringBuilder(num);
						Class18.GetModuleFileNameEx(intPtr, IntPtr.Zero, stringBuilder, num);
						if (stringBuilder.Length == int.Parse(DeProtectType.ArgValue_413))
						{
							Class18.GetProcessImageFileName(intPtr, stringBuilder, num);
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
							Class18.GetProcessImageFileName(intPtr, stringBuilder, num);
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
				Class18.CloseHandle(intPtr);
			}
		}
		catch
		{
		}
		return text;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00006654 File Offset: 0x00004854
	private static void smethod_8(Class18.Struct1 struct1_0)
	{
		if ((ulong)struct1_0.uint_2 >= (ulong)((long)int.Parse(DeProtectType.ArgValue_416)))
		{
			try
			{
				GClass29 gclass = null;
				try
				{
					Process processById = Process.GetProcessById((int)struct1_0.uint_2);
					gclass = new GClass29
					{
						uint_0 = struct1_0.uint_2,
						String_0 = (processById.ProcessName.EndsWith(DeProtectType.ArgValue_417) ? processById.ProcessName.Substring(0, processById.ProcessName.Length - 4) : processById.ProcessName),
						String_1 = struct1_0.string_0
					};
					StringBuilder stringBuilder = new StringBuilder(512);
					Class18.GetClassName(processById.MainWindowHandle, stringBuilder, 512);
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
					string string_ = GClass30.smethod_7(struct1_0);
					gclass = new GClass29
					{
						uint_0 = struct1_0.uint_2,
						String_0 = struct1_0.string_0,
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
					gclass.String_3 = GClass21.smethod_0(gclass.String_0);
					gclass.long_0 = 0L;
					GClass30.smethod_4(gclass);
				}
				else
				{
					string text = gclass.String_1.ToLower();
					if (!text.Contains(DeProtectType.ArgValue_419) && !text.Contains(DeProtectType.ArgValue_420))
					{
						GClass30.smethod_9(gclass);
					}
					Dictionary<string, GClass29> obj = GClass30.dictionary_0;
					lock (obj)
					{
						if (!GClass30.dictionary_0.ContainsKey(gclass.String_1))
						{
							GClass30.dictionary_0[gclass.String_1] = gclass;
							GClass30.smethod_6(gclass);
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
						if (num != GClass30.dictionary_0[gclass.String_1].long_0)
						{
							GClass30.dictionary_0[gclass.String_1] = gclass;
							GClass30.smethod_6(gclass);
							return;
						}
						gclass.long_0 = num;
						gclass.String_3 = GClass30.dictionary_0[gclass.String_1].String_3;
						gclass.bool_0 = GClass30.dictionary_0[gclass.String_1].bool_0;
					}
					GClass30.smethod_4(gclass);
				}
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_421;
				string argValue_2 = DeProtectType.ArgValue_422;
				Exception ex2 = ex;
				GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
		}
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00006A20 File Offset: 0x00004C20
	private static void smethod_9(GClass29 gclass29_0)
	{
		GClass30.Class17 @class = new GClass30.Class17();
		@class.gclass29_0 = gclass29_0;
		ThreadPool.QueueUserWorkItem(new WaitCallback(@class.method_0));
	}

	// Token: 0x040002C3 RID: 707
	internal static Thread thread_0;

	// Token: 0x040002C4 RID: 708
	private static bool bool_0 = false;

	// Token: 0x040002C5 RID: 709
	private static readonly HashSet<uint> hashSet_0 = new HashSet<uint>();

	// Token: 0x040002C6 RID: 710
	private static readonly Dictionary<string, GClass29> dictionary_0 = new Dictionary<string, GClass29>();

	// Token: 0x040002C7 RID: 711
	private static readonly List<GClass29> list_0 = new List<GClass29>();

	// Token: 0x040002C8 RID: 712
	private static readonly uint uint_0 = (uint)Marshal.SizeOf(typeof(Class18.Struct1));

	// Token: 0x040002C9 RID: 713
	private static bool bool_1 = false;

	// Token: 0x040002CA RID: 714
	public static Action<GClass29> action_0;

	// Token: 0x0200003D RID: 61
	[CompilerGenerated]
	private sealed class Class15
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00006A4C File Offset: 0x00004C4C
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
						GClass25.smethod_1(action_, new Action<Exception>(GClass30.Class16.class16_0.method_0), 15f);
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
								if (!GClass30.smethod_5(files2[i].FullName))
								{
									GClass7.smethod_0(DeProtectType.ArgValue_436, DeProtectType.ArgValue_437);
									GClass4.smethod_11();
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
								if (!GClass30.smethod_5(files3[j].FullName))
								{
									GClass7.smethod_0(DeProtectType.ArgValue_443, DeProtectType.ArgValue_444);
									GClass4.smethod_11();
									return;
								}
							}
							list.AddRange(files3);
						}
						for (int k = 0; k < list.Count; k++)
						{
							FileInfo fileInfo = list[k];
							Dictionary<string, GClass29> dictionary_ = GClass30.dictionary_0;
							lock (dictionary_)
							{
								if (!GClass30.dictionary_0.ContainsKey(fileInfo.FullName))
								{
									GClass29 gclass = new GClass29();
									gclass.String_0 = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length - 1);
									gclass.String_1 = fileInfo.FullName;
									gclass.String_2 = fileInfo.Directory.FullName;
									gclass.uint_0 = 0U;
									gclass.String_4 = DeProtectType.ArgValue_445;
									GClass30.dictionary_0.Add(fileInfo.FullName, gclass);
									GClass30.smethod_6(gclass);
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
					this.gclass29_0.bool_0 = GClass30.smethod_5(this.gclass29_0.String_1);
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
				this.gclass29_0.String_3 = GClass21.smethod_0(this.gclass29_0.String_0);
				this.gclass29_0.long_0 = 0L;
				IL_491:;
			}
			catch (Exception ex)
			{
				string argValue_ = DeProtectType.ArgValue_447;
				string argValue_2 = DeProtectType.ArgValue_448;
				Exception ex2 = ex;
				GClass7.smethod_0(argValue_, argValue_2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			GClass30.smethod_4(this.gclass29_0);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00006F9C File Offset: 0x0000519C
		internal void method_1()
		{
			if (Directory.Exists(this.gclass29_0.String_2))
			{
				FileInfo[] files = new DirectoryInfo(this.gclass29_0.String_2).GetFiles();
				int i = 0;
				while (i < files.Length)
				{
					if (files[i].FullName.EndsWith(DeProtectType.ArgValue_449) && !GClass30.bool_1)
					{
						GClass30.bool_1 = true;
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
					if (!GClass30.dictionary_0.ContainsKey(files[i].FullName) && !files[i].FullName.Contains(DeProtectType.ArgValue_450))
					{
						GClass29 gclass = new GClass29();
						gclass.String_0 = (files[i].Name.EndsWith(files[i].Extension) ? files[i].Name.Substring(0, files[i].Name.Length - files[i].Extension.Length - 1) : files[i].Name);
						gclass.String_1 = files[i].FullName;
						gclass.String_2 = files[i].Directory.FullName;
						gclass.uint_0 = 0U;
						gclass.String_4 = DeProtectType.ArgValue_451;
						GClass30.dictionary_0.Add(files[i].FullName, gclass);
						GClass30.smethod_6(gclass);
						goto IL_14C;
					}
					goto IL_14C;
				}
			}
		}

		// Token: 0x040002CB RID: 715
		public GClass29 gclass29_0;

		// Token: 0x040002CC RID: 716
		public Action action_0;
	}

	// Token: 0x0200003E RID: 62
	[CompilerGenerated]
	[Serializable]
	private sealed class Class16
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00002245 File Offset: 0x00000445
		internal void method_0(Exception exception_0)
		{
		}

		// Token: 0x040002CD RID: 717
		public static readonly GClass30.Class16 class16_0 = new GClass30.Class16();

		// Token: 0x040002CE RID: 718
		public static Action<Exception> action_0;
	}

	// Token: 0x0200003F RID: 63
	[CompilerGenerated]
	private sealed class Class17
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00007110 File Offset: 0x00005310
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
						GClass7.smethod_0(DeProtectType.ArgValue_453, DeProtectType.ArgValue_454);
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_455))
					{
						Process processById2 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById2 != null)
						{
							processById2.Kill();
						}
						GClass7.smethod_0(DeProtectType.ArgValue_456, DeProtectType.ArgValue_457);
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_458))
					{
						Process processById3 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById3 != null)
						{
							processById3.Kill();
						}
						GClass7.smethod_0(DeProtectType.ArgValue_459, DeProtectType.ArgValue_460);
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_461))
					{
						GClass7.smethod_0(DeProtectType.ArgValue_462, DeProtectType.ArgValue_463);
						Process processById4 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById4 != null)
						{
							processById4.Kill();
						}
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_464))
					{
						GClass7.smethod_0(DeProtectType.ArgValue_465, DeProtectType.ArgValue_466);
						Process processById5 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById5 != null)
						{
							processById5.Kill();
						}
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_467))
					{
						Process processById6 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById6 != null)
						{
							processById6.Kill();
						}
						GClass7.smethod_0(DeProtectType.ArgValue_468, DeProtectType.ArgValue_469);
						GClass4.smethod_11();
					}
					else if (@string.Contains(DeProtectType.ArgValue_470))
					{
						Process processById7 = Process.GetProcessById((int)this.gclass29_0.uint_0);
						if (processById7 != null)
						{
							processById7.Kill();
						}
						GClass7.smethod_0(DeProtectType.ArgValue_471, DeProtectType.ArgValue_472);
						GClass4.smethod_11();
					}
				}
			}
			catch
			{
				try
				{
					GClass7.smethod_0(DeProtectType.ArgValue_473, DeProtectType.ArgValue_474);
					GClass4.smethod_11();
				}
				catch
				{
				}
			}
		}

		// Token: 0x040002CF RID: 719
		public GClass29 gclass29_0;
	}
}
