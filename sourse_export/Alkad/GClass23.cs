using System;

// Token: 0x02000035 RID: 53
public class GClass23
{
	// Token: 0x060000DA RID: 218 RVA: 0x00005EF8 File Offset: 0x000040F8
	internal static DateTime smethod_0(double double_0)
	{
		DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		result = result.AddSeconds(double_0).ToLocalTime();
		return result;
	}
}
