using System;
using Newtonsoft.Json;

// Token: 0x02000028 RID: 40
public class GClass11
{
	// Token: 0x06000099 RID: 153 RVA: 0x000053DC File Offset: 0x000035DC
	internal virtual string vmethod_0()
	{
		return JsonConvert.SerializeObject(this);
	}

	// Token: 0x04000280 RID: 640
	[JsonProperty("method")]
	internal string string_0;
}
