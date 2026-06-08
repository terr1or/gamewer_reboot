using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using GameWer;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class FileLogger
{
	// (get) Token: 0x0600006A RID: 106 RVA: 0x000022BC File Offset: 0x000004BC
	private static FileLogger Instance { get; } = new FileLogger();
	private FileLogger()
	{
	}
	internal static void Log(string string_0, string string_1)
	{
		Console.WriteLine(DeProtectType.ArgValue_230 + string_0 + DeProtectType.ArgValue_231 + string_1);
		FileLogger obj = FileLogger.Instance;
		lock (obj)
		{
			try
			{
				Console.WriteLine(string.Format("\n[{0}] [{1}]: ", DateTime.Now, string_0) + string_1);
				File.AppendAllText(DeProtectType.ArgValue_232, string.Format("\n[{0}] [{1}]: ", DateTime.Now, string_0) + string_1);
			}
			catch (Exception)
			{
			}
		}
	}
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly FileLogger instance;
}
