using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;

// Token: 0x0200002C RID: 44
public class GClass16 : GClass11
{
	// Token: 0x060000A2 RID: 162 RVA: 0x000023A0 File Offset: 0x000005A0
	public GClass16()
	{
		this.string_0 = DeProtectType.ArgValue_338;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00005580 File Offset: 0x00003780
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_339,
				this.string_0
			},
			{
				DeProtectType.ArgValue_340,
				this.string_1
			},
			{
				DeProtectType.ArgValue_341,
				this.string_2
			},
			{
				DeProtectType.ArgValue_342,
				this.string_3
			},
			{
				DeProtectType.ArgValue_343,
				this.string_4
			},
			{
				DeProtectType.ArgValue_344,
				this.string_5
			},
			{
				DeProtectType.ArgValue_345,
				this.string_6
			},
			{
				DeProtectType.ArgValue_346,
				this.string_7
			},
			{
				DeProtectType.ArgValue_347,
				this.string_8
			},
			{
				DeProtectType.ArgValue_348,
				this.string_9
			},
			{
				DeProtectType.ArgValue_349,
				this.bool_0
			},
			{
				DeProtectType.ArgValue_350,
				this.int_0
			},
			{
				DeProtectType.ArgValue_351,
				this.string_10
			},
			{
				DeProtectType.ArgValue_352,
				this.string_11
			},
			{
				DeProtectType.ArgValue_353,
				this.string_12
			},
			{
				DeProtectType.ArgValue_354,
				this.string_13
			},
			{
				DeProtectType.ArgValue_355,
				this.string_14
			},
			{
				DeProtectType.ArgValue_356,
				this.int_1
			},
			{
				DeProtectType.ArgValue_357,
				this.string_15
			}
		});
	}

	// Token: 0x0400028C RID: 652
	[JsonProperty("hwid_list")]
	internal string string_1;

	// Token: 0x0400028D RID: 653
	[JsonProperty("modle")]
	internal string string_2;

	// Token: 0x0400028E RID: 654
	[JsonProperty("manufacturer")]
	internal string string_3;

	// Token: 0x0400028F RID: 655
	[JsonProperty("productname")]
	internal string string_4;

	// Token: 0x04000290 RID: 656
	[JsonProperty("organization")]
	internal string string_5;

	// Token: 0x04000291 RID: 657
	[JsonProperty("owner")]
	internal string string_6;

	// Token: 0x04000292 RID: 658
	[JsonProperty("systemroot")]
	internal string string_7;

	// Token: 0x04000293 RID: 659
	[JsonProperty("machinename")]
	internal string string_8;

	// Token: 0x04000294 RID: 660
	[JsonProperty("username")]
	internal string string_9;

	// Token: 0x04000295 RID: 661
	[JsonProperty("isbit64")]
	internal bool bool_0;

	// Token: 0x04000296 RID: 662
	[JsonProperty("memorysize")]
	internal int int_0;

	// Token: 0x04000297 RID: 663
	[JsonProperty("processorname")]
	internal string string_10;

	// Token: 0x04000298 RID: 664
	[JsonProperty("processorid")]
	internal string string_11;

	// Token: 0x04000299 RID: 665
	[JsonProperty("videoname")]
	internal string string_12;

	// Token: 0x0400029A RID: 666
	[JsonProperty("videoid")]
	internal string string_13;

	// Token: 0x0400029B RID: 667
	[JsonProperty("driversname")]
	internal string string_14;

	// Token: 0x0400029C RID: 668
	[JsonProperty("driverssize")]
	internal int int_1;

	// Token: 0x0400029D RID: 669
	[JsonProperty("privateKeyHash")]
	internal string string_15;
}
