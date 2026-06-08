using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x0200002E RID: 46
public class GClass18 : GClass11
{
	// Token: 0x060000A6 RID: 166 RVA: 0x000023C6 File Offset: 0x000005C6
	public GClass18()
	{
		this.string_0 = DeProtectType.ArgValue_361;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00005728 File Offset: 0x00003928
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_362,
				this.string_0
			}
		});
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00005754 File Offset: 0x00003954
	internal static GClass18 smethod_0(string string_1)
	{
		return GClass18.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_1));
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00005770 File Offset: 0x00003970
	internal static GClass18 smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new GClass18();
	}
}
