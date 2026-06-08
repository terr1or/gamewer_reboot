using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
/// <summary>
/// Provides the struct component for the GameWer client.
/// </summary>
public struct DetectionFinding
{
	// (get) Token: 0x060000AA RID: 170 RVA: 0x000023D9 File Offset: 0x000005D9
	// (set) Token: 0x060000AB RID: 171 RVA: 0x000023E1 File Offset: 0x000005E1
	[JsonProperty("hash")]
	public string String_0 { get; set; }
	// (get) Token: 0x060000AC RID: 172 RVA: 0x000023EA File Offset: 0x000005EA
	// (set) Token: 0x060000AD RID: 173 RVA: 0x000023F2 File Offset: 0x000005F2
	[JsonProperty("name")]
	public string String_1 { get; set; }
	// (get) Token: 0x060000AE RID: 174 RVA: 0x000023FB File Offset: 0x000005FB
	// (set) Token: 0x060000AF RID: 175 RVA: 0x00002403 File Offset: 0x00000603
	[JsonProperty("title")]
	public string String_2 { get; set; }
	// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000240C File Offset: 0x0000060C
	// (set) Token: 0x060000B1 RID: 177 RVA: 0x00002414 File Offset: 0x00000614
	[JsonProperty("class")]
	public string String_3 { get; set; }
	// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000241D File Offset: 0x0000061D
	// (set) Token: 0x060000B3 RID: 179 RVA: 0x00002425 File Offset: 0x00000625
	[JsonProperty("origin")]
	public string String_4 { get; set; }
	// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000242E File Offset: 0x0000062E
	// (set) Token: 0x060000B5 RID: 181 RVA: 0x00002436 File Offset: 0x00000636
	[JsonProperty("path")]
	public string String_5 { get; set; }
	// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000243F File Offset: 0x0000063F
	// (set) Token: 0x060000B7 RID: 183 RVA: 0x00002447 File Offset: 0x00000647
	[JsonProperty("size")]
	public int Int32_0 { get; set; }
	// (get) Token: 0x060000B8 RID: 184 RVA: 0x00002450 File Offset: 0x00000650
	// (set) Token: 0x060000B9 RID: 185 RVA: 0x00002458 File Offset: 0x00000658
	[JsonProperty("secure")]
	public bool Boolean_0 { get; set; }
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_0;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_1;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_2;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_3;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_4;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_5;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int int_0;
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_0;
}
