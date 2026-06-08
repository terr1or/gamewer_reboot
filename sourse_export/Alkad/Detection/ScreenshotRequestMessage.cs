using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ScreenshotRequestMessage : ServerMessage
{
	public ScreenshotRequestMessage()
	{
		this.string_0 = DeProtectType.ArgValue_361;
	}
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
	internal static ScreenshotRequestMessage smethod_0(string string_1)
	{
		return ScreenshotRequestMessage.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_1));
	}
	internal static ScreenshotRequestMessage smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new ScreenshotRequestMessage();
	}
}
