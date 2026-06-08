using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;
/// <summary>
/// Provides synchronized application settings for the GameWer client.
/// </summary>
[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
internal sealed partial class ApplicationSettings : ApplicationSettingsBase
{
	// (get) Token: 0x06000092 RID: 146 RVA: 0x00005310 File Offset: 0x00003510
	public static ApplicationSettings Default
	{
		get
		{
			return ApplicationSettings.defaultInstance;
		}
	}
	private static ApplicationSettings defaultInstance = (ApplicationSettings)SettingsBase.Synchronized(new ApplicationSettings());
}
