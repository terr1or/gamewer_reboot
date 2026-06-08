using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class AuthenticationResponseMessage : ServerMessage
{
	public AuthenticationResponseMessage()
	{
		this.string_0 = DeProtectType.ArgValue_329;
	}
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_330,
				this.string_0
			},
			{
				DeProtectType.ArgValue_331,
				this.bool_0
			},
			{
				DeProtectType.ArgValue_332,
				this.string_1
			},
			{
				DeProtectType.ArgValue_333,
				this.string_2
			}
		});
	}
	internal static AuthenticationResponseMessage smethod_0(string string_3)
	{
		return AuthenticationResponseMessage.smethod_1(JsonConvert.DeserializeObject<Dictionary<string, object>>(string_3));
	}
	internal static AuthenticationResponseMessage smethod_1(Dictionary<string, object> dictionary_0)
	{
		return new AuthenticationResponseMessage
		{
			bool_0 = (bool)dictionary_0[DeProtectType.ArgValue_334],
			string_1 = (string)dictionary_0[DeProtectType.ArgValue_335],
			string_2 = (string)dictionary_0[DeProtectType.ArgValue_336]
		};
	}
	[JsonProperty("result")]
	internal bool bool_0;
	[JsonProperty("privateKey")]
	internal string string_1;
	[JsonProperty("sessionKey")]
	public string string_2;
}
