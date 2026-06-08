using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class InjectionOptions
{
	// (get) Token: 0x06000004 RID: 4 RVA: 0x00002064 File Offset: 0x00000264
	// (set) Token: 0x06000005 RID: 5 RVA: 0x0000206C File Offset: 0x0000026C
	public bool Boolean_0 { get; set; }
	// (get) Token: 0x06000006 RID: 6 RVA: 0x0000272C File Offset: 0x0000092C
	public static InjectionOptions GClass1_0
	{
		get
		{
			return new InjectionOptions();
		}
	}
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_0;
}
