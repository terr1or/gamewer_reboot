using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class AuthenticationRequestMessage : ServerMessage
{
	public AuthenticationRequestMessage()
	{
		this.string_0 = DeProtectType.ArgValue_319;
	}
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_320,
				this.string_0
			},
			{
				DeProtectType.ArgValue_321,
				this.string_1
			},
			{
				DeProtectType.ArgValue_322,
				this.string_2
			},
			{
				DeProtectType.ArgValue_323,
				this.string_3
			},
			{
				DeProtectType.ArgValue_324,
				this.string_4
			},
			{
				DeProtectType.ArgValue_325,
				this.string_5
			},
			{
				DeProtectType.ArgValue_326,
				this.string_6
			},
			{
				DeProtectType.ArgValue_327,
				this.string_7
			},
			{
				DeProtectType.ArgValue_328,
				this.string_8
			}
		});
	}
	[JsonProperty("version")]
	internal string string_1;
	[JsonProperty("steamid")]
	internal string string_2;
	[JsonProperty("hwid")]
	internal string string_3;
	[JsonProperty("pcid")]
	internal string string_4;
	[JsonProperty("dsid")]
	internal string string_5;
	[JsonProperty("lastSessionKey")]
	internal string string_6;
	[JsonProperty("publicKey")]
	internal string string_7;
	[JsonProperty("publicKeyHash")]
	internal string string_8;
}
