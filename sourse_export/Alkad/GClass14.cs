using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x0200002A RID: 42
public class GClass14 : GClass11
{
	// Token: 0x0600009D RID: 157 RVA: 0x0000237A File Offset: 0x0000057A
	public GClass14()
	{
		this.string_0 = DeProtectType.ArgValue_329;
	}

	// Token: 0x0600009E RID: 158 RVA: 0x000054A8 File Offset: 0x000036A8
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_330,
				this.string_0
			},
			{
				DeProtectType.ArgValue_331,
				this.bool_0
			},
			{
				DeProtectType.ArgValue_332,
				this.string_1
			},
			{
				DeProtectType.ArgValue_333,
				this.string_2
			}
		});
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000550C File Offset: 0x0000370C
	internal static GClass14 smethod_0(string string_3)
	{
		return GClass14.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_3));
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00005528 File Offset: 0x00003728
	internal static GClass14 smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new GClass14
		{
			bool_0 = (bool)dictionary_0[DeProtectType.ArgValue_334],
			string_1 = (string)dictionary_0[DeProtectType.ArgValue_335],
			string_2 = (string)dictionary_0[DeProtectType.ArgValue_336]
		};
	}

	// Token: 0x04000289 RID: 649
	[JsonProperty("result")]
	internal bool bool_0;

	// Token: 0x0400028A RID: 650
	[JsonProperty("privateKey")]
	internal string string_1;

	// Token: 0x0400028B RID: 651
	[JsonProperty("sessionKey")]
	public string string_2;
}
