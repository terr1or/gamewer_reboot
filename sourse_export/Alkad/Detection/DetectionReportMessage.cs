using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class DetectionReportMessage : ServerMessage
{
	public DetectionReportMessage()
	{
		this.string_0 = DeProtectType.ArgValue_358;
	}
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
	[JsonProperty("processes")]
	internal DetectionFinding[] gstruct0_0;
}
