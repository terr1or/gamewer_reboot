using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x02000029 RID: 41
public class GClass13 : GClass11
{
	// Token: 0x0600009B RID: 155 RVA: 0x00002367 File Offset: 0x00000567
	public GClass13()
	{
		this.string_0 = DeProtectType.ArgValue_319;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000053F4 File Offset: 0x000035F4
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_320,
				this.string_0
			},
			{
				DeProtectType.ArgValue_321,
				this.string_1
			},
			{
				DeProtectType.ArgValue_322,
				this.string_2
			},
			{
				DeProtectType.ArgValue_323,
				this.string_3
			},
			{
				DeProtectType.ArgValue_324,
				this.string_4
			},
			{
				DeProtectType.ArgValue_325,
				this.string_5
			},
			{
				DeProtectType.ArgValue_326,
				this.string_6
			},
			{
				DeProtectType.ArgValue_327,
				this.string_7
			},
			{
				DeProtectType.ArgValue_328,
				this.string_8
			}
		});
	}

	// Token: 0x04000281 RID: 641
	[JsonProperty("version")]
	internal string string_1;

	// Token: 0x04000282 RID: 642
	[JsonProperty("steamid")]
	internal string string_2;

	// Token: 0x04000283 RID: 643
	[JsonProperty("hwid")]
	internal string string_3;

	// Token: 0x04000284 RID: 644
	[JsonProperty("pcid")]
	internal string string_4;

	// Token: 0x04000285 RID: 645
	[JsonProperty("dsid")]
	internal string string_5;

	// Token: 0x04000286 RID: 646
	[JsonProperty("lastSessionKey")]
	internal string string_6;

	// Token: 0x04000287 RID: 647
	[JsonProperty("publicKey")]
	internal string string_7;

	// Token: 0x04000288 RID: 648
	[JsonProperty("publicKeyHash")]
	internal string string_8;
}
