using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class DisconnectMessage : ServerMessage
{
	public DisconnectMessage()
	{
		this.string_0 = DeProtectType.ArgValue_363;
	}
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_364,
				this.string_0
			},
			{
				DeProtectType.ArgValue_365,
				this.string_1
			}
		});
	}
	internal static DisconnectMessage smethod_0(string string_2)
	{
		return DisconnectMessage.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_2));
	}
	internal static DisconnectMessage smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new DisconnectMessage
		{
			string_1 = dictionary_0[DeProtectType.ArgValue_366].ToString()
		};
	}
	[JsonProperty("hash")]
	internal string string_1;
}
