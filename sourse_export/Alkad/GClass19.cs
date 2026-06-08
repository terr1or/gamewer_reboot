using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x02000030 RID: 48
public class GClass19 : GClass11
{
	// Token: 0x060000BA RID: 186 RVA: 0x00002461 File Offset: 0x00000661
	public GClass19()
	{
		this.string_0 = DeProtectType.ArgValue_363;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00005784 File Offset: 0x00003984
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_364,
				this.string_0
			},
			{
				DeProtectType.ArgValue_365,
				this.string_1
			}
		});
	}

	// Token: 0x060000BC RID: 188 RVA: 0x000057C0 File Offset: 0x000039C0
	internal static GClass19 smethod_0(string string_2)
	{
		return GClass19.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_2));
	}

	// Token: 0x060000BD RID: 189 RVA: 0x000057DC File Offset: 0x000039DC
	internal static GClass19 smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new GClass19
		{
			string_1 = dictionary_0[DeProtectType.ArgValue_366].ToString()
		};
	}

	// Token: 0x040002A7 RID: 679
	[JsonProperty("hash")]
	internal string string_1;
}
