using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x02000027 RID: 39
public class GClass12 : GClass11
{
	// Token: 0x06000095 RID: 149 RVA: 0x00002354 File Offset: 0x00000554
	public GClass12()
	{
		this.string_0 = DeProtectType.ArgValue_313;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00005324 File Offset: 0x00003524
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_314,
				this.string_0
			},
			{
				DeProtectType.ArgValue_315,
				this.string_1
			},
			{
				DeProtectType.ArgValue_316,
				this.uint_0
			}
		});
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00005378 File Offset: 0x00003578
	internal static GClass12 smethod_0(string string_2)
	{
		return GClass12.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_2));
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00005394 File Offset: 0x00003594
	internal static GClass12 smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new GClass12
		{
			string_1 = dictionary_0[DeProtectType.ArgValue_317].ToString(),
			uint_0 = (uint)double.Parse(dictionary_0[DeProtectType.ArgValue_318].ToString())
		};
	}

	// Token: 0x0400027E RID: 638
	[JsonProperty("reason")]
	internal string string_1;

	// Token: 0x0400027F RID: 639
	[JsonProperty("finis_at")]
	internal uint uint_0;
}
