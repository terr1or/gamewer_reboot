using System;
using System.Collections.Generic;
using GameWer;
using Newtonsoft.Json;
/// <summary>
/// Provides the class component for the GameWer client.
/// </summary>
public class ProcessReportMessage : ServerMessage
{
	public ProcessReportMessage()
	{
		this.string_0 = DeProtectType.ArgValue_338;
	}
	internal virtual string vmethod_1()
	{
		return JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				DeProtectType.ArgValue_339,
				this.string_0
			},
			{
				DeProtectType.ArgValue_340,
				this.string_1
			},
			{
				DeProtectType.ArgValue_341,
				this.string_2
			},
			{
				DeProtectType.ArgValue_342,
				this.string_3
			},
			{
				DeProtectType.ArgValue_343,
				this.string_4
			},
			{
				DeProtectType.ArgValue_344,
				this.string_5
			},
			{
				DeProtectType.ArgValue_345,
				this.string_6
			},
			{
				DeProtectType.ArgValue_346,
				this.string_7
			},
			{
				DeProtectType.ArgValue_347,
				this.string_8
			},
			{
				DeProtectType.ArgValue_348,
				this.string_9
			},
			{
				DeProtectType.ArgValue_349,
				this.bool_0
			},
			{
				DeProtectType.ArgValue_350,
				this.int_0
			},
			{
				DeProtectType.ArgValue_351,
				this.string_10
			},
			{
				DeProtectType.ArgValue_352,
				this.string_11
			},
			{
				DeProtectType.ArgValue_353,
				this.string_12
			},
			{
				DeProtectType.ArgValue_354,
				this.string_13
			},
			{
				DeProtectType.ArgValue_355,
				this.string_14
			},
			{
				DeProtectType.ArgValue_356,
				this.int_1
			},
			{
				DeProtectType.ArgValue_357,
				this.string_15
			}
		});
	}
	[JsonProperty("hwid_list")]
	internal string string_1;
	[JsonProperty("modle")]
	internal string string_2;
	[JsonProperty("manufacturer")]
	internal string string_3;
	[JsonProperty("productname")]
	internal string string_4;
	[JsonProperty("organization")]
	internal string string_5;
	[JsonProperty("owner")]
	internal string string_6;
	[JsonProperty("systemroot")]
	internal string string_7;
	[JsonProperty("machinename")]
	internal string string_8;
	[JsonProperty("username")]
	internal string string_9;
	[JsonProperty("isbit64")]
	internal bool bool_0;
	[JsonProperty("memorysize")]
	internal int int_0;
	[JsonProperty("processorname")]
	internal string string_10;
	[JsonProperty("processorid")]
	internal string string_11;
	[JsonProperty("videoname")]
	internal string string_12;
	[JsonProperty("videoid")]
	internal string string_13;
	[JsonProperty("driversname")]
	internal string string_14;
	[JsonProperty("driverssize")]
	internal int int_1;
	[JsonProperty("privateKeyHash")]
	internal string string_15;
}
