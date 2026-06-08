using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ServerBanMessage : ServerMessage
{
	public ServerBanMessage()
	{
		this.string_0 = DeProtectType.ArgValue_313;
	}
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_314,
				this.string_0
			},
			{
				DeProtectType.ArgValue_315,
				this.string_1
			},
			{
				DeProtectType.ArgValue_316,
				this.uint_0
			}
		});
	}
	internal static ServerBanMessage smethod_0(string string_2)
	{
		return ServerBanMessage.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_2));
	}
	internal static ServerBanMessage smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new ServerBanMessage
		{
			string_1 = dictionary_0[DeProtectType.ArgValue_317].ToString(),
			uint_0 = (uint)double.Parse(dictionary_0[DeProtectType.ArgValue_318].ToString())
		};
	}
	[JsonProperty("reason")]
	internal string string_1;
	[JsonProperty("finis_at")]
	internal uint uint_0;
}
