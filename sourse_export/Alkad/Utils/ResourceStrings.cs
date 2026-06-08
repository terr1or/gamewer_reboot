using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using GameWer;
/// <summary>Provides access to embedded resources.</summary>
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class ResourceStrings
{
	internal ResourceStrings()
	{
	}
	// (get) Token: 0x0600008F RID: 143 RVA: 0x000052BC File Offset: 0x000034BC
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (ResourceStrings.resourceManager_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager(DeProtectType.ArgValue_312, typeof(ResourceStrings).Assembly);
				ResourceStrings.resourceManager_0 = resourceManager;
			}
			return ResourceStrings.resourceManager_0;
		}
	}
	// (get) Token: 0x06000090 RID: 144 RVA: 0x000052FC File Offset: 0x000034FC
	// (set) Token: 0x06000091 RID: 145 RVA: 0x0000232E File Offset: 0x0000052E
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return ResourceStrings.cultureInfo_0;
		}
		set
		{
			ResourceStrings.cultureInfo_0 = value;
		}
	}
	private static ResourceManager resourceManager_0;
	private static CultureInfo cultureInfo_0;
}
