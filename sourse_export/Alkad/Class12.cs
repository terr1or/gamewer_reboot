using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using GameWer;

// Token: 0x02000025 RID: 37
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Class12
{
	// Token: 0x0600008E RID: 142 RVA: 0x00002075 File Offset: 0x00000275
	internal Class12()
	{
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600008F RID: 143 RVA: 0x000052BC File Offset: 0x000034BC
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (Class12.resourceManager_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager(DeProtectType.ArgValue_312, typeof(Class12).Assembly);
				Class12.resourceManager_0 = resourceManager;
			}
			return Class12.resourceManager_0;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000090 RID: 144 RVA: 0x000052FC File Offset: 0x000034FC
	// (set) Token: 0x06000091 RID: 145 RVA: 0x0000232E File Offset: 0x0000052E
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return Class12.cultureInfo_0;
		}
		set
		{
			Class12.cultureInfo_0 = value;
		}
	}

	// Token: 0x0400027B RID: 635
	private static ResourceManager resourceManager_0;

	// Token: 0x0400027C RID: 636
	private static CultureInfo cultureInfo_0;
}
