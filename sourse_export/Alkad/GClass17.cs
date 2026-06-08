using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x0200002D RID: 45
public class GClass17 : GClass11
{
	// Token: 0x060000A4 RID: 164 RVA: 0x000023B3 File Offset: 0x000005B3
	public GClass17()
	{
		this.string_0 = DeProtectType.ArgValue_358;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x000056EC File Offset: 0x000038EC
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_359,
				this.string_0
			},
			{
				DeProtectType.ArgValue_360,
				this.gstruct0_0
			}
		});
	}

	// Token: 0x0400029E RID: 670
	[JsonProperty("processes")]
	internal GStruct0[] gstruct0_0;
}
